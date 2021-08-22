using System;
using Application.Aplication.Product.Domain.Read.Model;
using Application.Aplication.Product.Domain.Read.Repositories;
using Application.Aplication.Product.Domain.Write.Commands;
using Application.Aplication.Product.Domain.Write.Repositories;
using Application.Aplication.Product.Domain.Write.States;
using Application.Aplication.Product.Domain.Write.Aggregates;
using System.Collections.Generic;

namespace Application.Aplication.Product.Domain.Write.CommandHandlers
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
                  ProductState productState = writeRepository.GetById(cmd.Id);
                  ValidadeId(productState);
                  var aggregate = new ProductAggregate(productState);
                  aggregate.Change(cmd);
                  writeRepository.Update(aggregate.State);
            }

            public void Handle(Guid Id)
            {
                  ProductState productState = writeRepository.GetById(Id);
                  ValidadeId(productState);
                  writeRepository.Delete(productState);
            }

            public void Handle(List<Guid> idList)
            {
                 foreach (Guid element in idList)
                 {
                    ProductState productState = writeRepository.GetById(element);
                    ValidadeId(productState);
                    writeRepository.Delete(productState);
                 }
            }

            private void ValidadeId(ProductState productState)
                {

                      if (productState.Id == Guid.Empty)
                      {
                            throw new Exception("Não existe registro com esse Id.");
                      }

                }
      }
}