using System.Text;
using Microsoft.EntityFrameworkCore;

namespace backend.Models
{
    public partial class BlogContext : DbContext
    {
        
        public virtual DbSet<BlogModel.User> Users { get; set; }
        public virtual DbSet<BlogModel.Post> Posts { get; set; }

        public BlogContext()
        {
        }

        public BlogContext(DbContextOptions<BlogContext> options) : base(options)
        {
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