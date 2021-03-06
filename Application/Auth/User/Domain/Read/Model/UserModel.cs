
using System;

namespace Aplication.Auth.User.Domain.Read.Model
{
    public class UserModel
    {
        public virtual Guid Id { get; set; }
        public virtual string UserName { get; set; }
        public virtual string Password { get; set; }
        public virtual string Role { get; set; }
    }
}
