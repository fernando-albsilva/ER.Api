using System.Collections.Generic;
using System;
using System.Linq;
using NHibernate;



namespace Application.Invoice.Domain.Read.Repositories
{
      public class InvoiceReadRepository : IBaseReadInvoiceRepository
      {
            private readonly ISession _session;

            public InvoiceReadRepository(ISession _session)
            {
                      this._session = _session;
            }

      }
}