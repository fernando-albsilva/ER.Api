using Application.Aplication.Product.Domain.Write.Entities;

namespace Application.Aplication.Worker.Domain.Write.Commands
{

      public class SaveWorkerCommand : BaseEntity
      {

            public int FunctionIdFk { get; set; }
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