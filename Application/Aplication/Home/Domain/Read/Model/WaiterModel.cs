using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Aplication.Home.Domain.Read.Model
{
    public class WaiterModel 
    {
        public virtual Guid WorkerId { get; set; }
        public virtual string Name { get; set; }
    }
}
