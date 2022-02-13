using Application.Worker.Domain.Read.Model;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Worker.Domain.Maps.Read
{
    class WorkerActiveInvoiceModelMap : ClassMap<WorkerActiveInvoiceModel>
    {
        public WorkerActiveInvoiceModelMap()
        {
            ReadOnly();

            Table("Worker");

            Id(x => x.Id);
            Map(x => x.Name);
        }
    }
}
