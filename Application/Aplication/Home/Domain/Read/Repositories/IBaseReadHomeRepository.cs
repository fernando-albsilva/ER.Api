using System.Collections.Generic;
using Application.Aplication.Home.Domain.Read.Model;

namespace Application.Aplication.Home.Domain.Read.Repositories
{

      public interface IBaseReadHomeRepository
      {
            public IEnumerable<WaiterModel> GetAllWaiter();
      }

}