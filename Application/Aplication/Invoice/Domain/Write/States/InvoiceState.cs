

using Application.Aplication.Invoice.Domain.Write.Commands;
using Application.Aplication.Product.Domain.Write.Commands;
using System;
using System.Collections.Generic;

namespace Application.Aplication.Invoice.Domain.Write.States
{
    public class BaseInvoiceState
    {
        public Guid Id { get; set; }
    }
    public class InvoiceState : BaseInvoiceState
    {
        public Table Table { get; set; }

        public InvoiceState (CreateInvoice cmd)
        {
            this.Id = cmd.Id;
            this.Table= cmd.Table;  
        }
    }
}