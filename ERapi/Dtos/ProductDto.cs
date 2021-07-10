using System;
using ER.Entities;

namespace ER.Dtos
{
    public class ProductDto : BaseEntity
    {
         public string Name { get; set; }
        public double UnitValue { get; set; }
        public double Cost { get; set; }

    }
}