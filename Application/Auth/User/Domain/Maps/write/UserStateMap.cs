using Aplication.Auth.User.Domain.Write.States;
using FluentNHibernate.Mapping;

namespace Application.Auth.User.Domain.Maps.Write
{
      public class UserStateMap : ClassMap<UserState>
      {
            public UserStateMap()
            {

                  Table("[User]");

                  Id(x => x.Id);

                  Map(x => x.UserName);
                  Map(x => x.Password);
                  Map(x => x.Role);
            }
      }
}
