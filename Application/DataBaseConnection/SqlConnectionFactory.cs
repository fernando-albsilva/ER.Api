
namespace Application.DataBaseConnection
{
    public class SqlConnectionFactory : ISqlConnectionFactory
    {

        public string GetConnectionString()
        {
   
            return "Data Source=SIA-FSILVA;" +
                  "Initial Catalog=ER;" +
                  "User id=sa;" +
                  "Password=fer200790nando;";
        }
    }
}
