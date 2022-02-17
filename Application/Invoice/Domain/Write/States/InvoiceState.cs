

using Aplication.Auth.User.Domain.Read.Model;
using Aplication.Auth.User.Domain.Write.States;
using Application.Worker.Domain.Read.Model;
using Application.Worker.Domain.Write.States;
using System;
using System.Collections.Generic;

namespace Application.Invoice.Domain.Write.States
{
    public class InvoiceState
    {
        public virtual Guid? Id { get; set; }
        public virtual WorkerModel Worker{ get; set; }
        public virtual UserModel User { get; set; }
        public virtual DateTime? Date { get; set; }
        public virtual string ClientName { get; set; }
        public virtual IList<InvoiceItemState> InvoiceItemsState { get; set; }
    }
}