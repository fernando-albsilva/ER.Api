using ER.Entities;

namespace ER.States
{
    public class ProductState : BaseEntity
    {
        public string Name { get; set; }
        public decimal UnitValue { get; set; }
        public decimal Cost { get; set; }

    }
}