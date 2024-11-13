using GesDette.Core.Db;
using GesDette.Data.Entities;
using GesDette.Data.Enums;
using GesDette.Data.Repository;
using Dapper;
namespace GesDette.Data.repository.Dapper
{
    public class UserRepositoryImplDapper : IUserRepository
    {
        private readonly IDataBase dataBase;
        public UserRepositoryImplDapper(IDataBase dataBase)
        {
            this.dataBase = dataBase;
        }
        public int Insert(User entity)
{
    using (var conn = dataBase.GetConnection())
    {
        string query = @"
            INSERT INTO Users (Nom, Prenom, Login, Password, Etat, Role, create_at, update_at) 
            VALUES (@Nom, @Prenom, @Login, @Password, @Etat, @Role, @createAt, @updateAt);
            SELECT LAST_INSERT_ID();";
        int newId = conn.QuerySingle<int>(query, entity);
        return newId;
    }
}

        public List<User> SelectAll()
        {
            using (var conn = dataBase.GetConnection())
            {
                return conn.Query<User>("SELECT * FROM Users").ToList();
            }
        }

        public List<User> SelectAllUsersByEtat()
        {
            using (var conn = dataBase.GetConnection())
            {
                return conn.Query<User>("SELECT * FROM Users WHERE Etat = 1").ToList();
            }
        }

        public List<User> SelectAllUsersByRole(Role role)
        {
            using (var conn = dataBase.GetConnection())
            {
                return conn.Query<User>("SELECT * FROM Users WHERE Role = @Role", new { Role = role.ToString() }).ToList();
            }
        }

        public User? SelectById(int id)
        {
            using (var conn = dataBase.GetConnection())
            {
                return conn.QueryFirstOrDefault<User>("SELECT * FROM Users WHERE Id = @Id", new { Id = id });
            }
        }

        public User? SelectByLogin(string login)
        {
            using (var conn = dataBase.GetConnection())
            {
                return conn.QueryFirstOrDefault<User>("SELECT * FROM Users WHERE Login = @Login", new { Login = login });

            }
        }

        public User? SelectUserConnect(string login, string password)
        {
            using (var conn = dataBase.GetConnection())
            {
                return conn.QueryFirstOrDefault<User>("SELECT * FROM Users WHERE Login = @Login AND Password = @Password", new { Login = login, Password = password });
            }
        }

        public bool UpdateEtat(User user, bool etat)
        {
            using (var conn = dataBase.GetConnection())
            {
                string query = "UPDATE Users SET Etat = @Etat, update_at = @updatedAt WHERE Id = @Id";
                conn.Execute(query, new { Etat = etat, Id = user.Id, updatedAt = DateTime.Now });
                return true;
            }
        }
    }
}