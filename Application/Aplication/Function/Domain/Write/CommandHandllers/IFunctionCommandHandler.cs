using Application.Aplication.Function.Domain.Write.Commands;
using System.Collections.Generic;

namespace Application.Aplication.Function.Domain.Write.CommandHandllers
{

      public interface IFunctionCommandHandler
      {

            public void Handle(CreateFunction cmd);


            public void Handle(UpdateFunction cmd);


            public void Handle(int id);

            public void Handle(List<int> idList);
    }

}