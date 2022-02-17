
using Application.Product.Domain.Read.Model;
using Application.Product.Domain.Write.States;
using Application.Worker.Domain.Write.States;
using System;

namespace Application.Invoice.Domain.Write.States
{
    public class InvoiceItemState
    {
        public virtual Guid? Id { get; set; }
        public virtual InvoiceState Invoice { get; set; }
        public virtual ProductModel Product { get; set; }
        public virtual decimal UnitValue { get; set; }
        public virtual decimal Cost { get; set; }
        public virtual int? Quantity { get; set; }
    }
}
