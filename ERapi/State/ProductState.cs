using ER.Entities;

namespace ER.States
{
    public class ProductState : BaseEntity
    {
        public string Name { get; set; }
        public double UnitValue { get; set; }
        public double Cost { get; set; }

    }
}