using GesDette.Core.Db;
using GesDette.Data.Entities;
using GesDette.Data.Enums;
using MySql.Data.MySqlClient;

namespace GesDette.Data.Repository.Db
{
    public class UserRepositoryImplBd : IUserRepository
    {
        private IDataBase dataBase;
        public UserRepositoryImplBd(IDataBase dataBase)
        {
            this.dataBase = dataBase;
        }
        public int Insert(User entity)
        {
            using (var conn = dataBase.GetConnection())
            {
                string query = "INSERT INTO Users (Nom, Prenom, Login, Password, Etat, Role, create_at, update_at) VALUES (@Nom, @Prenom, @Login, @Password, @Etat, @Role, @createdAt, @updatedAt)";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Nom", entity.Nom);
                    cmd.Parameters.AddWithValue("@Prenom", entity.Prenom);
                    cmd.Parameters.AddWithValue("@Login", entity.Login);
                    cmd.Parameters.AddWithValue("@Password", entity.Password);
                    cmd.Parameters.AddWithValue("@Etat", entity.Etat);
                    cmd.Parameters.AddWithValue("@Role", (int)entity.Role);
                    cmd.Parameters.AddWithValue("@createdAt", entity.CreateAt);
                    cmd.Parameters.AddWithValue("@updatedAt", entity.UpdateAt);
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("User added successfully.");
                    return (int) cmd.LastInsertedId;
                }
            }

        }

        public List<User> SelectAll()
        {
            throw new NotImplementedException();
        }

        public List<User> SelectAllUsersByEtat()
        {
            throw new NotImplementedException();
        }

        public List<User> SelectAllUsersByRole(Role role)
        {
            throw new NotImplementedException();
        }

        public User SelectById(int id)
        {
            throw new NotImplementedException();
        }

        public User? SelectByLogin(string login)
        {
            using (var conn = dataBase.GetConnection())
            {
                string query = "SELECT * FROM users WHERE login = @login";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@login", login);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new User{
                                Id = reader.GetInt32("id"),
                                Nom = reader.GetString("nom"),
                                Prenom = reader.GetString("prenom"),
                                Login = reader.GetString("login"),
                                Password = reader.GetString("password"),
                                Etat = reader.GetBoolean("etat"),
                                Role = (Role)reader.GetInt32("role"),
                            };
                        }
                    }
                }
            }
            return null;
        }

        public User? SelectUserConnect(string login, string password)
        {
            using (var conn = dataBase.GetConnection())
            {
                string query = "SELECT * FROM users WHERE login = @login AND password = @password";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@login", login);
                    cmd.Parameters.AddWithValue("@password", password);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new User{
                                Id = reader.GetInt32("id"),
                                Nom = reader.GetString("nom"),
                                Prenom = reader.GetString("prenom"),
                                Login = reader.GetString("login"),
                                Password = reader.GetString("password"),
                                Etat = reader.GetBoolean("etat"),
                                Role = (Role)reader.GetInt32("role"),
                            };
                        }
                    }
                }
            }
            return null;
        }

        public bool UpdateEtat(User user, bool etat)
        {
            throw new NotImplementedException();
        }
    }
}