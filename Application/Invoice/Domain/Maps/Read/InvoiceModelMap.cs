using Application.Invoice.Domain.Read.Model;
using FluentNHibernate.Mapping;

namespace Application.Invoice.Domain.Maps.Read
{
    public class InvoiceModelMap : ClassMap<InvoiceModel>
    {
        public InvoiceModelMap()
        {
            ReadOnly();

            Table("Invoice");

            Id(x => x.Id, "Id");

            Map(x => x.Date, "Date");
            Map(x => x.ClientName, "ClientName");
            //Map(x => x.Duration, "Duration");

            References(x => x.Worker).Column("WorkerId");
            References(x => x.User).Column("UserId");

            HasMany(x => x.InvoiceItems)
                .KeyColumn("InvoiceId");
        }
    }
}
