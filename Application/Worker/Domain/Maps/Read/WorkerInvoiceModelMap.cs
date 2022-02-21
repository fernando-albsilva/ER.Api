using Application.Worker.Domain.Read.Model;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Worker.Domain.Maps.Read
{
    public class WorkerInvoiceModelMap : ClassMap<WorkerInvoiceModel>
    {
        public WorkerInvoiceModelMap()
        {
            ReadOnly();

            Table("[Worker]");

            Id(x => x.Id);
            
            Map(x => x.Name);
        }
    }
}
