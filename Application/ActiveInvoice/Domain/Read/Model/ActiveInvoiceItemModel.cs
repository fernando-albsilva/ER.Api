using Application.Product.Domain.Read.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ActiveInvoice.Domain.Read.Model
{
    public class ActiveInvoiceItemModel
    {
        public virtual Guid? Id { get; set; }
        public virtual Guid? ActiveInvoiceId { get; set; }
        public virtual int? Quantity { get; set; }
        public virtual ProductModel Product{ get; set; }
    }
}
