using System;
using System.Collections.Generic;
using ER.Entities;

namespace ER.Interfaces
{
    public interface IBaseProductRepository
    {
        void save();
        void Update();
        void Delete();
        public Product GetById(Guid Id);
        public IEnumerable<Product> GetAll();
    }
}