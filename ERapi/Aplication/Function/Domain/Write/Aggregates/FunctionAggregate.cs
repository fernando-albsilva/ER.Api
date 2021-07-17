using ERapi.Aplication.Function.Domain.Write.Commands;
using ERapi.Aplication.Function.Domain.Write.States;
using System;

namespace ERapi.Aplication.Function.Domain.Write.Aggregates
{

    public class FunctionAggregate
    {

        public FunctionState State;

        public FunctionAggregate(CreateFunction cmd)
        {

            ValidateFunctionCommand(cmd);
            State = new FunctionState
            {

                Type = cmd.Type

            };

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