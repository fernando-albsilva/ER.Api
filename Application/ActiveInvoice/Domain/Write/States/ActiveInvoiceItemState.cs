using Application.Product.Domain.Write.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ActiveInvoice.Domain.Write.States
{
    public class ActiveInvoiceItemState
    {
        public virtual Guid? Id { get; set; }
        public virtual Guid? ActiveInvoiceId { get; set; }
        public virtual Guid? ProductId { get; set; }
        public virtual int? Quantity { get; set; }
    }
}
