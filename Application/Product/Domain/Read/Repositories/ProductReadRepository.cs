using System.Collections.Generic;
using System;
using System.Linq;
using NHibernate;
using Application.Product.Domain.Read.Model;


namespace Application.Product.Domain.Read.Repositories
{
      public class ProductReadRepository : IBaseReadProductRepository
      {
            private readonly ISession _session;

            public ProductReadRepository(ISession _session)
            {
                      this._session = _session;
            }

            public ProductModel GetById(Guid Id)
            {
                      var product = new ProductModel();
                      var list = _session.Query<ProductModel>().Where(x => x.Id == Id).ToList();

                      product = list.ElementAt(0);

                      return product;
            }

            public IEnumerable<ProductModel> GetAll()
            {
                var list = this._session.Query<ProductModel>().ToList();
                return list;
            }
      }
}