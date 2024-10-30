using C_BackendEntity.Model;
using Microsoft.EntityFrameworkCore;

namespace C_BackendEntity.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<AccountModel> AccountModel { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Customize Account entity mapping
            modelBuilder.Entity<AccountModel>(entity =>
            {
                // Set table name (if you want a custom name)
                entity.ToTable("AccountModel");

                entity.HasKey(a => a.Id);
                // Configure Email property
                entity.Property(a => a.Email)
                    .IsRequired() // Make Email required
                    .HasMaxLength(100); // Limit length for Email

                // Configure Password property
                entity.Property(a => a.Password)
                    .IsRequired() 
                    .HasMaxLength(255);

                entity.Property(a => a.FirstName)
                    .IsRequired() 
                    .HasMaxLength(100);

                entity.Property(a => a.LastName)
                    .IsRequired() 
                    .HasMaxLength(100);

            });
        }
    }
}