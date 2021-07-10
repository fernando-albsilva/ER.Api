using System;
using ER.Entities;

namespace ER.Models
{
    public class ProductModel : BaseEntity
    {
         public string Name { get; set; }
        public double UnitValue { get; set; }
        public double Cost { get; set; }

    }
}