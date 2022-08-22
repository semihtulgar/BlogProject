using Microsoft.EntityFrameworkCore;

namespace BlogProject.Models
{
    public class BlogDbContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<Category> Categories { get; set; }

        public BlogDbContext(DbContextOptions<BlogDbContext> options):base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>()
                .HasOne<Category>(p => p.Category)
                .WithMany(c => c.Posts)
                .HasForeignKey(p => p.CategoryID);

            modelBuilder.Entity<Category>()
                .HasMany<Post>(c => c.Posts)
                .WithOne(p => p.Category)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Post>().Property<DateTime>("CreatedDate");
            modelBuilder.Entity<Post>().Property<DateTime>("UpdatedDate");

        }

        public override int SaveChanges()
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e =>
                        e.State == EntityState.Added
                        || e.State == EntityState.Modified);

            foreach (var entityEntry in entries)
            {
                entityEntry.Property("UpdatedDate").CurrentValue = DateTime.Now;

                if (entityEntry.State == EntityState.Added)
                {
                    entityEntry.Property("CreatedDate").CurrentValue = DateTime.Now;
                }
            }

            return base.SaveChanges();
        }



    }
}
