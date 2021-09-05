using System;
using Application.Aplication.Worker.Domain.Write.States;

namespace Application.Aplication.Worker.Domain.Write.Repositories
{

      public interface IBaseWriteWorkerRepository
      {

            public void Delete(WorkerState state);

        public WorkerState GetById(Guid Id);

      }

}