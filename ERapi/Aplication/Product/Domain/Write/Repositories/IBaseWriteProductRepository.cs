using System;
using System.Collections.Generic;
using ERapi.Aplication.Product.Domain.Write.States;

namespace ERapi.Aplication.Product.Domain.Write.Repositories
{
    public interface IBaseWriteProductRepository
    {
        public void Save(ProductState state);
        public void Delete(Guid Id);
        public void Update(ProductState state);
    }
}