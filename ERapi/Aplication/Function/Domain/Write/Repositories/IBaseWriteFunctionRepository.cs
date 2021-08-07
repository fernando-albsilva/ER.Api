using ERapi.Aplication.Function.Domain.Write.States;

namespace ERapi.Aplication.Function.Domain.Write.Repositories
{

    public interface IBaseWriteFunctionRepository
    {

        public void Save(FunctionState state);

        public void Update(FunctionState state);

        public void Delete(FunctionState state);

    }

}