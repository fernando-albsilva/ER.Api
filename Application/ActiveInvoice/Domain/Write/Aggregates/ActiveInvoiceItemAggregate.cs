using Application.ActiveInvoice.Domain.Write.Commands;
using Application.ActiveInvoice.Domain.Write.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ActiveInvoice.Domain.Write.Aggregates
{
    public class ActiveInvoiceItemAggregate
    {
        public ActiveInvoiceItemState State;

        public ActiveInvoiceItemAggregate(ActiveInvoiceItemState state)
        {
            State = state;
        }

        public ActiveInvoiceItemAggregate(CreateActiveInvoiceItemCommand cmd)
        {
            State = new ActiveInvoiceItemState()
            {
                Id = cmd.Id,
                Product = cmd.Product,
                Quantity = cmd.Quantity,
                ActiveInvoiceState = new ActiveInvoiceState()
            };

            State.ActiveInvoiceState.Id = cmd.activeInvoiceId;
        }
    }
}
