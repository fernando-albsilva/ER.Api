using System;
using System.Collections.Generic;
using Aplication.Aplication.Auth.User.Read.Model;


namespace Application.Aplication.Function.Domain.Read.Repositories
{

      public interface IBaseReadUserRepository
      {

            public UserModel GetByUser(string userName, string Password);

            public IEnumerable<UserModel> GetAll();

      }

}