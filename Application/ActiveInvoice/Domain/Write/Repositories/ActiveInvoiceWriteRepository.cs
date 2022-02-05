using Application.ActiveInvoice.Domain.Write.States;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ActiveInvoice.Domain.Write.Repositories
{
    public class ActiveInvoiceWriteRepository : IBaseWriteActiveInvoiceRepository
    {
        private readonly ISession _session;

        public ActiveInvoiceWriteRepository(ISession _session)
        {  
            this._session = _session;
        }

        public void save(ActiveInvoiceState state)
        {
            using (var tran = _session.BeginTransaction())
            {
                _session.Save(state);
                tran.Commit();
            }
        }
    }
}
