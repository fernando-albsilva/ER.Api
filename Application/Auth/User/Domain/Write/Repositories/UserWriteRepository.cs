using Aplication.Auth.User.Domain.Write.States;
using NHibernate;
using System;
using System.Linq;


namespace Application.Auth.User.Domain.Write.Repositories
{
    public class UserWriteRepository : IBaseWriteUserRepository
    {
        private readonly ISession _session;

        public UserWriteRepository(ISession _session)
        {

            this._session = _session;
        }

        public UserState GetById(Guid Id)
        {
            var workerState = new UserState();
            var list = _session.Query<UserState>().Where(x => x.Id == Id).ToList();

            workerState = list.FirstOrDefault(x => x.Id != Guid.Empty);

            if (list.Count < 1)
            {
                workerState.Id = Guid.Empty;
            }

            return workerState;
        }

        public void Save(UserState state)
        {
            using (var tran = _session.BeginTransaction())
            {
                _session.Save(state);
                tran.Commit();
            }

        }

        public void Delete(UserState state)
        {
            using (var tran = _session.BeginTransaction())
            {
                _session.Delete(state);
                tran.Commit();
            }

        }

        public void Update(UserState state)
        {
            using (var tran = _session.BeginTransaction())
            {
                _session.Update(state);
                tran.Commit();
            }
        }
    }
}
