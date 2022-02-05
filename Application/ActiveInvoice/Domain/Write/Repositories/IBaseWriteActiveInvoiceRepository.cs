using Application.ActiveInvoice.Domain.Write.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ActiveInvoice.Domain.Write.Repositories
{
    public interface IBaseWriteActiveInvoiceRepository
    {
        public void save(ActiveInvoiceState state);
    }
}
