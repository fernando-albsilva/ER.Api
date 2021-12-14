using System;
using System.Collections.Generic;
using System.Linq;
using Application.Function.Domain.Read.Model;
using NHibernate;

namespace Application.Function.Domain.Read.Repositories
{

      public class FunctionReadRepository : IBaseReadFunctionRepository
      {
            private readonly ISession _session;
            public FunctionReadRepository(ISession _session)
            {

                  this._session = _session;

            }

            public FunctionModel GetById(int id)
            {
                  var function = new FunctionModel();
                  var list = _session.Query<FunctionModel>().Where(x => x.Id == id).ToList();

                  function = list.ElementAt(0);

                  return function;
            }

            public IEnumerable<FunctionModel> GetAll()
            {
                  var list = _session.Query<FunctionModel>().ToList();
                  return list;
            }
      }
}