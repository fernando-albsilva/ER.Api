using System;
using System.Collections.Generic;
using System.Linq;
using Application.Invoice.Domain.Write.Commands;
using Application.Invoice.Domain.Write.States;
using Application.Product.Domain.Write.States;

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
            public InvoiceAggregate(CreateInvoice cmd)
            {
             
              State.Id = cmd.Id;
              State.WorkerState.Id = cmd.WorkerId;
              State.Date = cmd.Date;
              State.ClientName = cmd.ClientName;
              State.InvoiceItemsState = convertToInvoiceItemsState(cmd.InvoiceItems);
              
            }

            private List<InvoiceItemState> convertToInvoiceItemsState(List<InvoiceItem> CmdInvoiceItems)
            {
                var list = new List<InvoiceItemState>();
                var item = new InvoiceItemState();
                item.InvoiceState = new InvoiceState();
                item.ProductState = new ProductState();

                CmdInvoiceItems.ForEach(CmdItem =>
                {
                    item.Id = CmdItem.Id;
                    item.InvoiceState.Id = CmdItem.InvoiceId;
                    item.ProductState.Id = CmdItem.ProductId;
                    item.UnitValue = CmdItem.UnitValue;
                    item.Cost = CmdItem.Cost;
                    item.Quantity = CmdItem.Quantity;
                    list.Add(item);
                    item = new InvoiceItemState();

                });
                return list;
            }
                /*  public void Change(UpdateProduct cmd)
            {
                  validadeProductCommand(cmd);
                  State.Name = cmd.Name;
                  State.UnitValue = cmd.UnitValue;
                  State.Cost = cmd.Cost;

            }*/

           /* public void validadeProductCommand(UpdateProductCommand cmd)
            {
                  if (string.IsNullOrEmpty(cmd.Name))
                  {
                        throw new Exception("Não existe nome do produto.");
                  }
                  if (cmd.UnitValue == 0)
                  {
                        throw new Exception("Não existe Valor Unitario do produto.");
                  }
                  if (cmd.Cost == 0)
                  {
                        throw new Exception("Não existe Valor do Custo do produto.");
                  }
            }*/
      }
}