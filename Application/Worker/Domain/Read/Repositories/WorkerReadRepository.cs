using System.Collections.Generic;
using System;
using System.Linq;
using NHibernate;
using Application.Worker.Domain.Read.Model;


namespace Application.Worker.Domain.Read.Repositories
{
        public class WorkerReadRepository : IBaseReadWorkerRepository
        {
            private readonly ISession _session;
        
            public WorkerReadRepository(ISession _session)
            {
                      this._session = _session;
            }

            public IEnumerable<WorkerFlatModel> GetAll()
            {
                var list = this._session.Query<WorkerFlatModel>().ToList();
                return list;
            }

            public WorkerModel GetById(Guid Id)
            {
                var worker = new WorkerModel();
                var list = _session.Query<WorkerModel>().Where(x => x.Id == Id).ToList();

                worker = list.FirstOrDefault(x => x.Id != Guid.Empty);

                return worker;
            }

            public List<WorkerFlatModel> GetWorkersByFunctionWaiter()
            {
                return _session.Query<WorkerFlatModel>().Where(x => x.Type == "Gar?om").Select(x => new WorkerFlatModel { Name = x.Name, Id = x.Id, Type = x.Type }).ToList();
            }
    }
}