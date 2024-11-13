using MySql.Data.MySqlClient;

namespace GesDette.Core.Db
{
    public class DataBase : IDataBase
    {
        private readonly string connectionString = "Server=localhost;Port=3306;Database=gestion_dette;User ID=root;Password=;";
        private MySqlConnection? conn;
        public void CloseConnection()
        {
            if (conn != null && conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
                conn = null;
            }
        }

        public MySqlConnection GetConnection()
        {
            conn = new MySqlConnection(connectionString);
            conn.Open();
            return conn;
        }
    }
}