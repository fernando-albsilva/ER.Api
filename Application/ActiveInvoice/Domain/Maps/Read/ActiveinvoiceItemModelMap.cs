using Application.ActiveInvoice.Domain.Read.Model;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ActiveInvoice.Domain.Maps.Read
{
    public class ActiveinvoiceItemModelMap : ClassMap<ActiveInvoiceItemModel>
    {
        public ActiveinvoiceItemModelMap()
        {
            ReadOnly();

            Table("ActiveInvoiceItem");

            Id(x => x.Id, "Id");
            Map(x => x.Quantity, "Quantity");
            Map(x => x.ActiveInvoiceId, "ActiveInvoiceId");
            Map(x => x.ProductId, "ProductId");
        }
    }
}
