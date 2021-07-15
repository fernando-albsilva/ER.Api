using System;
using ER.Commands;

namespace ER.Interfaces
{

    public interface IFunctionCommandHandler
    {

        public void Handle(CreateFunction cmd);

    }

}