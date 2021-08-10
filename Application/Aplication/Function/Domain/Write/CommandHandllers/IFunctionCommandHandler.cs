using Application.Aplication.Function.Domain.Write.Commands;

namespace Application.Aplication.Function.Domain.Write.CommandHandllers
{

      public interface IFunctionCommandHandler
      {

            public void Handle(CreateFunction cmd);


            public void Handle(UpdateFunction cmd);


            public void Handle(int id);
      }

}