using System;
using ERapi.Aplication.Function.Domain.Write.Commands;

namespace ERapi.Aplication.Function.Domain.Write.CommandHandllers
{

    public interface IFunctionCommandHandler
    {

        public void Handle(CreateFunction cmd);

    }

}