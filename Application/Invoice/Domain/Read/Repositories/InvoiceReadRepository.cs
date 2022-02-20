using System.Collections.Generic;
using System;
using System.Linq;
using NHibernate;
using Application.Invoice.Domain.Read.Model;

namespace Application.Invoice.Domain.Read.Repositories
{
      public class InvoiceReadRepository : IBaseReadInvoiceRepository
      {
            private readonly ISession _session;

            public InvoiceReadRepository(ISession _session)
            {
                      this._session = _session;
            }

        public IList<InvoiceFlatModel> GetAllInvoices()
        {
            return _session.Query<InvoiceFlatModel>().ToList();
        }

        public InvoiceModel GetById(Guid id)
        {
            var invoiceModel = new InvoiceModel();
            var list = _session.Query<InvoiceModel>().Where(x => x.Id == id).ToList();

            invoiceModel = list.ElementAt(0);

            if (list.Count < 1)
            {
                invoiceModel.Id = Guid.Empty;
            }

            return invoiceModel;
        }
    }
}