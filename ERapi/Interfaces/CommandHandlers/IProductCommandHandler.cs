using System;
using ER.Commands;

namespace ER.Interfaces
{
    public interface IProductCommandHandler 
    {
        public void Handle(CreateProduct cmd);

        public void Handle(UpdateProduct cmd);

        public void Handle(Guid Id);
    }
}