using ERapi.Aplication.Product.Domain.Read.Model;
using FluentNHibernate.Mapping;


namespace ERapi.Aplication.Product.Domain.Maps
{
    public class FunctionModelMap : ClassMap<ProductModel>
    {
        public FunctionModelMap()
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
