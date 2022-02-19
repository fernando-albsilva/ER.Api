using Application.Invoice.Domain.Write.States;
using FluentNHibernate.Mapping;
using System.Collections.Generic;

namespace Application.Invoice.Domain.Maps.Write
{
    public class InvoiceStateMap : ClassMap<InvoiceState>
    {
        public InvoiceStateMap()
        {
            Table("Invoice");

            Id(x => x.Id, "Id");

            Map(x => x.Date, "Date");
            Map(x => x.ClientName, "ClientName");
            //Map(x => x.Duration, "Duration");

            References(x => x.Worker).Column("WorkerId");
            References(x => x.User).Column("UserId");

            HasMany(x => x.InvoiceItemsState)
                .KeyColumn("InvoiceId")
                .Cascade
                .AllDeleteOrphan()
                .Inverse();



        }
    }
}
