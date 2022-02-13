using Application.Worker.Domain.Read.WorkerBaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Worker.Domain.Read.Model
{
    public class WorkerActiveInvoiceModel : WorkerBaseReadModel
    {
        public virtual string Name { get; set; }
    }
}
