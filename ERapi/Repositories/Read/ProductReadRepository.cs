using ER.Interfaces;
using ER.Models;
using System.Collections.Generic;
using System;
using System.Linq;

namespace ER.Repositories
{
    public class ProductReadRepository : IBaseReadProductRepository
    {
       private readonly List<ProductModel> products = new List<ProductModel>()
       {
           new ProductModel { Id = Guid.Parse("37093981-646b-460b-8cca-43aa1da0db5f"), Name = "coca", UnitValue = 5.50, Cost = 3.00 },
           new ProductModel { Id = Guid.Parse("ae8949bf-bd45-4af8-ba61-5947665bacd1"), Name = "guarana", UnitValue = 6.50, Cost = 2.50 },
           new ProductModel { Id = Guid.Parse("bf0649dd-afb8-4dc6-a71b-ae3c3a1cd717"), Name = "batata-frita", UnitValue = 15.50, Cost = 13.00 },
          
       };

        public ProductModel GetById(Guid Id)
        {
            try
            {
                 var product = products.Where( product => product.Id == Id).SingleOrDefault();
                 return product;
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public IEnumerable<ProductModel> GetAll()
       {
           try
            {
                 return products;
            }
            catch
            {
                throw new NotImplementedException();
            }
       }
    }
}