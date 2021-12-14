using Application.Function.Domain.Write.States;
using Application.Worker.Domain.Write.WorkerBaseState;

namespace Application.Worker.Domain.Write.Commands
{

      public class SaveWorkerCommand : WorkerBaseWriteState
    {

            public FunctionState Function{ get; set; }
            public string Name { get; set; }
            public string Cpf { get; set; }
            public string PhoneNumber { get; set; }
            public string Address { get; set; }
            public string Email { get; set; }

      }

      public class CreateWorker : SaveWorkerCommand
      {

      }

      public class UpdateWorker : SaveWorkerCommand
      {

      }

}