using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Auth.User.Domain.Read.Model
{
    public class UserFlatModel
    {
        public virtual Guid Id { get; set; }
        public virtual string Role { get; set; }
        public virtual string  UserName { get; set; }
    }
}
