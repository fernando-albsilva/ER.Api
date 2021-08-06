using System;
using ERapi.Aplication.Product.Domain.Read.BaseModel;

namespace ERapi.Aplication.Product.Domain.Read.Model
{
    public class ProductModel : BaseReadModel
    {
        public virtual string Name { get; set; }
        public virtual decimal UnitValue { get; set; }
        public virtual decimal Cost { get; set; }

    }
}