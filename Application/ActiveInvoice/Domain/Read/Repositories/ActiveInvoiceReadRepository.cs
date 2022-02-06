using Application.ActiveInvoice.Domain.Read.Model;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ActiveInvoice.Domain.Read.Repositories
{
    public class ActiveInvoiceReadRepository : IBaseReadActiveInvoiceRepository
    {
        private readonly ISession _session;

        public ActiveInvoiceReadRepository(ISession _session)
        {
            this._session = _session;
        }
        public ActiveInvoiceModel GetById(Guid Id)
        {
            var activeinvoice = new ActiveInvoiceModel();
            var list = _session.Query<ActiveInvoiceModel>().Where(x => x.Id == Id).ToList();

            activeinvoice = list.ElementAt(0);

            return activeinvoice;
        }

        public IList<ActiveInvoiceModel> GetAll()
        {
            
            return _session.Query<ActiveInvoiceModel>().ToList();

        }
    }
}
