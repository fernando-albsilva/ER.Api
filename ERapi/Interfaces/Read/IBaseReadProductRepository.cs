using System;
using System.Collections.Generic;
using ER.Models;

namespace ER.Interfaces
{
    public interface IBaseReadProductRepository
    {
        public ProductModel GetById(Guid Id);
        public IEnumerable<ProductModel> GetAll();
    }
}