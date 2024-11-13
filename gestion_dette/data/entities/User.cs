using GesDette.Data.entities;
using GesDette.Data.Enums;

namespace GesDette.Data.Entities
{
    public class User : AbstractEntity{

        public string Nom {get; set;}
        public string Prenom {get; set;}
        public string Login {get; set;}
        public string Password {get; set;}
        public bool Etat {get; set;} = true;
        public Role Role {get; set;}

        public override string ToString() {
            return "User[" +
                    "id=" + Id +
                    ", nom='" + Nom + '\'' +
                    ", prenom='" + Prenom + '\'' +
                    ", login='" + Login + '\'' +
                    ", password='" + Password + '\'' +
                    ", etat=" + Etat +
                    ", role=" + Role + ']';
        }

        public bool equals(User user) {
            if (user == null) return false;
            if (this == user) return true;
            User u = (User) user;
            return this.Id == u.Id &&
                    object.Equals(Nom, u.Nom) &&
                    object.Equals(Prenom, u.Prenom) &&
                    object.Equals(Login, u.Login) &&
                    object.Equals(Password, u.Password) &&
                    this.Etat == u.Etat &&
                    object.Equals(Role, u.Role);
        } 
    }
}