using Application.Function.Domain.Write.States;
using NHibernate;
using System.Linq;

namespace Application.Function.Domain.Write.Repositories
{

      public class FunctionWriteRepository : IBaseWriteFunctionRepository
      {
            private readonly ISession _session;
            public FunctionWriteRepository(ISession _session)
            {
                  this._session = _session;
            }

            public void Save(FunctionState state)
            {
                  using (var tran = _session.BeginTransaction())
                  {
                        _session.Save(state);
                        tran.Commit();
                  }

            }

            public void Delete(FunctionState state)
            {
                  using (var tran = _session.BeginTransaction())
                  {
                        _session.Delete(state);
                        tran.Commit();
                  }

            }

            public void Update(FunctionState state)
            {
                  using (var tran = _session.BeginTransaction())
                  {
                        _session.Update(state);
                        tran.Commit();
                  }
            }

            public FunctionState GetById(int Id)
            {
                var functionState = new FunctionState();
                var list = _session.Query<FunctionState>().Where(x => x.Id == Id).ToList();

                functionState = list.ElementAt(0);

                if (list.Count < 1)
                {
                    functionState.Id = 0;
                }

                return functionState;
            }

    }

}