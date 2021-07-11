using ER.Interfaces;
using System;
using ER.States;
using ER.Infrastructure;
using System.Data;
using System.Data.SqlClient;

namespace ER.Repositories
{
    public class ProductRepository : IBaseProductRepository
    {
        private ISqlConnectionFactory sqlConnectionFactory;
        public ProductRepository(ISqlConnectionFactory sqlConnectionFactory)
        {
         this.sqlConnectionFactory = sqlConnectionFactory;
        }

        public void Save(ProductState state)
        {

            Console.WriteLine(state);
            try
            {
                SqlConnection sqlConn = new SqlConnection(sqlConnectionFactory.GetConnectionString());

                sqlConn.Open();

                var queryString = "insert into Product (Id,Name,UnitValue,Cost) values  ('" + state.Id +  "','" + state.Name+ "',@valor,@custo)";

                SqlCommand sqlCmd = new SqlCommand(queryString, sqlConn);
             
                SqlParameter param  = new SqlParameter();

                param.ParameterName = "@valor";
                param.Value = state.UnitValue;
                sqlCmd.Parameters.Add(param);

                param  = new SqlParameter();

                param.ParameterName = "@custo";
                param.Value = state.Cost;
                sqlCmd.Parameters.Add(param);

                sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();

            }
            catch (SqlException ex)
            {

                Console.WriteLine(ex.ToString());

            }
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}