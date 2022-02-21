using Application.Auth.User.Domain.Read.Model;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Auth.User.Domain.Maps.read
{
    public class UserInvoiceModelMap : ClassMap<UserInvoiceModel>
    {
        public UserInvoiceModelMap()
        {
            ReadOnly();

            Table("[User]");

            Id(x => x.Id);
            Map(x => x.Name,"UserName");
        }   
    }
}
