using System;
using System.Collections.Generic;
using ERapi.Aplication.Product.Domain.Read.Model;

namespace ERapi.Aplication.Product.Domain.Read.Repositories
{
    public interface IBaseReadProductRepository
    {
        public ProductModel GetById(Guid Id);
        public IEnumerable<ProductModel> GetAll();
    }
}