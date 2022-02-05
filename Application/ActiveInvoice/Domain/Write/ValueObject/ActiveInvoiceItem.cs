using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Invoice.Domain.Write.ValueObject
{
    public class ActiveInvoiceItem
    {
        public virtual Guid? Id { get; set; }
        public virtual Guid? InvoiceActiveId { get; set; }
        public virtual Guid? ProductId { get; set; }
        public virtual int? Quantity { get; set; }
    }
}
