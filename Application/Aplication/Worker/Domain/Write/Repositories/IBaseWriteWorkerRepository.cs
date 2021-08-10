using System;
using Application.Aplication.Worker.Domain.Write.States;

namespace Application.Aplication.Worker.Domain.Write.Repositories
{

      public interface IBaseWriteWorkerRepository
      {

            public void Save(WorkerState state);

            public void Update(WorkerState state);

            public void Delete(Guid id);

      }

}