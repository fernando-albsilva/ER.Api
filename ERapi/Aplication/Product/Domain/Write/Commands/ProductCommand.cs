using System;
using ERapi.Aplication.Product.Domain.Write.Entities;

namespace ERapi.Aplication.Product.Domain.Write.Commands
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