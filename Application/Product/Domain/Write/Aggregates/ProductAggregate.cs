using System;
using Application.Product.Domain.Write.Commands;
using Application.Product.Domain.Write.States;

namespace Application.Product.Domain.Write.Aggregates
{
      public class ProductAggregate
      {
            public ProductState State;

            public ProductAggregate()
            {
            }
            public ProductAggregate(ProductState state)
            {
                    State = state;
            }
            public ProductAggregate(CreateProduct cmd)
            {
                  validadeProductCommand(cmd);
                  State = new ProductState
                  {
                        Id = cmd.Id,
                        Name = cmd.Name,
                        UnitValue = cmd.UnitValue,
                        Cost = cmd.Cost,
                        Code = cmd.Code
                  };
            }

            public void Change(UpdateProduct cmd)
            {
                  validadeProductCommand(cmd);
                  State.Name = cmd.Name;
                  State.UnitValue = cmd.UnitValue;
                  State.Cost = cmd.Cost;
                  State.Code= cmd.Code;

            }

            public void validadeProductCommand(UpdateProductCommand cmd)
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
            }
      }
}