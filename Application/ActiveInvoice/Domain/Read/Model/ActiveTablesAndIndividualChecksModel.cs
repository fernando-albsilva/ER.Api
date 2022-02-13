using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ActiveInvoice.Domain.Read.Model
{
    public class ActiveTablesAndIndividualChecksModel
    {
        public virtual Guid Id{ get; set; }
        public virtual int? TableNumber { get; set; }
        public virtual int? IndividualCheckNumber { get; set; }
    }
}
