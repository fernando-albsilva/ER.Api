using System;
using ERapi.Aplication.Product.Domain.Read.BaseModel;

namespace ERapi.Aplication.Product.Domain.Read.Model
{
    public class ProductModel : BaseReadModel
    {
        public string Name { get; set; }
        public decimal UnitValue { get; set; }
        public decimal Cost { get; set; }

    }
}