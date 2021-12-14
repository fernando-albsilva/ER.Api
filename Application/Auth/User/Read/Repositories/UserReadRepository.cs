using System;
using System.Collections.Generic;
using System.Linq;
using Aplication.Aplication.Auth.User.Read.Model;
using Application.Aplication.Function.Domain.Read.Repositories;
using NHibernate;

namespace Application.Aplication.Auth.User.Read.Repositories
{

      public class UserReadRepository : IBaseReadUserRepository
      {
            private readonly ISession _session;
            public UserReadRepository(ISession _session)
            {

                  this._session = _session;

            }

            public UserModel GetByUser(string userName, string Password)
            {
                  var user = new UserModel();
                  var list = _session.Query<UserModel>().Where(x => x.UserName == userName && x.Password == Password).ToList();

                  user = list.FirstOrDefault(x => x.Id != Guid.Empty);

                  return user;
            }

            public IEnumerable<UserModel> GetAll()
            {
                  var list = _session.Query<UserModel>().ToList();
                  return list;
            }
      }
}