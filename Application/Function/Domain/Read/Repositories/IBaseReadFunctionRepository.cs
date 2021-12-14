using System.Collections.Generic;
using Application.Function.Domain.Read.Model;

namespace Application.Function.Domain.Read.Repositories
{

      public interface IBaseReadFunctionRepository
      {

            public FunctionModel GetById(int id);

            public IEnumerable<FunctionModel> GetAll();

      }

}