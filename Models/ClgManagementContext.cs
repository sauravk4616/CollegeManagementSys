using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CollegeManagementSystem.Models
{
    public partial class ClgManagementContext : DbContext
    {
        public ClgManagementContext()
        {
        }

        public ClgManagementContext(DbContextOptions<ClgManagementContext> options)
            : base(options)
        {
        }

        public virtual DbSet<SemesterFee> SemesterFee { get; set; }
        public virtual DbSet<Student> Student { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.;Database=ClgManagement;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SemesterFee>(entity =>
            {
                entity.HasKey(e => e.Semester);

                entity.Property(e => e.Semester).ValueGeneratedNever();
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.EnrollmentNo);

                entity.Property(e => e.EnrollmentNo)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Branch)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.StudentName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.SemesterNavigation)
                    .WithMany(p => p.Student)
                    .HasForeignKey(d => d.Semester)
                    .HasConstraintName("fk_inv_Semester");
            });
        }
    }
}
