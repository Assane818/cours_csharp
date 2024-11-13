using GesDette.Core.Db;
using GesDette.Data.Entities;
using Dapper;

namespace GesDette.Data.Repository.Dapper
{
    public class ClientRepositoryImplDapper : IClientRepository
    {
        private IDataBase dataBase;
        public ClientRepositoryImplDapper(IDataBase dataBase)
        {
            this.dataBase = dataBase;
        }
        public int Insert(Client entity)
        {
            using (var conn = dataBase.GetConnection())
            {
                string query = @"INSERT INTO Clients (surname, phone, Address, create_at, update_at, user_id) VALUES (@Surname, @Phone, @Address, @createAt, @updateAt, @user);SELECT LAST_INSERT_ID();";
                var parameter = new{
                        Surname = entity.Surname, 
                        Phone = entity.Phone, 
                        Address = entity.Address, 
                        createAt = entity.CreateAt, 
                        updateAt = entity.UpdateAt,
                        user = entity.User.Id
                    };
                return conn.QuerySingle<int>(query, parameter);
            }
        }

        public List<Client> SelectAll()
        {
            using (var conn = dataBase.GetConnection())
            {
                return conn.Query<Client>("SELECT * FROM Clients LEFT JOIN Users ON Clients.user_id = Users.id").ToList();
            }
        }


        public Client SelectById(int id)
        {
            using (var conn = dataBase.GetConnection())
            {
                return conn.QueryFirstOrDefault<Client>("SELECT * FROM Clients WHERE id = @Id", new { Id = id });
            }
        }

        public Client? SelectByPhone(string phone)
        {
            using (var conn = dataBase.GetConnection())
            {
                return conn.QueryFirstOrDefault<Client>("SELECT * FROM Clients WHERE phone = @Phone", new { Phone = phone });
            }
        }

        public Client? SelectBySurname(string surname)
        {
            using (var conn = dataBase.GetConnection())
            {
                return conn.QueryFirstOrDefault<Client>("SELECT * FROM Clients WHERE surname = @Prenom", new { Prenom = surname });
            }
        }

        public Client SelectByUser(User user)
        {
            using (var conn = dataBase.GetConnection())
            {
                return conn.QueryFirstOrDefault<Client>("SELECT * FROM Clients WHERE userId = @Id", new { Id = user.Id });
            }
        }

        public List<Client> SelectClientAccount()
        {
            using (var conn = dataBase.GetConnection())
            {
                return conn.Query<Client>("SELECT * FROM Clients WHERE userId IS NOT NULL").ToList();
            }
        }

        public List<Client> SelectClientNoAccount()
        {
            using (var conn = dataBase.GetConnection())
            {
                return conn.Query<Client>("SELECT * FROM Clients WHERE userId IS NULL").ToList();
            }
        }
    }
}