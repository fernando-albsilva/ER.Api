using Application.Aplication.Product.Domain.Write.Commands;
using System;
using System.Collections.Generic;


namespace Application.Aplication.Invoice.Domain.Write.Commands
{
    public class BaseInvoiceCommand
    {
        public Guid Id { get; set; }
    }
    public class CreateInvoice : BaseInvoiceCommand
    {
        public Table Table { get; set; }
    }

    public class Table
    {
        public string ClientName { get; set; }
        public Guid WaiterId { get; set; }
        public List<Products> products { get; set; }
    }

    public class Products : UpdateProductCommand  
    {
        public int Quantity { get; set; }
    }




}