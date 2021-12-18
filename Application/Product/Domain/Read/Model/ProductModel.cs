using System;
using Application.Product.Domain.Read.BaseModel;

namespace Application.Product.Domain.Read.Model
{
      public class ProductModel : BaseReadModel
      {
            public virtual string Name { get; set; }
            public virtual decimal UnitValue { get; set; }
            public virtual decimal Cost { get; set; }
            public virtual int Code { get; set; }

      }
}