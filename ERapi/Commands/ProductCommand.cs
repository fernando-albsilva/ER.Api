using System;
using ER.Entities;

namespace ER.Commands
{
    public class SaveCommand : BaseEntity
    {
        public string Name { get; set; }
        public decimal UnitValue { get; set; }
        public decimal Cost { get; set; }

    }

    public class CreateProduct : SaveCommand
    {

    }
      public class UpdateProduct : SaveCommand
    {

    }
}