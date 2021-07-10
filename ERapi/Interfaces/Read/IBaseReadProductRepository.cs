using System;
using System.Collections.Generic;
using ER.Entities;

namespace ER.Interfaces
{
    public interface IBaseReadProductRepository
    {
        public Product GetById(Guid Id);
        public IEnumerable<Product> GetAll();
    }
}