using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TravelManagementSystem.Models
{
    public partial class TravelManagementSystemContext : DbContext
    {
        public TravelManagementSystemContext()
        {
        }

        public TravelManagementSystemContext(DbContextOptions<TravelManagementSystemContext> options)
            : base(options)
        {
        }

        public virtual DbSet<EmployeeRegistration> EmployeeRegistration { get; set; }
        public virtual DbSet<ProjectTable> ProjectTable { get; set; }
        public virtual DbSet<RequestTable> RequestTable { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Users> Users { get; set; }

       /* protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(" Data Source=DESKTOP-47COLR8\\RASHMINAYAK;Initial Catalog=TravelManagementSystem;Integrated Security=True ");
            }
        }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeRegistration>(entity =>
            {
                entity.HasKey(e => e.EmpId)
                    .HasName("PK__Employee__AF2DBB99DBE4F430");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.LId).HasColumnName("L_Id");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNo).HasColumnType("numeric(10, 0)");

                entity.HasOne(d => d.L)
                    .WithMany(p => p.EmployeeRegistration)
                    .HasForeignKey(d => d.LId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EmployeeRe__L_Id__2A4B4B5E");
            });

            modelBuilder.Entity<ProjectTable>(entity =>
            {
                entity.HasKey(e => e.ProjectId)
                    .HasName("PK__ProjectT__BC90FC370570F4C8");

                entity.Property(e => e.ProjectId).HasColumnName("project_Id");

                entity.Property(e => e.ProjectName)
                    .IsRequired()
                    .HasColumnName("projectName")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RequestTable>(entity =>
            {
                entity.HasKey(e => e.RequestId)
                    .HasName("PK__RequestT__18D3B90FDE74BC9C");

                entity.Property(e => e.RequestId).HasColumnName("request_id");

                entity.Property(e => e.CauseTravel)
                    .IsRequired()
                    .HasColumnName("cause_travel")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Destination)
                    .IsRequired()
                    .HasColumnName("destination")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.FromDate)
                    .HasColumnName("from_date")
                    .HasColumnType("date");

                entity.Property(e => e.Mode)
                    .IsRequired()
                    .HasColumnName("mode")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NoDays)
                    .HasColumnName("no_days")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Priority)
                    .HasColumnName("priority")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ProjectId).HasColumnName("project_Id");

                entity.Property(e => e.Source)
                    .IsRequired()
                    .HasColumnName("source")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ToDate)
                    .HasColumnName("to_date")
                    .HasColumnType("date");

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.RequestTable)
                    .HasForeignKey(d => d.EmpId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__RequestTa__EmpId__300424B4");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.RequestTable)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__RequestTa__proje__2F10007B");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("role");

                entity.HasIndex(e => e.Role1)
                    .HasName("UQ__role__863D2148471B33C0")
                    .IsUnique();

                entity.Property(e => e.RoleId).HasColumnName("roleId");

                entity.Property(e => e.Role1)
                    .HasColumnName("role")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.LId)
                    .HasName("PK__Users__420BA17E55177674");

                entity.Property(e => e.LId).HasColumnName("L_Id");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.RoleId).HasColumnName("roleId");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasColumnName("userName")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Users__roleId__276EDEB3");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
