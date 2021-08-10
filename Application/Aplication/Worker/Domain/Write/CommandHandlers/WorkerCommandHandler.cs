using System;
using Application.Aplication.Worker.Domain.Write.Aggregates;
using Application.Aplication.Worker.Domain.Write.Commands;
using Application.Aplication.Worker.Domain.Write.Repositories;


namespace Application.Aplication.Worker.Domain.Write.CommandHandlers
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
                  throw new NotImplementedException();
            }

            public void Handle(Guid Id)
            {
                  throw new NotImplementedException();
            }
      }

}