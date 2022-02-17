using Application.ActiveInvoice.Domain.Write.Aggregates;
using Application.ActiveInvoice.Domain.Write.Commands;
using Application.ActiveInvoice.Domain.Write.Repositories;
using Application.ActiveInvoice.Domain.Write.States;
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
        public void Handle(CreateActiveInvoiceCommand cmd)
        {
            var aggregate = new ActiveInvoiceAggregate(cmd);
            ActiveInvoiceWriteRepository.save(aggregate.State);
        }

        public void Handle(UpdateActiveInvoiceCommand cmd)
        {
            ActiveInvoiceState activeInvoiceState = new ActiveInvoiceState();
            
            if (IsTable(cmd))
            {
                activeInvoiceState = ActiveInvoiceWriteRepository.GetByTableNumber(cmd.TableNumber);
            }
            else
            {
                activeInvoiceState = ActiveInvoiceWriteRepository.GetByTableNumber(cmd.TableNumber);
            }

            ValidadeId(activeInvoiceState);
            
            var aggregate = new ActiveInvoiceAggregate(activeInvoiceState);
            
            aggregate.Change(cmd);
            
            ActiveInvoiceWriteRepository.Update(aggregate.State);
        }

        public void Handle(CreateActiveInvoiceItemCommand cmd)
        {
            var aggregate = new ActiveInvoiceItemAggregate(cmd);
            ActiveInvoiceWriteRepository.save(aggregate.State);
        }
        public void RemoveActiveInvoiceItem(Guid Id)
        {
            ActiveInvoiceItemState activeInvoiceItemState = ActiveInvoiceWriteRepository.GetActiveInvoiceItemById(Id);
            ValidadeActiveInvoiceItemId(activeInvoiceItemState);
            ActiveInvoiceWriteRepository.Delete(activeInvoiceItemState);
        }

        public void Handle(Guid id)
        {
            throw new NotImplementedException();
        }

        public void CloseCheck(Guid activeInvoiceId)
        {
            throw new NotImplementedException();
        }

        private void ValidadeId(ActiveInvoiceState activeInvoiceState)
        {

            if (activeInvoiceState.Id == Guid.Empty)
            {
                throw new Exception("Não existe registro com esse Id.");
            }

        }
        private void ValidadeActiveInvoiceItemId(ActiveInvoiceItemState activeInvoiceItemState)
        {

            if (activeInvoiceItemState.Id == Guid.Empty)
            {
                throw new Exception("Não existe registro com esse Id.");
            }

        }

        private bool IsTable(ActiveInvoiceCommand cmd)
        {
            return cmd.TableNumber is not null;
        }
    }
}
