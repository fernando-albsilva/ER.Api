using System;
using ER.Entities;

namespace ER.Commands
{
    public class SaveCommand : BaseEntity
    {
        public string Name { get; set; }
        public double UnitValue { get; set; }
        public double Cost { get; set; }

    }

    public class CreateProduct : SaveCommand
    {

    }
      public class UpdateProduct : SaveCommand
    {

    }
}