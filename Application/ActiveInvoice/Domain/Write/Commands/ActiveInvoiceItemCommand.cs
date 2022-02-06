using Application.ActiveInvoice.Domain.Read.Model;
using Application.Product.Domain.Read.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ActiveInvoice.Domain.Write.Commands
{
    public class ActiveInvoiceItemCommand
    {
        public virtual Guid? Id { get; set; }
        public virtual ProductModel Product { get; set; }
        public virtual int? Quantity { get; set; }
        public virtual Guid activeInvoiceId { get; set; }
        public virtual ActiveInvoiceModel ActiveInvoice { get; set; }
    }

    public class CreateActiveInvoiceItemCommand : ActiveInvoiceItemCommand { }
}
