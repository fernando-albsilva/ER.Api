using Aplication.Auth.User.Domain.Read.Model;
using Application.Product.Domain.Read.Model;
using Application.Product.Domain.Write.Commands;
using Application.Worker.Domain.Read.Model;
using System;
using System.Collections.Generic;


namespace Application.Invoice.Domain.Write.Commands
{

    public class Invoice
    {
        public virtual Guid? Id { get; set; }
        public virtual UserModel User { get; set; }
        public virtual WorkerModel Worker { get; set; } 
        public virtual DateTime? Date { get; set; }
        public virtual string ClientName { get; set; }
        public virtual string StartTime { get; set; }
        public virtual IList<InvoiceItem> InvoiceItems { get; set; }
    }

    public class InvoiceItem
    {
        public virtual Guid? Id { get; set; }
        public virtual ProductModel Product { get; set; }
        public virtual decimal UnitValue { get; set; }
        public virtual decimal Cost { get; set; }
        public virtual int? Quantity { get; set; }
        public virtual Guid? InvoiceId { get; set; }
        public virtual Invoice Invoice { get; set; }
    }


    public class CreateInvoiceCommand : Invoice { }
  




}