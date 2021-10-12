using Application.Aplication.Product.Domain.Write.States;
using NHibernate;
using System;
using System.Linq;

namespace Application.Aplication.Product.Domain.Write.Repositories
{
      public class InvoiceWriteRepository : IBaseWriteInvoiceRepository
      {
            private readonly ISession _session;
            public InvoiceWriteRepository(ISession _session)
            {

                  this._session = _session;
            }

            public InvoiceState GetById(Guid Id)
            {
                var productState = new InvoiceState();
                var list = _session.Query<InvoiceState>().Where(x => x.Id == Id).ToList();

                productState = list.ElementAt(0);

                if (list.Count < 1)
                {
                    productState.Id = Guid.Empty;
                }

                return productState;
            }

            public void Save(InvoiceState state)
                {
                      using (var tran = _session.BeginTransaction())
                      {
                            _session.Save(state);
                            tran.Commit();
                      }

                }

            public void Delete(InvoiceState state)
            {
                  using (var tran = _session.BeginTransaction())
                  {
                        _session.Delete(state);
                        tran.Commit();
                  }

            }

            public void Update(InvoiceState state)
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