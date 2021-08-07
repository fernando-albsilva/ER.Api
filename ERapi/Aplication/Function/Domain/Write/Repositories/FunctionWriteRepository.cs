using ERapi.Aplication.Function.Domain.Write.States;
using ERapi.Aplication.Infrastructure;
using NHibernate;


namespace ERapi.Aplication.Function.Domain.Write.Repositories
{

    public class FunctionWriteRepository : IBaseWriteFunctionRepository
    {
        private readonly ISession _session;
        public FunctionWriteRepository(ISession _session)
        {
            this._session = _session;
        }

        public void Save(FunctionState state)
        {
            using (var tran = _session.BeginTransaction())
            {
                _session.Save(state);
                tran.Commit();
            }

        }

        public void Delete(FunctionState state)
        {
            using (var tran = _session.BeginTransaction())
            {
                _session.Delete(state);
                tran.Commit();
            }

        }

        public void Update(FunctionState state)
        {
            using (var tran = _session.BeginTransaction())
            {
                _session.Update(state);
                tran.Commit();
            }
        }

        /*public void Save(FunctionState state)
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

        }*/

        /* public void Update(FunctionState state)
         {
             try
             {
                 SqlConnection sqlConn = new SqlConnection(sqlConnectionFactory.GetConnectionString());

                 sqlConn.Open();

                 var queryString = "UPDATE [dbo].[Function] SET [Type] = @Type WHERE	[Function_Id] = @Id";

                 SqlCommand sqlCmd = new SqlCommand(queryString, sqlConn);

                 SqlParameter param = new SqlParameter();

                 param.ParameterName = "@Id";
                 param.Value = state.Id;
                 sqlCmd.Parameters.Add(param);

                 param = new SqlParameter();

                 param.ParameterName = "@Type";
                 param.Value = state.Type;
                 sqlCmd.Parameters.Add(param);

                 sqlCmd.ExecuteNonQuery();

                 sqlCmd.Dispose();

             }
             catch (SqlException ex)
             {
                 Console.WriteLine(ex.ToString());
             }
         }*/

        /* public void Delete(int id)
         {
             try
             {
                 SqlConnection sqlConn = new SqlConnection(sqlConnectionFactory.GetConnectionString());

                 sqlConn.Open();

                 var queryString = "DELETE FROM [dbo].[Function] WHERE [Function_Id] = @Id";

                 SqlCommand sqlCmd = new SqlCommand(queryString, sqlConn);

                 SqlParameter param = new SqlParameter();

                 param.ParameterName = "@Id";
                 param.Value = id;
                 sqlCmd.Parameters.Add(param);

                 sqlCmd.ExecuteNonQuery();

                 sqlCmd.Dispose();
             }
             catch(SqlException ex)
             {
                 Console.WriteLine(ex.ToString());
             }
         }
     }*/

    }

}