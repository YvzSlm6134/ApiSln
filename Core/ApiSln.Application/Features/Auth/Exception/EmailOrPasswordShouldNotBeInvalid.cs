using ApiSln.Application.Bases;

namespace ApiSln.Application.Features.Auth.Exception
{
    public class EmailOrPasswordShouldNotBeInvalidException : BaseException
    {
        public EmailOrPasswordShouldNotBeInvalidException() : base(" Kullanıcı adı veya şifre yanlıştır. ") { }
    }
}
