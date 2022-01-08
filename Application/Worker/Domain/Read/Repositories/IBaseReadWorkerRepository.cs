using System;
using System.Collections.Generic;
using Application.Worker.Domain.Read.Model;

namespace Application.Worker.Domain.Read.Repositories
{
      public interface IBaseReadWorkerRepository
      {
        public IEnumerable<WorkerFlatModel> GetAll();

        public WorkerModel GetById(Guid Id);

        public List<WorkerFlatModel> GetWorkersByFunctionWaiter();
      }
}