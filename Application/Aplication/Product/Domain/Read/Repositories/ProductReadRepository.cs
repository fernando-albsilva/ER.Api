using System.Collections.Generic;
using System;
using System.Linq;
using NHibernate;
using Application.Aplication.Product.Domain.Read.Model;
using System.Data.SqlClient;
using Application.Aplication.Infrastructure;

namespace Application.Aplication.Product.Domain.Read.Repositories
{
      public class ProductReadRepository : IBaseReadProductRepository
      {
            private readonly ISession _session;

        public ISqlConnectionFactory sqlConnectionFactory;
        private List<ProductModel> products;

        public ProductReadRepository(ISession _session, ISqlConnectionFactory SqlConnectionFactory)
            {
                  this._session = _session;
            this.sqlConnectionFactory = SqlConnectionFactory;

            }


        /*  public ProductModel GetById(Guid Id)
          {
              try
              {
                  SqlConnection sqlConn = new SqlConnection(sqlConnectionFactory.GetConnectionString());

                  sqlConn.Open();

                  var queyString = "select * from Product where Product.Id = @Id ";

                  SqlCommand sqlCmd = new SqlCommand(queyString, sqlConn);

                  SqlParameter param = new SqlParameter();

                  param.ParameterName = "@Id";
                  param.Value = Id.ToString();
                  sqlCmd.Parameters.Add(param);

                  SqlDataReader dados = sqlCmd.ExecuteReader();


                  ProductModel productModel = new ProductModel();

                  while (dados.Read())
                  {

                      productModel.Id = Guid.Parse(dados.GetString(0));
                      productModel.Name = dados.GetString(1);
                      productModel.UnitValue = dados.GetDecimal(2);
                      productModel.Cost = dados.GetDecimal(3);

                  }

                  dados.Close();

                  return productModel;
              }
              catch (SqlException ex)
              {

                  Console.WriteLine(ex.ToString());
                  throw new NotImplementedException();

              }
          }*/

       /* public IEnumerable<ProductModel> GetAll()
        {
            try
            {
                SqlConnection sqlConn = new SqlConnection(sqlConnectionFactory.GetConnectionString());

                sqlConn.Open();

                var queyString = "select * from Product";

                SqlCommand sqlCmd = new SqlCommand(queyString, sqlConn);

                SqlDataReader dados = sqlCmd.ExecuteReader();

                ProductModel productModel = new ProductModel();

                products = new List<ProductModel>();

                while (dados.Read())
                {

                    productModel.Id = Guid.Parse(dados.GetString(0));
                    productModel.Name = dados.GetString(1).TrimEnd();
                    productModel.UnitValue = dados.GetDecimal(2);
                    productModel.Cost = dados.GetDecimal(3);

                    products.Add(productModel);

                    productModel = new ProductModel();
                }

                dados.Close();

                return products;
            }
            catch (SqlException ex)
            {

                Console.WriteLine(ex.ToString());
                throw new NotImplementedException();

            }
        }*/

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