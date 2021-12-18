using Aplication.Auth.User.Domain.Write.Commands;
using System;
using System.Collections.Generic;


namespace Application.Auth.User.Domain.Write.CommandHandlers
{
    public interface IUserCommandHandler
    {
        public void Handle(UpdateUser cmd);
        public void Handle(CreateUser cmd);
        public void Handle(Guid Id);
        public void Handle(List<Guid> idList);
    }
}
