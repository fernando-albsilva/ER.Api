
using Application.Product.Domain.Write.States;


namespace Application.Invoice.Domain.Write.States
{
    public class InvoiceItemState
    {
        public virtual int Id { get; set; }
        public virtual InvoiceState InvoiceState { get; set; }
        public virtual ProductState ProductState { get; set; }
        public virtual decimal UnitValue { get; set; }
        public virtual decimal Cost { get; set; }
        public virtual int Quantity { get; set; }
    }
}
