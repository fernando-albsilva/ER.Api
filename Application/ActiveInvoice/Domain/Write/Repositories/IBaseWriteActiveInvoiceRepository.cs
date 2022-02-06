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
        public ActiveInvoiceState GetByTableNumber(int? number);
        public void save(ActiveInvoiceState state);
        public void save(ActiveInvoiceItemState state);
        public void Update(ActiveInvoiceState state);
    }
}
