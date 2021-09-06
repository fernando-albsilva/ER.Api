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
                        Worker_Id = cmd.Worker_Id,
                        Function = cmd.Function,
                        Name = cmd.Name,
                        Email = cmd.Email,
                        Cpf = cmd.Cpf,
                        Address = cmd.Address,
                        Phone_Number = cmd.Phone_Number
                  };

            }

            public void Change(UpdateWorker cmd)
            {
                validateWorkerCommand(cmd);
                State.Function = cmd.Function;
                State.Name = cmd.Name;
                State.Email = cmd.Email;
                State.Email = cmd.Cpf;
                State.Email = cmd.Address;
                State.Email = cmd.Phone_Number;

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
                  else if (string.IsNullOrEmpty(cmd.Phone_Number))
                  {
                        throw new Exception("Não existe Telefone do trabalhador.");
                  }

            }

      }

}