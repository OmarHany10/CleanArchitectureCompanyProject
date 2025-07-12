using CompanyProject.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CompanyProject.Infrustructure.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext() { }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<ApplicationUser> applicationUsers { get; set; }
        public DbSet<Employee> employees { get; set; }
        public DbSet<Department> departments { get; set; }
        public DbSet<Project> projects { get; set; }
        public DbSet<EmployeeProject> employeeProjects { get; set; }
        public DbSet<DepartmentProject> departmentProjects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<DepartmentProject>()
                .HasKey(dp => new { dp.ProjectId, dp.DepartmentId });

            modelBuilder.Entity<EmployeeProject>()
                .HasKey(ep => new { ep.ProjectId, ep.EmployeeId });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasMany(d => d.ProjectLeaders)
                .WithOne(pl => pl.Department)
                .HasForeignKey(pl => pl.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.LeaderManger)
                .WithOne(pl => pl.DepartmentManger)
                .HasForeignKey<Department>(d => d.LeaderMangerId)
                .OnDelete(DeleteBehavior.Restrict);

            });

            modelBuilder.Entity<ProjectLeader>(entity =>
            {
                entity.HasOne(pl => pl.Supervisor)
                .WithMany(pl => pl.Subordinates)
                .HasForeignKey(pl => pl.SupervisorId)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(pl => pl.Projects)
                .WithOne(p => p.ProjectLeader)
                .HasForeignKey(p => p.ProjectLeaderId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
