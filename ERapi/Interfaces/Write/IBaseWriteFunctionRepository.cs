using ER.States;

namespace ER.Interfaces 
{

    public interface IBaseWriteFunctionRepository
    {

        public void Save(FunctionState state);

    }

}