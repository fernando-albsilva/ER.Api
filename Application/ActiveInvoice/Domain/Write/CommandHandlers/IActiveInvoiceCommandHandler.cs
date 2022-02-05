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
        public void handle(CreateActiveInvoiceCommand cmd);
        public void handle(ChangeActiveInvoiceCommand cmd);
        public void handle(Guid id);
    }
}
