using System.Collections.Generic;
using System;
using System.Linq;
using NHibernate;



namespace Application.Aplication.Invoice.Domain.Read.Repositories
{
      public class InvoiceReadRepository : IBaseReadInvoiceRepository
    {
            private readonly ISession _session;

        public InvoiceReadRepository(ISession _session)
        {
                  this._session = _session;
        }

    /*    public InvoiceModel GetById(Guid Id)
            {
                  var invoice = new InvoiceModel();
                  var list = _session.Query<InvoiceModel>().Where(x => x.Id == Id).ToList();

                  invoice = list.ElementAt(0);

                  return invoice;
            }*/

       /* public IEnumerable<InvoiceModel> GetAll()
        {
            var list = this._session.Query<InvoiceModel>().ToList();
            return list;
        }*/
    }
}