using Application.Product.Domain.Write.Commands;
using System;
using System.Collections.Generic;


namespace Application.Invoice.Domain.Write.Commands
{

    public class CreateInvoice
    {
        public virtual Guid Id { get; set; }
        public virtual Guid WorkerId { get; set; }
        public virtual DateTime Date { get; set; }
        public virtual string ClientName { get; set; }
        public virtual List<InvoiceItem> InvoiceItems{ get; set; }
    }

    public class InvoiceItem
    {
        public virtual int Id { get; set; }
        public virtual Guid InvoiceId { get; set; }
        public virtual Guid ProductId { get; set; }
        public virtual decimal UnitValue { get; set; }
        public virtual decimal Cost { get; set; }
        public virtual int Quantity { get; set; }
    }

  




}