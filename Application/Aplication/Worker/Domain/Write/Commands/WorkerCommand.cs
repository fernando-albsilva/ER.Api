using Application.Aplication.Function.Domain.Write.States;
using Application.Aplication.Product.Domain.Write.Entities;

namespace Application.Aplication.Worker.Domain.Write.Commands
{

      public class SaveWorkerCommand : BaseEntity
      {

            public FunctionState Function{ get; set; }
            public string Name { get; set; }
            public string Cpf { get; set; }
            public string Phone_Number { get; set; }
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