using Application.ActiveInvoice.Domain.Read.Model;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ActiveInvoice.Domain.Maps.Read
{
    public class ActiveInvoiceModelMap : ClassMap<ActiveInvoiceModel>
    {
        public ActiveInvoiceModelMap()
        {
            ReadOnly();

            Table("ActiveInvoice");

            Id(x => x.Id);
            Map(x => x.UserId);
            Map(x => x.Date);
            Map(x => x.ClientName);
            Map(x => x.TableNumber);
            Map(x => x.StartTime);

            References(x => x.Worker,"WorkerId");

            HasMany(x => x.ActiveInvoiceItems).KeyColumn("ActiveInvoiceId");
        }
    }
}
