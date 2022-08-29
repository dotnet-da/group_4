using System.Text;
using Microsoft.EntityFrameworkCore;

namespace backend.Models
{
    public class BlogContext : DbContext
    {
        
        public DbSet<BlogModel.User> Users { get; set; }
        public DbSet<BlogModel.Post> Posts { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=db0f91pe.mariadb.hosting.zone;database=db0f91pe;user=db0f91pe_x81cegh;password=63V+qe-Bdf");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<BlogModel.User>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.Property(e => e.Name);
            });

            modelBuilder.Entity<BlogModel.Post>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.Property(e => e.Title);
                entity.Property(e => e.Content);
                entity.Property(e => e.AuthorID);
                entity.HasOne(p => p.Author)
                    .WithMany(u => u.Posts)
                    .HasForeignKey(p => p.AuthorID)
                    .HasConstraintName("IX_blog_posts_author");
            });
                  
        }
    }
}