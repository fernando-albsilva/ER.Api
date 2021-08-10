using System;
using Application.Aplication.Product.Domain.Write.Commands;

namespace Application.Aplication.Product.Domain.Write.CommandHandlers
{
      public interface IProductCommandHandler
      {
            public void Handle(CreateProduct cmd);

            public void Handle(UpdateProduct cmd);

            public void Handle(DeleteProduct cmd);
      }
}