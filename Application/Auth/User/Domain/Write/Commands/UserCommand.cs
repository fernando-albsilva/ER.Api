
using System;

namespace Aplication.Auth.User.Domain.Write.Commands
{
    public class UserCommand
    {
        public virtual Guid Id { get; set; }
        public virtual string UserName { get; set; }
        public virtual string Password { get; set; }
        public virtual string Role { get; set; }
    }

    public class CreateUser : UserCommand { }

    public class UpdateUser: UserCommand { }
}
