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

        public ActiveInvoiceState GetByTableNumber(int? number)
        {
            var activeInvoiceState = new ActiveInvoiceState();

            var list = _session.Query<ActiveInvoiceState>().Where(x => x.TableNumber == number).ToList();

            activeInvoiceState = list.ElementAt(0);

            if (list.Count < 1)
            {
                activeInvoiceState.Id = Guid.Empty;
            }

            return activeInvoiceState;
        }

        public void save(ActiveInvoiceState state)
        {
            using (var tran = _session.BeginTransaction())
            {
                _session.Save(state);
                tran.Commit();
            }
        } 
        
        public void save(ActiveInvoiceItemState state)
        {
            using (var tran = _session.BeginTransaction())
            {
                _session.Save(state);
                tran.Commit();
            }
        }

        public void Delete(ActiveInvoiceItemState state)
        {
            using (var tran = _session.BeginTransaction())
            {
                _session.Delete(state);
                tran.Commit();
            }
        }

        public void Delete(ActiveInvoiceState state)
        {
            using (var tran = _session.BeginTransaction())
            {
                _session.Delete(state);
                tran.Commit();
            }
        }

        public void Update(ActiveInvoiceState state)
        {
            using (var tran = _session.BeginTransaction())
            {
                _session.Update(state);
                tran.Commit();
            }
        }

        public ActiveInvoiceItemState GetActiveInvoiceItemById(Guid id)
        {
            var activeInvoiceItemState = new ActiveInvoiceItemState();
            var list = _session.Query<ActiveInvoiceItemState>().Where(x => x.Id == id).ToList();

            activeInvoiceItemState = list.ElementAt(0);

            if (list.Count < 1)
            {
                activeInvoiceItemState.Id = Guid.Empty;
            }

            return activeInvoiceItemState;
        }

        public ActiveInvoiceState GetActiveInvoiceById(Guid id)
        {
            var activeInvoiceItemState = new ActiveInvoiceState();
            var list = _session.Query<ActiveInvoiceState>().Where(x => x.Id == id).ToList();

            activeInvoiceItemState = list.ElementAt(0);

            if (list.Count < 1)
            {
                activeInvoiceItemState.Id = Guid.Empty;
            }

            return activeInvoiceItemState;
        }
    }
}
