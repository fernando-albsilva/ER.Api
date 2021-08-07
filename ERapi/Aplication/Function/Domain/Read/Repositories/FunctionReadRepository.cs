using System;
using System.Collections.Generic;
using System.Linq;
using ERapi.Aplication.Function.Domain.Read.Model;
using NHibernate;

namespace ERapi.Aplication.Function.Domain.Read.Repositories
{

    public class FunctionReadRepository : IBaseReadFunctionRepository
    {
        private readonly ISession _session;
        public FunctionReadRepository(ISession _session)
        {

            this._session = _session;

        }

        public FunctionModel GetById(int id)
        {
            var function = new FunctionModel();
            var list = _session.Query<FunctionModel>().Where(x => x.Id == id).ToList();

            function = list.ElementAt(0);

            return function;
        }

         public IEnumerable<FunctionModel> GetAll()
        {
            var list = _session.Query<FunctionModel>().ToList();
            return list;
        }

        /*public IEnumerable<FunctionModel> GetAll()
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


        }*/

        /* public FunctionModel GetById(int id)
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

         }*/
    }
}