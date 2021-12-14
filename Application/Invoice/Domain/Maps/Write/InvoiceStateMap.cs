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

            References(x => x.WorkerState).Column("WorkerId");
            Map(x => x.Date, "Date");
            Map(x => x.ClientName, "ClientName");
            HasMany(x => x.InvoiceItemsState).KeyColumn("InvoiceId");

                //.Cascade.AllDeleteOrphan();
        }
    }
}
