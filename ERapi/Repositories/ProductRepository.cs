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
           new Product { Id = new Guid(), Name = "coca", UnitValue = 5.50, Cost = 3.00 },
           new Product { Id = new Guid(), Name = "guarana", UnitValue = 6.50, Cost = 2.50 },
           new Product { Id = new Guid(), Name = "batata-frita", UnitValue = 15.50, Cost = 13.00 }
       };

       public IEnumerable<Product> GetProducts()
       {
           return products;
       }

    //    public Product GetProduct(Guid Id)
    //    {
    //        return products.Where( product => product.Id == Id).SingleOrDefault();
    //    }

    }
}