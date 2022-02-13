using Application.ActiveInvoice.Domain.Read.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ActiveInvoice.Domain.Read.Repositories
{
    public interface IBaseReadActiveInvoiceRepository
    {
        public ActiveInvoiceModel GetById(Guid Id);
        public IList<ActiveInvoiceModel> GetAll();
        public IList<ActiveTablesAndIndividualChecksModel> GetActiveTablesAndIndividualChecks();
    }
}
