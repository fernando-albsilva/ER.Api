using Application.ActiveInvoice.Domain.Write.Commands;
using Application.ActiveInvoice.Domain.Write.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ActiveInvoice.Domain.Write.Aggregates
{ 
    public class ActiveInvoiceAggregate
    {
        public ActiveInvoiceState State;

        public ActiveInvoiceAggregate(CreateActiveInvoiceCommand cmd)
        {
            State = new ActiveInvoiceState() 
            {
                Id = cmd.Id,
                UserId = cmd.UserId,
                WorkerId = cmd.WorkerId,
                Date = cmd.Date,
                ClientName = cmd.ClientName,
                TableNumber = cmd.TableNumber,
                StartTime = cmd.StartTime
            };

            cmd.ActiveInvoiceItems.ForEach(
                item => 
                {
                    State.ActiveInvoiceItemsState.Add(
                        new ActiveInvoiceItemState
                        {
                            Id = item.Id,
                            ActiveInvoiceId = item.InvoiceActiveId,
                            ProductId = item.ProductId,
                            Quantity = item.Quantity
                        }
                    );
                }
            );
        }
    }
}
