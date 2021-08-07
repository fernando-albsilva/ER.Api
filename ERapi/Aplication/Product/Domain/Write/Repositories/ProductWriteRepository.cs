using ERapi.Aplication.Infrastructure;
using ERapi.Aplication.Product.Domain.Write.States;
using NHibernate;

namespace ERapi.Aplication.Product.Domain.Write.Repositories
{
    public class ProductWriteRepository : IBaseWriteProductRepository
    {
        private readonly ISession _session;
        public ProductWriteRepository(ISession _session)
        {

            this._session = _session;
        }

        public void Save(ProductState state)
        {
            using (var tran = _session.BeginTransaction())
            {
                _session.Save(state);
                tran.Commit();
            }
         
        }

        public void Delete(ProductState state)
        {
            using (var tran = _session.BeginTransaction())
            {
                _session.Delete(state);
                tran.Commit();
            }

        }

        public void Update(ProductState state)
        {
            using (var tran = _session.BeginTransaction())
            {
                _session.Update(state);
                tran.Commit();
            }
        }

        /* public void Save(ProductState state)
         {

             Console.WriteLine(state);
             try
             {
                 SqlConnection sqlConn = new SqlConnection(sqlConnectionFactory.GetConnectionString());

                 sqlConn.Open();

                 var queryString = "INSERT INTO Product (Id,Name,UnitValue,Cost) VALUES  ('" + state.Id + "','" + state.Name + "',@valor,@custo)";

                 SqlCommand sqlCmd = new SqlCommand(queryString, sqlConn);

                 SqlParameter param = new SqlParameter();

                 param.ParameterName = "@valor";
                 param.Value = state.UnitValue;
                 sqlCmd.Parameters.Add(param);

                 param = new SqlParameter();

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
         }*/
        /* public void Delete(Guid Id)
         {

             try
             {
                 SqlConnection sqlConn = new SqlConnection(sqlConnectionFactory.GetConnectionString());

                 sqlConn.Open();

                 var queryString = "DELETE  FROM Product WHERE Product.Id = @Id";

                 SqlCommand sqlCmd = new SqlCommand(queryString, sqlConn);

                 SqlParameter param = new SqlParameter();

                 param.ParameterName = "@Id";
                 param.Value = Id.ToString("D");
                 sqlCmd.Parameters.Add(param);

                 sqlCmd.ExecuteNonQuery();

                 sqlCmd.Dispose();

             }
             catch (SqlException ex)
             {

                 Console.WriteLine(ex.ToString());

             }
         }*/
        /*    public void Update(ProductState state)
         {
             Console.WriteLine(state);
             try
             {
                 SqlConnection sqlConn = new SqlConnection(sqlConnectionFactory.GetConnectionString());

                 sqlConn.Open();

                 var queryString = "UPDATE Product SET Name = '" + state.Name + "', UnitValue = @valor, Cost = @custo WHERE Product.Id = @Id";

                 SqlCommand sqlCmd = new SqlCommand(queryString, sqlConn);

                 SqlParameter param = new SqlParameter();

                 param.ParameterName = "@valor";
                 param.Value = state.UnitValue;
                 sqlCmd.Parameters.Add(param);

                 param = new SqlParameter();

                 param.ParameterName = "@custo";
                 param.Value = state.Cost;
                 sqlCmd.Parameters.Add(param);

                 param = new SqlParameter();

                 param.ParameterName = "@Id";
                 param.Value = state.Id.ToString("D");
                 sqlCmd.Parameters.Add(param);

                 sqlCmd.ExecuteNonQuery();

                 sqlCmd.Dispose();

             }
             catch (SqlException ex)
             {

                 Console.WriteLine(ex.ToString());

             }
         }*/
    }
}