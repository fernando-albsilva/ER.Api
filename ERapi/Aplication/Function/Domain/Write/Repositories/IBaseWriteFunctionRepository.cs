using ERapi.Aplication.Function.Domain.Write.States;

namespace ERapi.Aplication.Function.Domain.Write.Repositories
{

    public interface IBaseWriteFunctionRepository
    {

        public void Save(FunctionState state);

    }

}