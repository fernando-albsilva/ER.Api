using Application.Aplication.Product.Domain.Read.Model;
using FluentNHibernate.Mapping;


namespace Application.Aplication.Product.Domain.Maps.Read
{
      public class ProductModelMap : ClassMap<ProductModel>
      {
            public ProductModelMap()
            {
                   ReadOnly();
                  
                  Table("Product");

                  Id(x => x.Id);

                  Map(x => x.Name);
                  Map(x => x.UnitValue);
                  Map(x => x.Cost);
            }
      }
}
