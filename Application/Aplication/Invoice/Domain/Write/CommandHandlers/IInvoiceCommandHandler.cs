using System;
using System.Collections.Generic;
using Application.Aplication.Invoice.Domain.Write.Commands;
using Application.Aplication.Product.Domain.Write.Commands;

namespace Application.Aplication.Invoice.Domain.Write.CommandHandlers
{
      public interface IInvoiceCommandHandler
      {
            public void Handle(CreateInvoice cmd);
/*
            public void Handle(UpdateProduct cmd);

            public void Handle(Guid Id);

            public void Handle(List<Guid> cmd);*/
      }
}