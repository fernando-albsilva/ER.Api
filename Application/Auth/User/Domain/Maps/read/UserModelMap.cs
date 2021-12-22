using Aplication.Auth.User.Domain.Read.Model;
using FluentNHibernate.Mapping;

namespace Application.Auth.User.Domain.Maps.Read
{
      public class UserModelMap : ClassMap<UserModel>
      {
            public UserModelMap()
            {
                  ReadOnly();

                  Table("[User]");

                  Id(x => x.Id);

                  Map(x => x.UserName);
                  Map(x => x.Password);
                  Map(x => x.Role);


            }
      }
}
