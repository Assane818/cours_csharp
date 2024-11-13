using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Proxies;

namespace WebGestionDette.Entities
{
    public class WebGesDetteContext :DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Client> Clients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseNpgsql("Host=localhost;Database=gestion_dette_csarp;Username=postgres;Password=Assane123;Port=5433").UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("users");
            modelBuilder.Entity<User>().Property(u => u.CreateAt).HasColumnName("create_at");
            modelBuilder.Entity<User>().Property(u => u.UpdateAt).HasColumnName("update_at");
            modelBuilder.Entity<Client>().ToTable("clients");
            modelBuilder.Entity<Client>().Property(c => c.CreateAt).HasColumnName("create_at");
            modelBuilder.Entity<Client>().Property(c => c.UpdateAt).HasColumnName("update_at");
        }
    }
}