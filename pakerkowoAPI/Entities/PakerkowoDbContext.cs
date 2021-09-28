using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pakerkowo.Entities
{
    public class PakerkowoDbContext : DbContext
    {
        public PakerkowoDbContext(DbContextOptions<PakerkowoDbContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(u => u.Nickname)
                .IsRequired()
                .HasMaxLength(20);
            modelBuilder.Entity<User>()
                .Property(u => u.Email)
                .IsRequired();
            modelBuilder.Entity<User>()
                .Property(u => u.PasswordHash)
                .IsRequired();
            modelBuilder.Entity<User>()
                .Property(u => u.Role)
                .IsRequired();
        }
    }
}
