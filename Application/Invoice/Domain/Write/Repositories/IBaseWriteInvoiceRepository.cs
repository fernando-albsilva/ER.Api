using System;
using System.Collections.Generic;
using Application.Invoice.Domain.Write.States;

namespace Application.Invoice.Domain.Write.Repositories
{
      public interface IBaseWriteInvoiceRepository
      { 
            public void Save(InvoiceState state); 
            public void Delete(InvoiceState state);
         
      }
}