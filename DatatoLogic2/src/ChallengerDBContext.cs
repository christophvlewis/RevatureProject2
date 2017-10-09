using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Configuration;
using Microsoft.Extensions.Configuration;

namespace DatatoLogic2.src
{
	public partial class ChallengerDBContext : DbContext
	{
		public virtual DbSet<Administrator> Administrator { get; set; }
		public virtual DbSet<Challenge> Challenge { get; set; }
		public virtual DbSet<NonAdmin> NonAdmin { get; set; }
		public virtual DbSet<Progress> Progress { get; set; }
		public virtual DbSet<UserCreds> UserCreds { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
				optionsBuilder.UseSqlServer(@"data source=sqlmiah.database.windows.net;initial catalog=ChallengerDB;user id=miahtampa;password=Pass1234");
				//optionsBuilder.UseSqlServer(Startup.ConnectionString);
				

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Administrator>(entity =>
            {
                entity.HasKey(e => e.Email);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.HasOne(d => d.EmailNavigation)
                    .WithOne(p => p.Administrator)
                    .HasForeignKey<Administrator>(d => d.Email)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Administrator_Email");
            });

            modelBuilder.Entity<Challenge>(entity =>
            {
                entity.HasKey(e => e.QuestionNumber);

                entity.Property(e => e.Answer)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Objetive).IsRequired();

                entity.Property(e => e.Question).IsRequired();
            });

            modelBuilder.Entity<NonAdmin>(entity =>
            {
                entity.HasKey(e => e.Email);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.HasOne(d => d.EmailNavigation)
                    .WithOne(p => p.NonAdmin)
                    .HasForeignKey<NonAdmin>(d => d.Email)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NonAdmin_Email");
            });

            modelBuilder.Entity<Progress>(entity =>
            {
                entity.HasKey(e => e.TableId);

                entity.Property(e => e.TableId).HasColumnName("TableID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.EmailNavigation)
                    .WithMany(p => p.Progress)
                    .HasForeignKey(d => d.Email)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Progress_Email");

                entity.HasOne(d => d.QuestionNumberNavigation)
                    .WithMany(p => p.Progress)
                    .HasForeignKey(d => d.QuestionNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Progress_QuestionNumber");
            });

            modelBuilder.Entity<UserCreds>(entity =>
            {
                entity.HasKey(e => e.Email);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Psswrd)
                    .IsRequired()
                    .HasMaxLength(50);
            });
        }
    }
}
