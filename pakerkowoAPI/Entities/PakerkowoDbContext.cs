using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PakerkowoAPI.Entities
{
    public class PakerkowoDbContext : DbContext
    {
        public PakerkowoDbContext(DbContextOptions<PakerkowoDbContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<BodyPart> BodyParts { get; set; }
        public DbSet<TrainingSchedule> TrainingSchedules { get; set; }

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
                .Property(u => u.RoleId)
                .IsRequired();
            modelBuilder.Entity<User>()
                .HasMany(u => u.LikedExercises)
                .WithMany(e => e.UsersLiked);

            modelBuilder.Entity<Role>()
                .Property(r => r.Name)
                .IsRequired();

            modelBuilder.Entity<Exercise>()
                .Property(e => e.Name)
                .IsRequired();
            modelBuilder.Entity<Exercise>()
                .HasOne(e => e.CreatedBy);


            modelBuilder.Entity<BodyPart>()
                .Property(bp => bp.Name)
                .IsRequired();

            modelBuilder.Entity<TrainingSchedule>()
                .Property(t => t.Name)
                .IsRequired();
            
            
        }
    }
}
