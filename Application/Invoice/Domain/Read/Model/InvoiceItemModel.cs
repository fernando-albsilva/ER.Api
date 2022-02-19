using Application.Product.Domain.Read.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Invoice.Domain.Read.Model
{
    public class InvoiceItemModel
    {
        public virtual Guid? Id { get; set; }
        public virtual ProductModel Product { get; set; }
        public virtual decimal UnitValue { get; set; }
        public virtual decimal Cost { get; set; }
        public virtual int? Quantity { get; set; }
    }
}
