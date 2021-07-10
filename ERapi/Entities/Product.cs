namespace ER.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public double UnitValue { get; set; }
        public double Cost { get; set; }
    }
}