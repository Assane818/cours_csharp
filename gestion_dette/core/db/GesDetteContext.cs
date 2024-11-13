using GesDette.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace GesDette.Core.Db
{
    public class GesDetteContext :DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Dette> Dettes { get; set; }
        public DbSet<Payement> Payments { get; set; }
        public DbSet<Detail> Details { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseNpgsql("Host=localhost;Database=gestion_dette_csarp;Username=postgres;Password=Assane123;Port=5433");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("users");
            modelBuilder.Entity<User>().Property(u => u.CreateAt).HasColumnName("create_at");
            modelBuilder.Entity<User>().Property(u => u.UpdateAt).HasColumnName("update_at");
            modelBuilder.Entity<Client>().ToTable("clients");
            modelBuilder.Entity<Client>().Property(c => c.CreateAt).HasColumnName("create_at");
            modelBuilder.Entity<Client>().Property(c => c.UpdateAt).HasColumnName("update_at");
            modelBuilder.Entity<Article>().ToTable("articles");
            modelBuilder.Entity<Article>().Property(a => a.CreateAt).HasColumnName("create_at");
            modelBuilder.Entity<Article>().Property(a => a.UpdateAt).HasColumnName("update_at");
            modelBuilder.Entity<Dette>().ToTable("dettes");
            modelBuilder.Entity<Dette>().Property(d => d.CreateAt).HasColumnName("create_at");
            modelBuilder.Entity<Dette>().Property(d => d.UpdateAt).HasColumnName("update_at");
            modelBuilder.Entity<Payement>().ToTable("paiements");
            modelBuilder.Entity<Payement>().Property(p => p.CreateAt).HasColumnName("create_at");
            modelBuilder.Entity<Payement>().Property(p => p.UpdateAt).HasColumnName("update_at");
            modelBuilder.Entity<Detail>().ToTable("details");
            modelBuilder.Entity<Detail>().Property(d => d.CreateAt).HasColumnName("create_at");
            modelBuilder.Entity<Detail>().Property(d => d.UpdateAt).HasColumnName("update_at");
        }
    }
}