using ERapi.Aplication.Product.Domain.Write.Entities;

namespace ERapi.Aplication.Product.Domain.Write.States
{
    public class ProductState : BaseEntity
    {
        public virtual string Name { get; set; }
        public virtual decimal UnitValue { get; set; }
        public virtual decimal Cost { get; set; }

    }
}