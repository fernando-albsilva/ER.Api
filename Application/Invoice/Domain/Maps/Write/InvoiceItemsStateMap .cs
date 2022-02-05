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
            References(x => x.InvoiceState).Column("ActiveInvoiceId");
            References(x => x.ProductState).Column("ProductId");
        }
    }
}
