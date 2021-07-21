using System;
using ERapi.Aplication.Worker.Domain.Commands;

namespace ERapi.Aplication.Worker.Domain.Write.CommandHandlers
{

    public interface IWorkerCommandHandler
    {

        public void Handle(CreateWorker cmd);

        public void Handle(UpdateWorker cmd);

        public void Handle(Guid Id);

    }

}