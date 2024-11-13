namespace WebGestionDette.Entities
{
    public class Client : AbstractEntity
    {
        public string Surname {get; set;} 
        public string Phone {get; set;}
        public string Address {get; set;}
        public virtual User? User {get; set;}
    }
}