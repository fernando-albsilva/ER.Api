using System;
using System.Collections.Generic;
using Application.Aplication.Invoice.Domain.Write.States;

namespace Application.Aplication.Invoice.Domain.Write.Repositories
{
      public interface IBaseWriteInvoiceRepository
      {
          /*  public InvoiceState GetById(Guid Id);*/
            public void Save(InvoiceState state);
         /*   public void Delete(InvoiceState state);
            public void Update(InvoiceState state);*/
      }
}