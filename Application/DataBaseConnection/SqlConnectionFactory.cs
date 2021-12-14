
namespace Application.DataBaseConnection
{
    public class SqlConnectionFactory : ISqlConnectionFactory
    {

        public string GetConnectionString()
        {
            return "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ER;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        }
    }
}
