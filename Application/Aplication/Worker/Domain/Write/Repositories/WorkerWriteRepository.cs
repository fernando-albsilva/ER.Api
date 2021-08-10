using System;
using System.Data.SqlClient;
using Application.Aplication.Infrastructure;
using Application.Aplication.Worker.Domain.Write.States;


namespace Application.Aplication.Worker.Domain.Write.Repositories
{

      public class WorkerWriteRepository : IBaseWriteWorkerRepository
      {

            private ISqlConnectionFactory sqlConnectionFactory;

            public WorkerWriteRepository(ISqlConnectionFactory sqlConnectionFactory)
            {
                  this.sqlConnectionFactory = sqlConnectionFactory;
            }

            public void Delete(Guid id)
            {
                  throw new NotImplementedException();
            }

            public void Save(WorkerState state)
            {
                  /* try
                   {

                       SqlConnection sqlConn = new SqlConnection(sqlConnectionFactory.GetConnectionString());

                       sqlConn.Open();


                       var queryString = "INSERT INTO dbo.Worker (Worker_Id, Function_Id_Fk, [Name], Cpf, Phone_Number, [Address], Email) VALUES (@ID, @FUNCTION_ID, @NAME, @CPF, @PHONE_NUMBER, @ADDRESS, @EMAIL)";

                       SqlCommand sqlCmd = new SqlCommand(queryString, sqlConn);

                       SqlParameter param = new SqlParameter();

                       param.ParameterName = "@ID";
                       param.Value = state.Id;
                       sqlCmd.Parameters.Add(param);

                       param = new SqlParameter();

                       param.ParameterName = "@FUNCTION_ID";
                       param.Value = state.FunctionIdFk;
                       sqlCmd.Parameters.Add(param);

                       param = new SqlParameter();

                       param.ParameterName = "@NAME";
                       param.Value = state.Name;
                       sqlCmd.Parameters.Add(param);

                       param = new SqlParameter();

                       param.ParameterName = "@CPF";
                       param.Value = state.Cpf;
                       sqlCmd.Parameters.Add(param);

                       param = new SqlParameter();


                       param.ParameterName = "@PHONE_NUMBER";
                       param.Value = state.PhoneNumber;
                       sqlCmd.Parameters.Add(param);

                       param = new SqlParameter();

                       param.ParameterName = "@ADDRESS";
                       param.Value = state.Address;
                       sqlCmd.Parameters.Add(param);

                       param = new SqlParameter();

                       param.ParameterName = "@EMAIL";
                       param.Value = state.Email;
                       sqlCmd.Parameters.Add(param);

                       sqlCmd.ExecuteNonQuery();

                       sqlCmd.Dispose();



                   }
                   catch(SqlException ex)
                   {

                       Console.WriteLine(ex.ToString());

                   }*/
            }

            public void Update(WorkerState state)
            {
                  throw new NotImplementedException();
            }
      }

}
