using System;
using ERapi.Aplication.Product.Domain.Write.Commands;

namespace ERapi.Aplication.Product.Domain.Write.CommandHandlers
{
    public interface IProductCommandHandler
    {
        public void Handle(CreateProduct cmd);

        public void Handle(UpdateProduct cmd);

        public void Handle(DeleteProduct cmd);
    }
}