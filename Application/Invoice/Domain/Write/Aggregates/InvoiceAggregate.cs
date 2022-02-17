using System;
using System.Collections.Generic;
using System.Linq;
using Aplication.Auth.User.Domain.Read.Model;
using Aplication.Auth.User.Domain.Write.States;
using Application.Invoice.Domain.Write.Commands;
using Application.Invoice.Domain.Write.States;
using Application.Product.Domain.Read.Model;
using Application.Product.Domain.Write.States;
using Application.Worker.Domain.Read.Model;
using Application.Worker.Domain.Write.States;

namespace Application.Invoice.Domain.Write.Aggregates
{
      public class InvoiceAggregate
      {
            public InvoiceState State = new InvoiceState();

            public InvoiceAggregate()
            {
            }
            public InvoiceAggregate(InvoiceState state)
            {
                    State = state;
            }
            public InvoiceAggregate(CreateInvoiceCommand cmd)
            {

            State = new InvoiceState()
            {
                Id = cmd.Id,
                Date = cmd.Date,
                ClientName = cmd.ClientName,
                Worker = cmd.Worker,
                User = cmd.User,
                InvoiceItemsState = new List<InvoiceItemState>()
            };

                foreach (var invoiceItem in cmd.InvoiceItems)
                {
                    var item = new InvoiceItemState
                    {
                        Id = invoiceItem.Id,
                        Quantity = invoiceItem.Quantity,
                        Cost = invoiceItem.Cost,
                        UnitValue = invoiceItem.UnitValue,
                        Product = invoiceItem.Product,
                        Invoice = State
                    };

                    State.InvoiceItemsState.Add(item);
                }

            }

         
      }
}