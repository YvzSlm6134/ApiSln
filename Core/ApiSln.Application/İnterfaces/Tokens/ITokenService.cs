﻿using ApiSln.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ApiSln.Application.İnterfaces.Tokens
{
    public interface ITokenService
    {
        Task<JwtSecurityToken> CreateToken(User user, IList<string> roles);
        string GenerateResfreshToken();
        ClaimsPrincipal? GetPrincipalFromExpiredToken(string? token);
    }
}
