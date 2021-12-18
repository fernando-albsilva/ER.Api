using Application.Invoice.Domain.Write.States;
using Application.Product.Domain.Write.States;
using FluentNHibernate.Mapping;

namespace Application.Product.Domain.Maps.Write
{
      public class ProductStateMap : ClassMap<ProductState>
      {
            public ProductStateMap()
            {
                  Table("Product");

                  Id(x => x.Id);  

                  Map(x => x.Name);
                  Map(x => x.UnitValue);
                  Map(x => x.Cost);
                  Map(x => x.Code);
                  HasMany(x => x.InvoiceItemState).KeyColumn("ProductId").Cascade.AllDeleteOrphan();
            }
      }
}
