using System;
using System.Collections.Generic;
using System.Linq;
using Aplication.Auth.User.Domain.Read.Model;
using Application.Auth.Domain.Read.Repositories;
using NHibernate;

namespace Application.Auth.User.Read.Repositories
{

      public class UserReadRepository : IBaseReadUserRepository
      {
            private readonly ISession _session;
            public UserReadRepository(ISession _session)
            {
                  this._session = _session;
            }
            UserModel IBaseReadUserRepository.GetByUser(string userName, string Password)
            {
                var user = new UserModel();
                var list = _session.Query<UserModel>().Where(x => x.UserName == userName && x.Password == Password).ToList();

                user = list.FirstOrDefault(x => x.Id != Guid.Empty);

                return user;
            }

            IEnumerable<UserModel> IBaseReadUserRepository.GetAll()
            {
                var list = _session.Query<UserModel>().ToList();
                return list;
            }
    }
}