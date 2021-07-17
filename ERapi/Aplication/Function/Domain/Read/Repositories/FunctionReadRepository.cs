using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using ERapi.Aplication.Function.Domain.Read.Model;
using ERapi.Aplication.Infrastructure;

namespace ERapi.Aplication.Function.Domain.Read.Repositories
{

    public class FunctionReadRepository : IBaseReadFunctionRepository
    {
        private ISqlConnectionFactory sqlConnectionFactory;

        public FunctionReadRepository(ISqlConnectionFactory sqlConnectionFactory)
        {

            this.sqlConnectionFactory = sqlConnectionFactory;

        }

        public IEnumerable<FunctionModel> GetAll()
        {
            
            try 
            {
                SqlConnection sqlConn = new SqlConnection(sqlConnectionFactory.GetConnectionString());
            
                sqlConn.Open();

                var queryString = "SELECT * FROM [ER].[dbo].[Function]";

                SqlCommand sqlCmd = new SqlCommand(queryString, sqlConn);

                SqlDataReader dados = sqlCmd.ExecuteReader();

                FunctionModel functionModel = new FunctionModel();

                List<FunctionModel> functions = new List<FunctionModel>();

                while(dados.Read())
                {
                    functionModel.Id = dados.GetInt32(0);
                    functionModel.Type = dados.GetString(1);

                    functions.Add(functionModel);

                    functionModel = new FunctionModel();
                }

                dados.Close();

                return functions;
            }
            catch(SqlException ex) 
            {

                Console.WriteLine(ex.ToString());
                throw new NotImplementedException();

            }


        }

        public FunctionModel GetById(int id)
        {
           
            try
            {

                SqlConnection sqlConn = new SqlConnection(sqlConnectionFactory.GetConnectionString());

                sqlConn.Open();

                var queryString = "SELECT * FROM [ER].[dbo].[Function] WHERE [Function_Id] = @Id";

                SqlCommand sqlCmd = new SqlCommand(queryString, sqlConn);

                SqlParameter param = new SqlParameter();

                param.ParameterName = "@Id";
                param.Value = id.ToString();
                sqlCmd.Parameters.Add(param);

                SqlDataReader dados = sqlCmd.ExecuteReader();

                FunctionModel functionModel = new FunctionModel();

                while(dados.Read())
                {

                    functionModel.Id = dados.GetInt32(0);
                    functionModel.Type = dados.GetString(1);

                }

                dados.Close();

                return functionModel;
            
            }
            catch (SqlException ex)
            {

                Console.WriteLine(ex.ToString());
                throw new NotImplementedException();

            }

        }
    }
}