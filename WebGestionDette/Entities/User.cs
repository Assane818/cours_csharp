using WebGestionDette.Enums;

namespace WebGestionDette.Entities
{
    public class User : AbstractEntity
    {
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public bool Etat { get; set; }
        public Role Role { get; set; }

        public User()
        {
            Etat = true;
        }
    }
}