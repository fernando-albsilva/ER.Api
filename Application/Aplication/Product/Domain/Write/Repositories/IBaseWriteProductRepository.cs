using System;
using System.Collections.Generic;
using Application.Aplication.Product.Domain.Write.States;

namespace Application.Aplication.Product.Domain.Write.Repositories
{
      public interface IBaseWriteInvoiceRepository
      {
            public InvoiceState GetById(Guid Id);
            public void Save(InvoiceState state);
            public void Delete(InvoiceState state);
            public void Update(InvoiceState state);
      }
}