using System.Collections.Generic;
using System;
using System.Linq;
using NHibernate;
using Application.Aplication.Worker.Domain.Read.Model;


namespace Application.Aplication.Worker.Domain.Read.Repositories
{
        public class WorkerReadRepository : IBaseReadWorkerRepository
        {
            private readonly ISession _session;
        
            public WorkerReadRepository(ISession _session)
            {
                      this._session = _session;
            }

            public IEnumerable<WorkerModel> GetAll()
            {
                var list = this._session.Query<WorkerModel>().ToList();
                return list;
            }

        }
}