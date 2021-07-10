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
                SqlConnection sqlConn = new SqlConnection(this.SqlConnectionFactory.GetConnectionString());

                sqlConn.Open();

                queyString = "insert into tabela_produto (nome,valor,custo_unitario) values  ('" + produto.Nome +  "','" + produto.Valor.ToString()+ "','" + produto.Custo.ToString()+"')";

                SqlCommand cmd = new SqlCommand(queyString, sqlConn);

                cmd.ExecuteNonQuery();

                cmd.Dispose();

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