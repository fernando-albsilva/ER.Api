using Application.Aplication.Product.Domain.Write.States;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Aplication.Product.Domain.Maps.Write
{
      public class FunctionStateMap : ClassMap<ProductState>
      {
            public FunctionStateMap()
            {
                  Table("Product");

                  Id(x => x.Id).GeneratedBy.Assigned();

                  Map(x => x.Name);
                  Map(x => x.UnitValue);
                  Map(x => x.Cost);
            }
      }
}
