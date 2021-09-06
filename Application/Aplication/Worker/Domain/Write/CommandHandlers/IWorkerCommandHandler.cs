using System;
using System.Collections.Generic;
using Application.Aplication.Worker.Domain.Write.Commands;

namespace Application.Aplication.Worker.Domain.Write.CommandHandlers
{

      public interface IWorkerCommandHandler
      {

        public void Handle(UpdateWorker cmd);
        public void Handle(CreateWorker cmd);
        public void Handle(Guid Id);
        public void Handle(List<Guid> idList);

      }

}