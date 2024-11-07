using GesDette.Data.entities;

namespace GesDette.Data.Entities
{
    public class Client : AbstractEntity {
        private string surname;
        private string phone;
        private string address;
        private User user;
        private static int nbreClient;
        List<Dette> dettes = new List<Dette>();

        public Client() {
            nbreClient++;
            id = nbreClient;
        }

        public int Id {get => id; set => id = value;}
        public string Surname {get => surname; set => surname = value;} 
        public string Phone {get => phone; set => phone = value;}
        public string Address {get => address; set => address = value;}
        public User User {get => user; set => user = value;}
        public List<Dette> Dettes {get => dettes; set => dettes = value;}

        public override string ToString() {
            return "Client[" +
                    "id=" + id +
                    ", surnom='" + surname + '\'' +
                    ", telephone='" + phone + '\'' +
                    ", adresse='" + address + '\'' +
                    ", user=" + (user != null ? user.ToString() : "null") +
                    ", dettes=" + dettes +'\'' + ']' ;
        }

        public bool equals(Client obj) {
            if (this == obj) return true;
            if (obj == null) return false;
            Client client = (Client) obj;
            return id == client.id &&
                    object.Equals(surname, client.surname) &&
                    object.Equals(phone, client.phone) &&
                    object.Equals(address, client.address);  
        }
    }
}