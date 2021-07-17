using System.Collections.Generic;
using ERapi.Aplication.Function.Domain.Read.Model;

namespace ERapi.Aplication.Function.Domain.Read.Repositories
{

    public interface IBaseReadFunctionRepository
    {

        public FunctionModel GetById(int id);

        public IEnumerable<FunctionModel> GetAll();

    }

}