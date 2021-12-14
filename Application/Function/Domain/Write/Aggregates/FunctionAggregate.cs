using Application.Function.Domain.Write.Commands;
using Application.Function.Domain.Write.States;
using System;

namespace Application.Function.Domain.Write.Aggregates
{

      public class FunctionAggregate
      {

            public FunctionState State;

            public FunctionAggregate(FunctionState state)
            {
                  State = state;

            }

            public FunctionAggregate(CreateFunction cmd)
            {

                  ValidateFunctionCommand(cmd);
                  State = new FunctionState
                  {

                        Type = cmd.Type

                  };

            }

            public void Change(UpdateFunction cmd)
            {
                  ValidateFunctionCommand(cmd);
                  State.Id = cmd.Id;
                  State.Type = cmd.Type;
            }




            public void ValidateFunctionCommand(SaveFunctionCommand cmd)
            {
                  if (string.IsNullOrEmpty(cmd.Type))
                  {
                        throw new Exception("Nao existe tipo da funcao");
                  }
            }

      }



}