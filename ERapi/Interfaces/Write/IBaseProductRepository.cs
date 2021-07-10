using System;
using System.Collections.Generic;
using ER.Entities;

namespace ER.Interfaces
{
    public interface IBaseProductRepository
    {
        void Save();
        void Delete();
        void Update();
    }
}