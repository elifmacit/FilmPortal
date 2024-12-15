using FilmPortal.Core.Entities;
using FilmPortal.Core.Enums;
using Microsoft.EntityFrameworkCore;

namespace FilmPortal.Data.Context
{
    public class FilmPortalDbContext : DbContext
    {
        public FilmPortalDbContext(DbContextOptions<FilmPortalDbContext> options): base(options){}

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<MovieCategory> MovieCategories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<MovieReview> MovieReviews { get; set; }
        public DbSet<MovieLike> MovieLikes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(BaseEntity).IsAssignableFrom(entityType.ClrType))
                {
                    modelBuilder.Entity(entityType.ClrType)
                        .Property<DateTime>("CreatedDate")
                        .HasDefaultValueSql("GETUTCDATE()");

                    modelBuilder.Entity(entityType.ClrType)
                        .Property<DateTime?>("UpdatedDate");
                }
            }

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.ToTable("Movies");
                entity.Property(m => m.Title)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(m => m.Description)
                    .HasMaxLength(1000);

                entity.Property(m => m.ImdbRating)
                    .HasPrecision(3, 1);

                entity.Property(m => m.Picture)
                    .HasColumnType("TEXT");

                entity.Property(m => m.ReleaseDate)
                    .IsRequired();

                entity.HasOne(m => m.Director)
                    .WithMany(d => d.Movies)
                    .HasForeignKey(m => m.DirectorId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Director>(entity =>
            {
                entity.ToTable("Directors");
                entity.Property(d => d.FirstName)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(d => d.LastName)
                    .IsRequired()
                    .HasMaxLength(150);
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Categories");
                entity.Property(c => c.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<MovieCategory>(entity =>
            {
                entity.ToTable("MovieCategories");
                entity.HasKey(mc => new { mc.MovieId, mc.CategoryId });

                entity.HasOne(mc => mc.Movie)
                    .WithMany(m => m.MovieCategories)
                    .HasForeignKey(mc => mc.MovieId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(mc => mc.Category)
                    .WithMany(c => c.MovieCategories)
                    .HasForeignKey(mc => mc.CategoryId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("Users");
                entity.Property(u => u.Username)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(u => u.PasswordHash)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(u => u.PasswordSalt)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<MovieReview>(entity =>
            {
                entity.ToTable("MovieReviews");
                entity.Property(mr => mr.ReviewText)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.HasOne(mr => mr.Movie)
                    .WithMany(m => m.MovieReviews)
                    .HasForeignKey(mr => mr.MovieId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(mr => mr.User)
                    .WithMany(u => u.MovieReviews)
                    .HasForeignKey(mr => mr.UserId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<MovieLike>(entity =>
            {
                entity.ToTable("MovieLikes");
                entity.HasOne(ml => ml.Movie)
                    .WithMany(m => m.MovieLikes)
                    .HasForeignKey(ml => ml.MovieId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(ml => ml.User)
                    .WithMany(u => u.MovieLikes)
                    .HasForeignKey(ml => ml.UserId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            base.OnModelCreating(modelBuilder);
        }



    }
}
