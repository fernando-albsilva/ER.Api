using System;
using Application.Aplication.Invoice.Domain.Read.Repositories;
using Application.Aplication.Invoice.Domain.Write.Commands;
using Application.Aplication.Invoice.Domain.Write.Repositories;
using Application.Aplication.Invoice.Domain.Write.States;
using Application.Aplication.Invoice.Domain.Write.Aggregates;
using System.Collections.Generic;

namespace Application.Aplication.Invoice.Domain.Write.CommandHandlers
{
      public class InvoiceCommandhandler : IInvoiceCommandHandler
      {
            private readonly IBaseReadInvoiceRepository readRepository;
            private readonly IBaseWriteInvoiceRepository writeRepository;

            public InvoiceCommandhandler(IBaseReadInvoiceRepository readRepository, IBaseWriteInvoiceRepository writeRepository)
            {
                  this.readRepository = readRepository;
                  this.writeRepository = writeRepository;
            }

        /*    public void Handle(CreateInvoice cmd)
            {
                  cmd.Id = Guid.NewGuid();
                  var aggregate = new InvoiceAggregate(cmd);
                  writeRepository.Save(aggregate.State);
            }*/

            public void Handle(CreateInvoice cmd)
            {
                throw new NotImplementedException();
            }

     

        /*    public void Handle(UpdateProduct cmd)
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

                }*/
    }
}