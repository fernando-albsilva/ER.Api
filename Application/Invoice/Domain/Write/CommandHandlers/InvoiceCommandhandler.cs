using System;
using Application.Invoice.Domain.Read.Repositories;
using Application.Invoice.Domain.Write.Commands;
using Application.Invoice.Domain.Write.Repositories;
using Application.Invoice.Domain.Write.Aggregates;
using Application.ActiveInvoice.Domain.Read.Model;
using NHibernate.Util;
using System.Collections.Generic;
using Application.Worker.Domain.Read.Model;
using Aplication.Auth.User.Domain.Read.Model;

namespace Application.Invoice.Domain.Write.CommandHandlers
{
      public class InvoiceCommandhandler : IInvoiceCommandHandler
      {
            private readonly IBaseReadInvoiceRepository readRepository;
            private readonly IBaseWriteInvoiceRepository writeRepository;

            public InvoiceCommandhandler(IBaseReadInvoiceRepository readRepository, IBaseWriteInvoiceRepository writeRepository)
            {
                  this.readRepository = readRepository;
                  this.writeRepository = writeRepository;
            }

            public void CreateInvoice(CreateInvoiceCommand cmd)
            {
                cmd.Id = Guid.NewGuid();
                var aggregate = new InvoiceAggregate(cmd);
        
                writeRepository.Save(aggregate.State);
            }

            public void Handle(ActiveInvoiceModel activeInvoice)
            {
                var cmd = parseActiveInvoice(activeInvoice);
                CreateInvoice(cmd);
            }

            private CreateInvoiceCommand parseActiveInvoice(ActiveInvoiceModel activeInvoice)
            {
                var cmd = new CreateInvoiceCommand
                {
                    Id = activeInvoice.Id != null ? activeInvoice.Id : Guid.NewGuid(),
                    ClientName = activeInvoice.ClientName,
                    Date = activeInvoice.Date,
                    Worker = new WorkerModel { Id = activeInvoice.Worker.Id },
                    User = new UserModel { Id = (Guid)activeInvoice.UserId },
                    InvoiceItems = new List<InvoiceItem>()
                 };

                    foreach(var item in activeInvoice.ActiveInvoiceItems)
                    {
                        var invoiceItem = new InvoiceItem
                        {
                             Id = item.Id,
                             Cost = item.Product.Cost,
                             InvoiceId = item.ActiveInvoiceId,
                             Product = item.Product,
                             Quantity = item.Quantity,
                             UnitValue = item.Product.UnitValue
                        };

                        cmd.InvoiceItems.Add(invoiceItem);
                    }

                return cmd;
            }
      }
}