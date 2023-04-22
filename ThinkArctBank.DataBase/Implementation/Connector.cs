using System.Data.SqlClient;

namespace ThinkArctBank.DataBase
{
    public static class Connector
    {
        public static SqlConnection Connect()
        {
            string connectionString =
                "Data Source= AXNIGCELAP4660; Initial Catalog = BankAppDemo; Integrated Security = True";
            //string connectString = ConfigurationManager.ConnectionStrings["BankDataBase"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(connectionString);
            return myConnection;
        }

    }
}
