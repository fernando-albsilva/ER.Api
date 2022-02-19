using Application.Invoice.Domain.Read.Model;
using FluentNHibernate.Mapping;

namespace Application.Invoice.Domain.Maps.Read
{
    public class InvoiceItemModelMap : ClassMap<InvoiceItemModel>
    {
        public InvoiceItemModelMap()
        {
            ReadOnly();

            Table("InvoiceItem");

            Id(x => x.Id, "Id");

            Map(x => x.Quantity, "Quantity");
            Map(x => x.Cost, "Cost");
            Map(x => x.UnitValue, "UnitValue");

            References(x => x.Product).Column("ProductId");
        }
    }
}
