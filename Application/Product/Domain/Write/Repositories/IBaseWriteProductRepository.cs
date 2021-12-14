using System;
using System.Collections.Generic;
using Application.Product.Domain.Write.States;

namespace Application.Product.Domain.Write.Repositories
{
    public interface IBaseWriteProductRepository
    {
        public ProductState GetById(Guid Id);
        public void Save(ProductState state);
        public void Delete(ProductState state);
        public void Update(ProductState state);
    }
}