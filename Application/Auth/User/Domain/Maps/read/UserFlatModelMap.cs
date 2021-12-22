using Aplication.Auth.User.Domain.Read.Model;
using Application.Auth.User.Domain.Read.Model;
using FluentNHibernate.Mapping;

namespace Application.Auth.User.Domain.Maps.read
{
    class UserFlatModelMap : ClassMap<UserFlatModel>
    {
        public UserFlatModelMap()
        {
            ReadOnly();

            Table("[User]");

            Id(x => x.Id);

            Map(x => x.UserName);
            Map(x => x.Role);


        }
    }
}