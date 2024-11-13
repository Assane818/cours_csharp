
using WebGestionDette.Models.Enum;

namespace WebGestionDette.Models
{
    public class User : AbstractEntity
    {
        public string Nom {get; set;}
        public string Prenom {get; set;}
        public string Login {get; set;}
        public string Password {get; set;}
        public bool Etat {get; set;} = true;
        public Role Role {get; set;} 
    }
}