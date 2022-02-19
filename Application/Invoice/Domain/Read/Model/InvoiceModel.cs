using Aplication.Auth.User.Domain.Read.Model;
using Application.Worker.Domain.Read.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Invoice.Domain.Read.Model
{
    public class InvoiceModel
    {
        public virtual Guid? Id { get; set; }
        public virtual WorkerModel Worker { get; set; }
        public virtual UserModel User { get; set; }
        public virtual DateTime? Date { get; set; }
        public virtual string ClientName { get; set; }
        public virtual DateTime Duration { get; set; }
        public virtual IList<InvoiceItemModel>? InvoiceItems { get; set; }
    }
}
