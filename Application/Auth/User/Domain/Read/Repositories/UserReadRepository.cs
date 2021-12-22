using System;
using System.Collections.Generic;
using System.Linq;
using Aplication.Auth.User.Domain.Read.Model;
using Application.Auth.Domain.Read.Repositories;
using Application.Auth.User.Domain.Read.Model;
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
            UserModel IBaseReadUserRepository.GetByUser(string userName)
            {
                var user = new UserModel();
                var list = _session.Query<UserModel>().Where(x => x.UserName == userName).ToList();

                user = list.FirstOrDefault(x => x.Id != Guid.Empty);

                return user;
            }

            public IEnumerable<UserFlatModel> GetAll()
            {
                var list = _session.Query<UserFlatModel>().ToList();
                return list;
             }
    }
}