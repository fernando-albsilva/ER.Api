using Application.Function.Domain.Write.States;
using Application.Invoice.Domain.Write.States;
using Application.Worker.Domain.Write.WorkerBaseState;
using System.Collections.Generic;

namespace Application.Worker.Domain.Write.States
{

      public class WorkerState : WorkerBaseWriteState
    {

            public virtual FunctionState Function{ get; set; }
            public virtual IList<InvoiceState> InvoiceState { get; set; }
            public virtual string Name { get; set; }
            public virtual string Cpf { get; set; }
            public virtual string PhoneNumber { get; set; }
            public virtual string Address { get; set; }
            public virtual string Email { get; set; }
      }

}