using ERapi.Aplication.Function.Domain.Read.Model;
using FluentNHibernate.Mapping;

namespace ERapi.Aplication.Function.Domain.Maps
{
    public class FunctionModelMap : ClassMap<FunctionModel>
    {
        public FunctionModelMap()
        {
            ReadOnly();

            Table("[Function]");
            
            Id(x => x.Id);
           
            Map(x => x.Type);
        }
    }
}
