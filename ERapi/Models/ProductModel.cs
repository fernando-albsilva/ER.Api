using System;
using ER.Entities;

namespace ER.Models
{
    public class ProductModel : BaseEntity
    {
        public string Name { get; set; }
        public decimal UnitValue { get; set; }
        public decimal Cost { get; set; }

    }
}