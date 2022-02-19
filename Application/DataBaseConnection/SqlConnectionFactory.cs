
namespace Application.DataBaseConnection
{
    public class SqlConnectionFactory : ISqlConnectionFactory
    {

        public string GetConnectionString()
        {  
            return "Data Source=(localdb)\\MSSQLLocalDB;" +
                  "Initial Catalog=ER;" +
                  "User id=sa;" +
                  "Password=123456;";
        }
    }
}
