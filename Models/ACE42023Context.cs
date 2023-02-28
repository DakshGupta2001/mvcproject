using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace EmployeeManagement2.Models
{
    public partial class ACE42023Context : DbContext
    {
        public ACE42023Context()
        {
        }

        public ACE42023Context(DbContextOptions<ACE42023Context> options)
            : base(options)
        {
        }

        public virtual DbSet<SuneetDept> SuneetDepts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DEVSQL.corp.local;Database=ACE 4- 2023;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<SuneetDept>(entity =>
            {
                entity.HasKey(e => e.DeptId)
                    .HasName("PK__Suneet_D__0148818EA754B5DB");

                entity.ToTable("Suneet_Dept");

                entity.Property(e => e.DeptId)
                    .ValueGeneratedNever()
                    .HasColumnName("DeptID");

                entity.Property(e => e.Dname)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NoOfEmployees).HasColumnName("No_of_Employees");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
