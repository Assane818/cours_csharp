using MySql.Data.MySqlClient;

namespace GesDette.Core.Db
{
    public interface IDataBase
    {
        MySqlConnection GetConnection();
        void CloseConnection();
    }
}