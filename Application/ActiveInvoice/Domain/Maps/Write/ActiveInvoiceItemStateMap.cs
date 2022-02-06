using Application.ActiveInvoice.Domain.Write.States;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ActiveInvoice.Domain.Maps.Write
{
    public class ActiveInvoiceItemStateMap : ClassMap<ActiveInvoiceItemState>
    {
        public ActiveInvoiceItemStateMap()
        {
            Table("ActiveInvoiceItem");

            Id(x => x.Id, "Id");
            Map(x => x.Quantity, "Quantity");

            References(x => x.Product, "ProductId");
            References(x => x.ActiveInvoiceState) // you'll need 'Property' in your class definition too
            .Column("ActiveInvoiceId");
     

        }
    }
}
