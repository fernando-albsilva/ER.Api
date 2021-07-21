using System;
using ERapi.Aplication.Worker.Domain.Write.States;
using ERapi.Aplication.Worker.Domain.Commands;

namespace ERapi.Aplication.Worker.Domain.Write.Repositories
{

    public interface IBaseWriteWorkerRepository
    {

        public void Save(WorkerState state);

        public void Update(WorkerState state);

        public void Delete(Guid id);

    }

}