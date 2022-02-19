using Application.Invoice.Domain.Write.States;
using FluentNHibernate.Mapping;

namespace Application.Invoice.Domain.Maps.Write
{
    public class InvoiceItemStateMap : ClassMap<InvoiceItemState>
    {
        public InvoiceItemStateMap()
        {
            Table("InvoiceItem");

            Id(x => x.Id, "Id");
            
            Map(x => x.Quantity, "Quantity");
            Map(x => x.Cost, "Cost");
            Map(x => x.UnitValue, "UnitValue");

            References(x => x.Invoice).Column("InvoiceId");
            References(x => x.Product).Column("ProductId");
        }
    }
}
