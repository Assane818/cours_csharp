using GesDette.Data.entities;
using GesDette.Data.Enums;

namespace GesDette.Data.Entities
{
    public class User : AbstractEntity{
        private String nom;
        private String prenom;
        private String login;
        private String password;
        private bool etat;
        private Role role;
        private static int nbreUser = 0;

        public User() {
            nbreUser++;
            id = nbreUser;
            etat = true;
        }

        public int Id {get => id; set => id = value;}
        public string Nom {get => nom; set => nom = value;}
        public string Prenom {get => prenom; set => prenom = value;}
        public string Login {get => login; set => login = value;}
        public string Password {get => password; set => password = value;}
        public bool Etat {get => etat; set => etat = value;}
        public Role Role {get => role; set => role = value;}

        public override string ToString() {
            return "User[" +
                    "id=" + id +
                    ", nom='" + nom + '\'' +
                    ", prenom='" + prenom + '\'' +
                    ", login='" + login + '\'' +
                    ", password='" + password + '\'' +
                    ", etat=" + etat +
                    ", role=" + role + ']';
        }

        public bool equals(User user) {
            if (user == null) return false;
            if (this == user) return true;
            User u = (User) user;
            return this.Id == u.Id &&
                    object.Equals(nom, u.Nom) &&
                    object.Equals(prenom, u.Prenom) &&
                    object.Equals(login, u.Login) &&
                    object.Equals(password, u.Password) &&
                    this.Etat == u.Etat &&
                    object.Equals(role, u.Role);
        } 
    }
}