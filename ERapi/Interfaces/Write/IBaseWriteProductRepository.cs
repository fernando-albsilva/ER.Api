using System;
using System.Collections.Generic;
using ER.States;

namespace ER.Interfaces
{
    public interface IBaseWriteProductRepository
    {
        public void Save(ProductState state);
        public void Delete(Guid Id);
        public void Update(ProductState state);
    }
}