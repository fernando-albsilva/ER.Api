using ERapi.Aplication.Product.Domain.Write.Entities;

namespace ERapi.Aplication.Product.Domain.Write.States
{
    public class ProductState : BaseEntity
    {
        public string Name { get; set; }
        public decimal UnitValue { get; set; }
        public decimal Cost { get; set; }

    }
}