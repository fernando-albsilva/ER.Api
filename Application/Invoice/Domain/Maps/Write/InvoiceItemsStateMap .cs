using Application.Invoice.Domain.Write.States;
using FluentNHibernate.Mapping;

namespace Application.Invoice.Domain.Maps.Write
{
    public class InvoiceItemStateMap : ClassMap<InvoiceItemState>
    {
        public InvoiceItemStateMap()
        {
            Table("InvoiceItems");

            Id(x => x.Id, "Id");
            References(x => x.InvoiceState).Column("InvoiceId");
            References(x => x.ProductState).Column("ProductId");
            Map(x => x.UnitValue, "UnitValue");
            Map(x => x.Cost, "Cost");
            Map(x => x.Quantity, "Quantity");
                //.Cascade.AllDeleteOrphan();
        }
    }
}
