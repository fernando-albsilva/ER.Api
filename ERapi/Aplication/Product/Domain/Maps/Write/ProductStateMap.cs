using ERapi.Aplication.Product.Domain.Write.States;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERapi.Aplication.Product.Domain.Maps.Write
{
    public class ProductStateMap : ClassMap<ProductState>
    {
        public ProductStateMap()
        {   
            Table("Product");

            Id(x => x.Id).GeneratedBy.Assigned();

            Map(x => x.Name);
            Map(x => x.UnitValue);
            Map(x => x.Cost);
        }
    }
}
