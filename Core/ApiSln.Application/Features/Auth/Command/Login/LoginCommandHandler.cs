using ApiSln.Application.Bases;
using ApiSln.Application.Features.Auth.Rules;
using ApiSln.Application.İnterface.UnitOfWorks;
using ApiSln.Application.İnterfaces.AutoMapper;
using ApiSln.Application.İnterfaces.Tokens;
using ApiSln.Domain.Entitys;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSln.Application.Features.Auth.Command.Login
{
    public class LoginCommandHandler : BaseHandler, IRequestHandler<LoginCommandRequest, LoginCommandResponse>
    {
        private readonly UserManager<User> userManager;
        private readonly IConfiguration configuration;
        private readonly ITokenService tokenService;
        private readonly RoleManager<Role> roleManager;
        private readonly AuthRules authRules;

        public LoginCommandHandler(UserManager<User> userManager, IConfiguration configuration ,ITokenService tokenService ,RoleManager<Role> roleManager ,AuthRules authRules ,IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
            this.userManager = userManager;
            this.configuration = configuration;
            this.tokenService = tokenService;
            this.roleManager = roleManager;
            this.roleManager = roleManager;
            this.authRules = authRules;
        }
        public  async Task<LoginCommandResponse> Handle(LoginCommandRequest request, CancellationToken cancellationToken)
           {
            User user = await userManager.FindByEmailAsync(request.Email);
            bool checkPassword = await userManager.CheckPasswordAsync(user, request.Password);

            await authRules.EmailOrPasswordShouldNotBeInvalid(user, checkPassword);

            IList<string> roles = await userManager.GetRolesAsync(user);

            JwtSecurityToken token = await tokenService.CreateToken(user, roles);
            string resfreshToken = tokenService.GenerateResfreshToken();

            _ = int.TryParse(configuration["JWT: RefreshTokenValidityDays"], out int refreshTokenValidityDays);

            user.RefreshToken = resfreshToken;
            user.RefreshTokenExpiryTime = DateTime.Now.AddDays(refreshTokenValidityDays);

            await userManager.UpdateAsync(user);
            await userManager.UpdateSecurityStampAsync(user);

            var _token = new JwtSecurityTokenHandler().WriteToken(token);

            await userManager.SetAuthenticationTokenAsync(user, "Default", "AccessToken", _token);

            return new()
            {
                Token = _token,
                RefreshToken = resfreshToken,
                Expiration = token.ValidTo
            };
        }


            
        }
    }

