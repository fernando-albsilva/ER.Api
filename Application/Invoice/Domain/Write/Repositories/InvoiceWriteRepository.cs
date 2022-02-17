using Application.Invoice.Domain.Write.States;
using NHibernate;
using System;
using System.Linq;

namespace Application.Invoice.Domain.Write.Repositories
{
      public class InvoiceWriteRepository : IBaseWriteInvoiceRepository
      {
            private readonly ISession _session;
            public InvoiceWriteRepository(ISession _session)
            {

                  this._session = _session;
            }

            public void Save(InvoiceState state)
            {
                using (var tran = _session.BeginTransaction())
                {
                    _session.Save(state);
                    tran.Commit();
                }

            }
/*
            public void Delete(ProductState state)
            {
                  using (var tran = _session.BeginTransaction())
                  {
                        _session.Delete(state);
                        tran.Commit();
                  }

            }*/
/*
            public void Update(ProductState state)
            {
                  using (var tran = _session.BeginTransaction())
                  {
                        _session.Update(state);
                        tran.Commit();
                  }
            }*/



    }
}