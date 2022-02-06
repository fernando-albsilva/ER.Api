using Application.Product.Domain.Read.Model;
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
        public virtual ProductModel Product { get; set; }
        public virtual int? Quantity { get; set; }
    }
}
