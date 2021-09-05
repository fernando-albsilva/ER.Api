using System;
using System.Collections.Generic;
using Application.Aplication.Worker.Domain.Read.Model;

namespace Application.Aplication.Worker.Domain.Read.Repositories
{
      public interface IBaseReadWorkerRepository
      {
        public IEnumerable<WorkerModel> GetAll();

        public WorkerModel GetById(Guid Id);
      }
}