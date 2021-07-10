using System;
using System.Collections.Generic;
using ER.Dtos;

namespace ER.Interfaces
{
    public interface IBaseReadProductRepository
    {
        public ProductDto GetById(Guid Id);
        public IEnumerable<ProductDto> GetAll();
    }
}