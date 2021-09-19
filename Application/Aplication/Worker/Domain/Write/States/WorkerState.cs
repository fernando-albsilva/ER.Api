using Application.Aplication.Function.Domain.Write.States;
using Application.Aplication.Worker.Domain.Write.WorkerBaseState;

namespace Application.Aplication.Worker.Domain.Write.States
{

      public class WorkerState : WorkerBaseWriteState
    {

            public virtual FunctionState Function{ get; set; }
            public virtual string Name { get; set; }
            public virtual string Cpf { get; set; }
            public virtual string PhoneNumber { get; set; }
            public virtual string Address { get; set; }
            public virtual string Email { get; set; }
      }

}