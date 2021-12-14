using Application.Function.Domain.Write.States;
using FluentNHibernate.Mapping;


namespace Application.Function.Domain.Maps.Write
{
      public class FunctionStateMap : ClassMap<FunctionState>
      {
            public FunctionStateMap()
            {
                  Table("[Function]");

            // Does not have id because column Id is auto incremente (identity)
            //.Cascade.AllDeleteOrphan();
            Id(x => x.Id).GeneratedBy.Identity();

                  Map(x => x.Type);
            }
      }
}
