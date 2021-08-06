using ERapi.Aplication.Product.Domain.Read.Model;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERapi.Aplication.Product.Domain.Maps
{
    public class ProductModelMap : ClassMap<ProductModel>
    {
        public ProductModelMap()
        {
            
            Table("Product");
            
            Id(x => x.Id);
           
            Map(x => x.Name);
            Map(x => x.UnitValue);
            Map(x => x.Cost);
        }
    }
}
