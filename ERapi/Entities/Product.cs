using System;

namespace ER.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public double UnitValue { get; set; }
        public double Cost { get; set; }

        public Product (Guid IdNovo, string NameNovo, double UnitValueNovo, double CostNovo)
        {
            Id = IdNovo;
            Name = NameNovo;
            UnitValue = UnitValueNovo;
            Cost = CostNovo;
        }
    }
}