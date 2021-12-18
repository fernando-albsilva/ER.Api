using Aplication.Auth.User.Domain.Write.States;
using System;

namespace Application.Auth.User.Domain.Write.Repositories
{
    public interface IBaseWriteUserRepository
    {
        public void Delete(UserState state);
        public UserState GetById(Guid Id);
        public void Save(UserState state);
        public void Update(UserState state);
    }
}
