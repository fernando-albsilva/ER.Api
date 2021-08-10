using System.Collections.Generic;
using Application.Aplication.Function.Domain.Read.Model;

namespace Application.Aplication.Function.Domain.Read.Repositories
{

      public interface IBaseReadFunctionRepository
      {

            public FunctionModel GetById(int id);

            public IEnumerable<FunctionModel> GetAll();

      }

}