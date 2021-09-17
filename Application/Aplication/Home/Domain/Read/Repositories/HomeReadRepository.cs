using System.Collections.Generic;
using System.Linq;
using Application.Aplication.Home.Domain.Read.Model;
using NHibernate;

namespace Application.Aplication.Home.Domain.Read.Repositories
{

      public class HomeReadRepository : IBaseReadHomeRepository
      {
            private readonly ISession _session;
            public HomeReadRepository(ISession _session)
            {

                  this._session = _session;

            }

            public IEnumerable<WaiterModel> GetAllWaiter()
            {
                  var list = _session.Query<WaiterModel>().ToList();
                  return list;
            }

    
    }
}