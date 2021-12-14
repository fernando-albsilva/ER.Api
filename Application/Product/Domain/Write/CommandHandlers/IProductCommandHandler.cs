using System;
using System.Collections.Generic;
using Application.Product.Domain.Write.Commands;

namespace Application.Product.Domain.Write.CommandHandlers
{
      public interface IProductCommandHandler
      {
            public void Handle(CreateProduct cmd);

            public void Handle(UpdateProduct cmd);

            public void Handle(Guid Id);

            public void Handle(List<Guid> cmd);
      }
}