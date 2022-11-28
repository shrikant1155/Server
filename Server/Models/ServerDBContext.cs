using Microsoft.EntityFrameworkCore;

namespace Server.Models
{
    public class ServerDBContext : DbContext
    {
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<AdminUser> AdminUser { get; set; }
        public ServerDBContext(DbContextOptions<ServerDBContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>().ToTable("Employee");
            modelBuilder.Entity<Department>().ToTable("Department");
            modelBuilder.Entity<AdminUser>().ToTable("AdminUser");
            modelBuilder.Entity<Employee>()
                .HasKey(b => b.ID).HasName("ID");
            modelBuilder.Entity<Department>()
                .HasKey(b => b.ID).HasName("ID");
            modelBuilder.Entity<AdminUser>()
                .HasKey(b => b.ID).HasName("ID");
        }
    }
}
