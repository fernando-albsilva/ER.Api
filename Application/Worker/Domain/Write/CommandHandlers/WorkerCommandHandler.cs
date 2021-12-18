using System;
using System.Collections.Generic;
using Application.Worker.Domain.Write.Aggregates;
using Application.Worker.Domain.Write.Commands;
using Application.Worker.Domain.Write.Repositories;
using Application.Worker.Domain.Write.States;

namespace Application.Worker.Domain.Write.CommandHandlers
{

      public class WorkerCommandHandler : IWorkerCommandHandler
      {
            private readonly IBaseWriteWorkerRepository writeWorkerRepository;
            public WorkerCommandHandler(IBaseWriteWorkerRepository writeWorkerRepository)
            {
                  this.writeWorkerRepository = writeWorkerRepository;
            }
            
            public void Handle(CreateWorker cmd)
            {
                  cmd.Id = Guid.NewGuid();
                  var aggregate = new WorkerAggregate(cmd);
                  writeWorkerRepository.Save(aggregate.State);
            }

            public void Handle(UpdateWorker cmd)
            {
                WorkerState workerState = writeWorkerRepository.GetById(cmd.Id);
                var aggregate = new WorkerAggregate(workerState);
                aggregate.Change(cmd);
                writeWorkerRepository.Update(aggregate.State);
            }

            public void Handle(Guid Id)
            {
                WorkerState workerState = writeWorkerRepository.GetById(Id);
                writeWorkerRepository.Delete(workerState);
            }

            public void Handle(List<Guid> idList)
            {
                foreach (Guid element in idList)
                {
                    WorkerState workerState = writeWorkerRepository.GetById(element);
                    writeWorkerRepository.Delete(workerState);
                }
            }
      }

}