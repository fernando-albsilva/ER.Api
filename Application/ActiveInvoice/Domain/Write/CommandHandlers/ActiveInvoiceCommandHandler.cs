using Application.ActiveInvoice.Domain.Write.Aggregates;
using Application.ActiveInvoice.Domain.Write.Commands;
using Application.ActiveInvoice.Domain.Write.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ActiveInvoice.Domain.Write.CommandHandlers
{
    public class ActiveInvoiceCommandHandler : IActiveInvoiceCommandHandler
    {
        private readonly IBaseWriteActiveInvoiceRepository ActiveInvoiceWriteRepository;

        public ActiveInvoiceCommandHandler(
            IBaseWriteActiveInvoiceRepository activeInvoiceWriteRepository
        )
        {
            ActiveInvoiceWriteRepository = activeInvoiceWriteRepository;
        }
        public void handle(CreateActiveInvoiceCommand cmd)
        {
            var aggregate = new ActiveInvoiceAggregate(cmd);
            ActiveInvoiceWriteRepository.save(aggregate.State);
        }

        public void handle(ChangeActiveInvoiceCommand cmd)
        {
            throw new NotImplementedException();
        }

        public void handle(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
