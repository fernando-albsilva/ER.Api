using System;
using ER.Commands;
using ER.States;

namespace ER.Aggregates
{
    public class ProductAggregate
    {
        public ProductState State;
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
                Cost = cmd.Cost
            };
        }

        public void Change(UpdateProduct cmd)
        {
                validadeProductCommand(cmd);
                this.State.Name = cmd.Name;
                this.State.UnitValue = cmd.UnitValue;
                this.State.Cost = cmd.Cost;
  
        }

        public void validadeProductCommand(SaveProductCommand cmd)
        {
            if (String.IsNullOrEmpty(cmd.Name))
            {
                throw new Exception("Não existe nome do produto.");
            }
            if(cmd.UnitValue == 0)
            {
                throw new Exception("Não existe Valor Unitario do produto.");
            }
             if(cmd.Cost == 0)
            {
                throw new Exception("Não existe Valor do Custo do produto.");
            }
        }
    }
}