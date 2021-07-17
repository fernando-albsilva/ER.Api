using ERapi.Aplication.Function.Domain.Write.States;
using ERapi.Aplication.Infrastructure;
using System;
using System.Data.SqlClient;

namespace ERapi.Aplication.Function.Domain.Write.Repositories
{

    public class FunctionWriteRepository : IBaseWriteFunctionRepository
    {

        private ISqlConnectionFactory sqlConnectionFactory;

        public FunctionWriteRepository(ISqlConnectionFactory sqlConnectionFactory)
        {

            this.sqlConnectionFactory = sqlConnectionFactory;

        }

        public void Save(FunctionState state)
        {

            Console.WriteLine(state);
            try
            {
                SqlConnection sqlConn = new SqlConnection(sqlConnectionFactory.GetConnectionString());

                sqlConn.Open();

                var queryString = "INSERT INTO [dbo].[Function] ([Type]) VALUES (@type)";

                SqlCommand sqlCmd = new SqlCommand(queryString, sqlConn);

                SqlParameter param = new SqlParameter();

                param.ParameterName = "@type";
                param.Value = state.Type;
                sqlCmd.Parameters.Add(param);

                sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();

            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }
    }

}