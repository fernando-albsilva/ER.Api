
using Aplication.Aplication.Auth.User.Read.Model;
using FluentNHibernate.Mapping;

namespace Application.Aplication.Auth.User.Read.Maps
{
      public class UserMap : ClassMap<UserModel>
      {
            public UserMap()
            {
                  ReadOnly();

                  Table("[Users]");

                  Id(x => x.Id);

                  Map(x => x.UserName);
                  Map(x => x.Password);
                  Map(x => x.Role);


            }
      }
}
