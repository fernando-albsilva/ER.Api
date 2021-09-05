using Application.Aplication.Function.Domain.Read.Model;
using FluentNHibernate.Mapping;

namespace Application.Aplication.Function.Domain.Maps.Read
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
