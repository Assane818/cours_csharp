using Microsoft.EntityFrameworkCore;
using WebGestionDette.Models;

namespace WebGestionDette.Data
{
    public class WebGesDetteContext :DbContext
    {
        public WebGesDetteContext(DbContextOptions<WebGesDetteContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Dette> Dettes { get; set; }
        public DbSet<Detail> Details { get; set; }
        public DbSet<Payement> Payements { get; set; }
    }
}