using System.Collections.Generic;
using Application.Home.Domain.Read.Model;

namespace Application.Home.Domain.Read.Repositories
{

      public interface IBaseReadHomeRepository
      {
            public IEnumerable<WaiterModel> GetAllWaiter();
      }

}