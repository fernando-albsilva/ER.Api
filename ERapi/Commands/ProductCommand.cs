using System;
using ER.Entities;

namespace ER.Commands
{
    public class SaveProductCommand : BaseEntity
    {
        public string Name { get; set; }
        public decimal UnitValue { get; set; }
        public decimal Cost { get; set; }

    }

    public class CreateProduct : SaveProductCommand
    {

    }
      public class UpdateProduct : SaveProductCommand
    {

    }
}