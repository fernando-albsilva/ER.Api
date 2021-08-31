using Application.Aplication.Function.Domain.Write.States;

namespace Application.Aplication.Function.Domain.Write.Repositories
{

      public interface IBaseWriteFunctionRepository
      {

            public void Save(FunctionState state);

            public void Update(FunctionState state);

            public void Delete(FunctionState state);

             public FunctionState GetById(int Id);

      }

}