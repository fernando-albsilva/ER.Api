using System;
using System.Collections.Generic;
using Application.Invoice.Domain.Write.Commands;
using Application.Product.Domain.Write.Commands;

namespace Application.Invoice.Domain.Write.CommandHandlers
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