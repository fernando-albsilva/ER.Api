using System;
using ERapi.Aplication.Product.Domain.Write.Commands;

namespace ER.Interfaces
{
    public interface IProductCommandHandler 
    {
        public void Handle(CreateProduct cmd);

        public void Handle(UpdateProduct cmd);

        public void Handle(Guid Id);
    }
}