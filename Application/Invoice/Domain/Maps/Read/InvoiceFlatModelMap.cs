using Application.Invoice.Domain.Read.Model;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Invoice.Domain.Maps.Read
{
    class InvoiceFlatModelMap : ClassMap<InvoiceFlatModel>
    {
        public InvoiceFlatModelMap()
        {
            ReadOnly();

            Table("[InvoiceFlatModelView]");

            Id(x => x.Id, "Id");
            
            Map(x => x.ClientName);
            Map(x => x.Date);
            Map(x => x.Duration);
            Map(x => x.WorkerName);
            Map(x => x.TotalValue);
        }
    }
}
