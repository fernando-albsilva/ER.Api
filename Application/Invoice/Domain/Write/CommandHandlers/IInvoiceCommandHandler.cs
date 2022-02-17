using System;
using System.Collections.Generic;
using Application.ActiveInvoice.Domain.Read.Model;
using Application.Invoice.Domain.Write.Commands;
using Application.Product.Domain.Write.Commands;

namespace Application.Invoice.Domain.Write.CommandHandlers
{
      public interface IInvoiceCommandHandler
      {
            public void CreateInvoice(CreateInvoiceCommand cmd);
            public void Handle(ActiveInvoiceModel activeInvoice);
/*
            public void Handle(UpdateProduct cmd);

            public void Handle(Guid Id);

            public void Handle(List<Guid> cmd);*/
      }
}