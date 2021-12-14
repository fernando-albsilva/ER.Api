using System;
using Application.Worker.Domain.Write.States;

namespace Application.Worker.Domain.Write.Repositories
{

      public interface IBaseWriteWorkerRepository
      {

        public void Delete(WorkerState state);
        public WorkerState GetById(Guid Id);
        public void Save(WorkerState state);
        public void Update(WorkerState state);

      }

}