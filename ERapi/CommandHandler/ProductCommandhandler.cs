using System;
using ER.Interfaces;
using ER.Commands;
using ER.Aggregates;
using ER.Repositories;
using ER.States;
using ER.Models;

namespace ER.CommandHandler
{
    public class ProductCommandHandler : IProductCommandHandler
    {
        private readonly IBaseReadProductRepository readRepository;
        private readonly IBaseWriteProductRepository writeRepository;
        
        public ProductCommandHandler(IBaseReadProductRepository readRepository,IBaseWriteProductRepository writeRepository)
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
            this.ValidadeId(productModel);
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
            this.ValidadeId(productModel);
            writeRepository.Delete(productModel.Id);
        }

        private void ValidadeId(ProductModel productModel){

            if (productModel.Id == Guid.Empty)
            {
                throw new Exception("Não existe registro com esse Id.");
            }
        
        }
    }
}