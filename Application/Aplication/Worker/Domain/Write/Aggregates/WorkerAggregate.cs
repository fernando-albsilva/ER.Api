using System;
using Application.Aplication.Worker.Domain.Write.Commands;
using Application.Aplication.Worker.Domain.Write.States;

namespace Application.Aplication.Worker.Domain.Write.Aggregates
{
      public class WorkerAggregate
      {


            public WorkerState State;


            public WorkerAggregate(WorkerState state)
            {

                  State = state;

            }

            public WorkerAggregate(CreateWorker cmd)
            {

                  validateWorkerCommand(cmd);
                  State = new WorkerState
                  {
                        Id = cmd.Id,
                        Function_Id = cmd.FunctionIdFk,
                        Name = cmd.Name,
                        Email = cmd.Email,
                        Cpf = cmd.Cpf,
                        Adress = cmd.Address,
                        Phone_Number = cmd.PhoneNumber
                  };

            }





            private void validateWorkerCommand(SaveWorkerCommand cmd)
            {



                  if (string.IsNullOrEmpty(cmd.Name))
                  {
                        throw new Exception("Não existe nome do produto.");
                  }
                  else if (string.IsNullOrEmpty(cmd.Cpf))
                  {
                        throw new Exception("Não existe CPF do trabalhador.");
                  }
                  else if (string.IsNullOrEmpty(cmd.Email))
                  {
                        throw new Exception("Não existe Email do trabalhador.");
                  }
                  else if (string.IsNullOrEmpty(cmd.Address))
                  {
                        throw new Exception("Não existe Endereço do trabalhador.");
                  }
                  else if (string.IsNullOrEmpty(cmd.PhoneNumber))
                  {
                        throw new Exception("Não existe Telefone do trabalhador.");
                  }

            }

      }

}