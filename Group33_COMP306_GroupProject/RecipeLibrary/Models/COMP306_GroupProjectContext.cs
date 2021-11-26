using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace RecipeLibrary.Models
{
    public partial class COMP306_GroupProjectContext : DbContext
    {
        public COMP306_GroupProjectContext()
        {
        }

        public COMP306_GroupProjectContext(DbContextOptions<COMP306_GroupProjectContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Ingredient> Ingredients { get; set; }
        public virtual DbSet<Recipe> Recipes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=COMP306_GroupProject;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Ingredient>(entity =>
            {
                entity.ToTable("Ingredient");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.IngredientAmount)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.IngredientName)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.HasOne(d => d.Recipe)
                    .WithMany(p => p.Ingredients)
                    .HasForeignKey(d => d.RecipeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Recipe_RecipeId");

                //entity.HasOne<Recipe>(i => i.Recipe).WithMany(r => r.Ingredients);
            });

            modelBuilder.Entity<Recipe>(entity =>
            {
                entity.ToTable("Recipe");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AuthorId)
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(3000)
                    .IsUnicode(false);

                entity.Property(e => e.ImageIrl)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.RecipeName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.RecipeType)
                    .HasMaxLength(30)
                    .IsUnicode(false);
                
                //entity.HasMany<Ingredient>(r => r.Ingredients).WithOne(i => i.Recipe).OnDelete(DeleteBehavior.SetNull);

                //entity.HasMany<Ingredient>(r => r.Ingredients).WithOne(i => i.Recipe);
            });



            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
