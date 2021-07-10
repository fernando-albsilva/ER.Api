using ER.Interfaces;
using ER.Entities;
using System.Collections.Generic;
using System;
using System.Linq;

namespace ER.Repositories
{
    public class ProductRepository 
    {
       private readonly List<Product> products = new List<Product>()
       {
        //    new Product { Id = Guid.NewGuid(), Name = "coca", UnitValue = 5.50, Cost = 3.00 },
        //    new Product { Id = Guid.NewGuid(), Name = "guarana", UnitValue = 6.50, Cost = 2.50 },
        //    new Product { Id = Guid.NewGuid(), Name = "batata-frita", UnitValue = 15.50, Cost = 13.00 }
           new Product (  Guid.Parse("37093981-646b-460b-8cca-43aa1da0db5f"),  "coca",  5.50,  3.00 ),
           new Product (  Guid.Parse("ae8949bf-bd45-4af8-ba61-5947665bacd1"), "guarana", 6.50, 2.50 ),
           new Product ( Guid.Parse("bf0649dd-afb8-4dc6-a71b-ae3c3a1cd717"),  "batata-frita", 15.50,  13.00 )
       };

       public IEnumerable<Product> GetProducts()
       {
           return products;
       }

       public Product GetProduct(Guid Id)
       {
           var product = products.Where( product => product.Id == Id).SingleOrDefault();
           return product;
       }

    }
}