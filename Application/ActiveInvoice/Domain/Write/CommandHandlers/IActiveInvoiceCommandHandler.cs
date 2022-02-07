using Application.ActiveInvoice.Domain.Write.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ActiveInvoice.Domain.Write.CommandHandlers
{
    public interface IActiveInvoiceCommandHandler
    {
        public void Handle(CreateActiveInvoiceCommand cmd);
        public void Handle(UpdateActiveInvoiceCommand cmd);
        public void Handle(CreateActiveInvoiceItemCommand cmd);
        public void RemoveActiveInvoiceItem(Guid id);
    }
}
