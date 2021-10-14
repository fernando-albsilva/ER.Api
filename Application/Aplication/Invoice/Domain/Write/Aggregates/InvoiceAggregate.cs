using System;
using System.Linq;
using Application.Aplication.Invoice.Domain.Write.Commands;
using Application.Aplication.Invoice.Domain.Write.States;


namespace Application.Aplication.Invoice.Domain.Write.Aggregates
{
      public class InvoiceAggregate
      {
            public InvoiceState State;

            public InvoiceAggregate()
            {
            }
            public InvoiceAggregate(InvoiceState state)
            {
                    State = state;
            }
            public InvoiceAggregate(CreateInvoice cmd)
            {
                State = new InvoiceState(cmd);
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