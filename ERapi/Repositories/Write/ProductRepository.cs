using ER.Interfaces;
using System.Collections.Generic;
using System;
using System.Linq;
using ER.States;

namespace ER.Repositories
{
    public class ProductRepository : IBaseProductRepository
    {
  
        public void Save(ProductState state)
        {
            Console.WriteLine(state);
            // throw new NotImplementedException();
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}