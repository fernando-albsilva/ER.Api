using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Invoice.Domain.Read.Model
{
    public class InvoiceFlatModel
    {
        public virtual Guid Id { get; set; }
        public virtual string ClientName { get; set; }
        public virtual DateTime Date { get; set; }
        public virtual string? Duration { get; set; }
        public virtual string WorkerName { get; set; }
        public virtual double TotalValue { get; set; }
    }
}
