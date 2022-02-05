using Application.Invoice.Domain.Write.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ActiveInvoice.Domain.Write.Commands
{
    public class ActiveInvoiceCommand
    {
         public virtual Guid? Id { get; set; }
         public virtual Guid? UserId { get; set; }
         public virtual Guid? WorkerId { get; set; }
         public virtual DateTime? Date { get; set; }
         public virtual string? ClientName { get; set; }
         public virtual int? TableNumber{ get; set; }
         public virtual string? StartTime { get; set; }

         public List<ActiveInvoiceItem> ActiveInvoiceItems = new List<ActiveInvoiceItem>();
    }

    public class CreateActiveInvoiceCommand : ActiveInvoiceCommand { }
    public class ChangeActiveInvoiceCommand : ActiveInvoiceCommand { }
}
