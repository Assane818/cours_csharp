using GesDette.Data.entities;

namespace GesDette.Data.Entities
{
    public class Client : AbstractEntity {


        public string Surname {get; set;} 
        public string Phone {get; set;}
        public string Address {get; set;}
        public User? User {get; set;}
        public List<Dette> Dettes {get; set;}

        public override string ToString() {
            return "Client[" +
                    "id=" + Id +
                    ", surnom='" + Surname + '\'' +
                    ", telephone='" + Phone + '\'' +
                    ", adresse='" + Address + '\'' +
                    ", user=" + (User != null ? User.ToString() : "null") +
                    ", dettes=" + Dettes +'\'' + ']' ;
        }

        public bool Equals(Client obj) {
            if (this == obj) return true;
            if (obj == null) return false;
            Client client = (Client) obj;
            return Id == client.Id &&
                    object.Equals(Surname, client.Surname) &&
                    object.Equals(Phone, client.Phone) &&
                    object.Equals(Address, client.Address);  
        }
    }
}