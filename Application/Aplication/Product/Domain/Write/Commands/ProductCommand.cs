using System;
using System.Collections.Generic;
using Application.Aplication.Product.Domain.Write.Entities;

namespace Application.Aplication.Product.Domain.Write.Commands
{
      public class UpdateProductCommand : BaseEntity
      {
            public string Name { get; set; }
            public decimal UnitValue { get; set; }
            public decimal Cost { get; set; }

      }

      public class CreateProduct : UpdateProductCommand
      {

      }
      public class UpdateProduct : UpdateProductCommand
      {

      }

      public class DeleteProduct : BaseEntity
      {

      }

      public class DeleteProductList
      {
            public List<Guid> idList = new List<Guid>();

      }

}