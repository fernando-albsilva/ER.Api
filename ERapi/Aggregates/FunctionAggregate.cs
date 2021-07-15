using ER.Commands;
using ER.States;
using System;

namespace ER.Aggregates
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
            if(string.IsNullOrEmpty(cmd.Type))
            {
                throw new Exception("Nao existe tipo da funcao");
            }
        }

    }


}