
using Application.Home.Domain.Read.Model;
using FluentNHibernate.Mapping;

namespace Application.Home.Domain.Maps.Read
{
    public class WaiterModelMap : ClassMap<WaiterModel>
    {
        public WaiterModelMap()
        {
            ReadOnly();

            Table("[WaiterView]");

            Id(x => x.WorkerId);

            Map(x => x.Name);
            
        }
    }
}
