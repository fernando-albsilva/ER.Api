using Aplication.Auth.User.Domain.Write.Commands;
using Aplication.Auth.User.Domain.Write.States;
using Application.Auth.User.Domain.Write.Aggregates;
using Application.Auth.User.Domain.Write.Repositories;
using Application.Worker.Domain.Write.Commands;
using System;
using System.Collections.Generic;


namespace Application.Auth.User.Domain.Write.CommandHandlers
{
    public class UserCommandHandler : IUserCommandHandler
    {
        private readonly IBaseWriteUserRepository writeUserRepository;
        public UserCommandHandler(IBaseWriteUserRepository writeUserRepository)
        {
            this.writeUserRepository = writeUserRepository;
        }

        public void Handle(CreateUser cmd)
        {
            cmd.Id = Guid.NewGuid();
            var aggregate = new UserAggregate(cmd);
            writeUserRepository.Save(aggregate.State);
        }

        public void Handle(UpdateUser cmd)
        {
            UserState userState = writeUserRepository.GetById(cmd.Id);
            var aggregate = new UserAggregate(userState);
            aggregate.Change(cmd);
            writeUserRepository.Update(aggregate.State);
        }

        public void Handle(Guid Id)
        {
            UserState userState = writeUserRepository.GetById(Id);
            writeUserRepository.Delete(userState);
        }

        public void Handle(List<Guid> idList)
        {
            foreach (Guid element in idList)
            {
                UserState userState = writeUserRepository.GetById(element);
                writeUserRepository.Delete(userState);
            }
        }
    }
}
