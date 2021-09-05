using Application.Aplication.Function.Domain.Write.States;
using FluentNHibernate.Mapping;


namespace Application.Aplication.Function.Domain.Maps.Write
{
      public class FunctionStateMap : ClassMap<FunctionState>
      {
            public FunctionStateMap()
            {
                  Table("[Function]");

                  // Does not have id because column Id is auto incremente (identity)
                  Id(x => x.Id).GeneratedBy.Identity();

                  Map(x => x.Type);
            }
      }
}
