using System;
using System.Linq;
using Application.Worker.Domain.Write.States;
using NHibernate;

namespace Application.Worker.Domain.Write.Repositories
{

      public class WorkerWriteRepository : IBaseWriteWorkerRepository
      {

        private readonly ISession _session;

        public WorkerWriteRepository(ISession _session)
        {

            this._session = _session;
        }

        public WorkerState GetById(Guid Id)
        {
            var workerState = new WorkerState();
            var list = _session.Query<WorkerState>().Where(x => x.Id == Id).ToList();

            workerState = list.FirstOrDefault(x => x.Id != Guid.Empty);

            if (list.Count < 1)
            {
                workerState.Id = Guid.Empty;
            }

            return workerState;
        }

        public void Save(WorkerState state)
        {
            using (var tran = _session.BeginTransaction())
            {
                _session.Save(state);
                tran.Commit();
            }

        }

        public void Delete(WorkerState state)
        {
            using (var tran = _session.BeginTransaction())
            {
                _session.Delete(state);
                tran.Commit();
            }

        }

        public void Update(WorkerState state)
        {
            using (var tran = _session.BeginTransaction())
            {
                _session.Update(state);
                tran.Commit();
            }
        }

    }

}
