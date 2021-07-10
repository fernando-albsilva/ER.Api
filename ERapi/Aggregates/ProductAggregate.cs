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
            State = new ProductState
            {
                Id = cmd.Id,
                Name = cmd.Name,
                UnitValue = cmd.UnitValue,
                Cost = cmd.Cost
            };
        }
    }
}