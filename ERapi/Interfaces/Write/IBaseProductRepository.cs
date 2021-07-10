using System;
using System.Collections.Generic;
using ER.States;

namespace ER.Interfaces
{
    public interface IBaseProductRepository
    {
        public void Save(ProductState state);
        public void Delete();
        public void Update();
    }
}