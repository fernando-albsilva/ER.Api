using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Worker.Domain.Read.Model
{
    public class WorkerInvoiceModel
    {
        public virtual Guid Id { get; set; }
        public virtual string Name { get; set; }
    }
}
