using Aplication.Auth.User.Domain.Read.Model;
using Application.Auth.User.Domain.Read.Model;
using System.Collections.Generic;


namespace Application.Auth.Domain.Read.Repositories
{

      public interface IBaseReadUserRepository
      {

            public UserModel GetByUser(string userName);

            public IEnumerable<UserFlatModel> GetAll();

      }

}