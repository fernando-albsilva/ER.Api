using Application.ActiveInvoice.Domain.Write.States;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ActiveInvoice.Domain.Maps.Write
{
    public class ActiveInvoiceStateMap : ClassMap<ActiveInvoiceState>
    {
        public ActiveInvoiceStateMap()
        {
            Table("ActiveInvoice");

            Id(x => x.Id);

            Map(x => x.Date);
            Map(x => x.ClientName);
            Map(x => x.TableNumber);
            Map(x => x.IndividualCheckNumber);
            Map(x => x.StartTime);
            References(x => x.User,"UserId");
            References(x => x.Worker,"WorkerId");

            HasMany(x => x.ActiveInvoiceItemsState).KeyColumn("ActiveInvoiceId");

            //TODO
            // Mapear de acordo com a tabela
        }
    }
}
