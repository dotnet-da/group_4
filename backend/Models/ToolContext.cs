using System;
using Microsoft.EntityFrameworkCore;
using static backend.Models.ToolModel;

namespace backend.Models
{
    public partial class ToolContext : DbContext
    {
        public virtual DbSet<ToolModel.Player> Players { get; set; }
        public virtual DbSet<ToolModel.Entry> Entries { get; set; }
        public virtual DbSet<ToolModel.Type> Types { get; set; }
        public virtual DbSet<ToolModel.Collection> Collections { get; set; }

        public ToolContext()
        {
        }

        public ToolContext(DbContextOptions<ToolContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entry>(entity =>
            {
                entity.HasKey(e => new { e.CollectionId, e.TypeId })
                    .HasName("PRIMARY");

                entity.ToTable("tool_entries");

                entity.HasIndex(e => e.CollectionId, "collection_id");
                entity.HasIndex(e => e.TypeId, "type_id");
                
                entity.Property(e => e.CollectionId)
                    .HasColumnType("int(11)")
                    .HasColumnName("collection_id");

                entity.Property(e => e.TypeId)
                    .HasColumnType("int(11)")
                    .HasColumnName("type_id");


                entity.Property(e => e.Value)
                    .HasColumnType("int(11)")
                    .HasColumnName("value")
                    .HasDefaultValueSql("'0'");

                entity.HasOne(d => d.CollectionNavigation)
                    .WithMany(p => p.Entries)
                    .HasForeignKey(d => d.CollectionId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("entries_ibfk_1");

                entity.HasOne(d => d.TypeNavigation)
                    .WithMany(p => p.Entries)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("entries_ibfk_2");
            });

            modelBuilder.Entity<Player>(entity =>
            {
                entity.ToTable("tool_players");
                
                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(16)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<ToolModel.Type>(entity =>
            {
                entity.ToTable("tool_types");

                entity.HasIndex(e => e.Identifier, "identifier")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Identifier)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("identifier");
                
                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .HasColumnName("description");
            });
            
            modelBuilder.Entity<Collection>(entity =>
            {
                entity.ToTable("tool_collections");
                
                entity.HasIndex(e => e.PlayerId, "player_id");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.PlayerId)
                    .HasColumnType("int(11)")
                    .HasColumnName("player_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP()");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}