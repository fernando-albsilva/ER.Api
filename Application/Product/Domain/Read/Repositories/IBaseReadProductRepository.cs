using System;
using System.Collections.Generic;
using Application.Product.Domain.Read.Model;


namespace Application.Product.Domain.Read.Repositories
{
      public interface IBaseReadProductRepository
      {
            public ProductModel GetById(Guid Id);
            public IEnumerable<ProductModel> GetAll();
      }
}