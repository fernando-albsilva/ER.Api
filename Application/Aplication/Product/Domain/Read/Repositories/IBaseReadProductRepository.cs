using System;
using System.Collections.Generic;
using Application.Aplication.Product.Domain.Read.Model;

namespace Application.Aplication.Product.Domain.Read.Repositories
{
      public interface IBaseReadProductRepository
      {
            public ProductModel GetById(Guid Id);
            public IEnumerable<ProductModel> GetAll();
      }
}