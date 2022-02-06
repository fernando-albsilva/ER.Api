using Application.ActiveInvoice.Domain.Write.Commands;
using Application.ActiveInvoice.Domain.Write.States;
using Application.Product.Domain.Read.Model;
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

        public ActiveInvoiceAggregate(ActiveInvoiceState state)
        {
            State = state;
        }

        public ActiveInvoiceAggregate(CreateActiveInvoiceCommand cmd)
        {
            State = new ActiveInvoiceState() 
            {
                Id = cmd.Id,
                User = cmd.User,
                Worker = cmd.Worker,
                Date = cmd.Date,
                ClientName = cmd.ClientName,
                TableNumber = cmd.TableNumber,
                StartTime = cmd.StartTime
            };

            foreach(var invoiceItem in cmd.ActiveInvoiceItems)
            {
                State.ActiveInvoiceItemsState.Add(
                    new ActiveInvoiceItemState
                    {
                        Id = invoiceItem.Id,
                        Product = invoiceItem.Product,
                        Quantity = invoiceItem.Quantity
                    }
                );
            }
            
        }

        public void Change(UpdateActiveInvoiceCommand cmd)
        { 
            State.User = cmd.User;
            State.Worker = cmd.Worker;
            State.Date = cmd.Date;
            State.ClientName = cmd.ClientName;
            State.TableNumber = cmd.TableNumber;
            State.StartTime = cmd.StartTime;


            foreach ( var cmdItem in cmd.ActiveInvoiceItems)
            {
                foreach (var stateItem in State.ActiveInvoiceItemsState)
                {
                    if( cmdItem.Id == stateItem.Id)
                    {
                        stateItem.Product = cmdItem.Product;
                        stateItem.Quantity = cmdItem.Quantity;
                    }
                }
            }
        }
    }
}
