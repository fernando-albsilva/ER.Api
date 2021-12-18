using Application.Invoice.Domain.Write.States;
using Application.Product.Domain.Write.Entities;
using System.Collections.Generic;

namespace Application.Product.Domain.Write.States
{
    public class ProductState : BaseEntity
    {
        public virtual string Name { get; set; }
        public virtual decimal UnitValue { get; set; }
        public virtual decimal Cost { get; set; }
        public virtual int Code { get; set; }
        public virtual IList<InvoiceItemState> InvoiceItemState { get; set; }

      }
}