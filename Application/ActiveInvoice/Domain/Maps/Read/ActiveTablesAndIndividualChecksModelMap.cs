using Application.ActiveInvoice.Domain.Read.Model;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ActiveInvoice.Domain.Maps.Read
{
    class ActiveTablesAndIndividualChecksModelMap : ClassMap<ActiveTablesAndIndividualChecksModel>
    {
        public ActiveTablesAndIndividualChecksModelMap()
        {
            ReadOnly();

            Table("ActiveInvoice");

            Id(x => x.Id);

            Map(x => x.TableNumber, "TableNumber");
            Map(x => x.IndividualCheckNumber, "IndividualCheckNumber");
            Map(x => x.ClientName, "ClientName");
        }
    }
}
