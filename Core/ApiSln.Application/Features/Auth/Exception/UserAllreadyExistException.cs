using ApiSln.Application.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSln.Application.Features.Auth.Exception
{
    public class UserAllreadyExistException : BaseException
    {
        public UserAllreadyExistException() : base(" Böyle bir kullanıcı zaten var! ") { }
    }
}
