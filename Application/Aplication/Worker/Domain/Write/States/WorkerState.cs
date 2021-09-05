using Application.Aplication.Product.Domain.Write.Entities;

namespace Application.Aplication.Worker.Domain.Write.States
{

      public class WorkerState : BaseEntity
      {

            public int Function_Id { get; set; }
            public string Name { get; set; }
            public string Cpf { get; set; }
            public string Phone_Number { get; set; }
            public string Adress { get; set; }
            public string Email { get; set; }
      }

}