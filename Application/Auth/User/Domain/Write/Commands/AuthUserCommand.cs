using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Auth.User.Domain.Write.Commands
{
    public class AuthUserCommand
    {
        public virtual string UserName { get; set; }
        public virtual string Password { get; set; }
    }
}
