using Application.Invoice.Domain.Read.Model;
using System;
using System.Collections.Generic;



namespace Application.Invoice.Domain.Read.Repositories
{
      public interface IBaseReadInvoiceRepository
      {
          public InvoiceModel GetById(Guid Id);
          public IList<InvoiceFlatModel> GetAllInvoices();
          //public IEnumerable<InvoiceModel> GetAll();
      }
}