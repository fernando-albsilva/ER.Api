using System;
using ERapi.Aplication.Product.Domain.Read.Repositories;
using ERapi.Aplication.Product.Domain.Read.Model;
using ERapi.Aplication.Product.Domain.Write.Aggregates;
using ERapi.Aplication.Product.Domain.Write.Commands;
using ERapi.Aplication.Product.Domain.Write.Repositories;
using ERapi.Aplication.Product.Domain.Write.States;

namespace ERapi.Aplication.Product.Domain.Write.CommandHandlers
{
    public class ProductCommandHandler : IProductCommandHandler
    {
        private readonly IBaseReadProductRepository readRepository;
        private readonly IBaseWriteProductRepository writeRepository;

        public ProductCommandHandler(IBaseReadProductRepository readRepository, IBaseWriteProductRepository writeRepository)
        {
            this.readRepository = readRepository;
            this.writeRepository = writeRepository;
        }

        public void Handle(CreateProduct cmd)
        {
            cmd.Id = Guid.NewGuid();
            var aggregate = new ProductAggregate(cmd);
            writeRepository.Save(aggregate.State);
        }

        public void Handle(UpdateProduct cmd)
        {
            ProductModel productModel = readRepository.GetById(cmd.Id);
            ValidadeId(productModel);
            ProductState state = new ProductState
            {
                Id = productModel.Id,
                Name = productModel.Name,
                UnitValue = productModel.UnitValue,
                Cost = productModel.Cost
            };
            var aggregate = new ProductAggregate(state);
            aggregate.Change(cmd);
            writeRepository.Update(aggregate.State);
        }

        public void Handle(Guid Id)
        {
            ProductModel productModel = readRepository.GetById(Id);
            ValidadeId(productModel);
            ProductState state = new ProductState
            {
                Id = productModel.Id,
                Name = productModel.Name,
                UnitValue = productModel.UnitValue,
                Cost = productModel.Cost
            };
            writeRepository.Delete(state);
        }

        private void ValidadeId(ProductModel productModel)
        {

            if (productModel.Id == Guid.Empty)
            {
                throw new Exception("Não existe registro com esse Id.");
            }

        }
    }
}