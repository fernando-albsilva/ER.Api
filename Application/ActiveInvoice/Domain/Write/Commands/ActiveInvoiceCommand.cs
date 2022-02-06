using Aplication.Auth.User.Domain.Read.Model;
using Application.Invoice.Domain.Write.ValueObject;
using Application.Worker.Domain.Read.Model;
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
         public virtual UserModel User { get; set; }
         public virtual WorkerModel Worker { get; set; }
         public virtual DateTime? Date { get; set; }
         public virtual string ClientName { get; set; }
         public virtual int? TableNumber{ get; set; }
         public virtual string StartTime { get; set; }

         public IList<ActiveInvoiceItem> ActiveInvoiceItems { get; set; }
    }

    public class CreateActiveInvoiceCommand : ActiveInvoiceCommand { }
    public class UpdateActiveInvoiceCommand : ActiveInvoiceCommand { }
}
