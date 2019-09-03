using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace P1.Data.Entities
{
    public partial class p1Context : DbContext
    {
        public p1Context()
        {
        }

        public p1Context(DbContextOptions<p1Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Crust> Crust { get; set; }
        public virtual DbSet<CustomPizza> CustomPizza { get; set; }
        public virtual DbSet<Location> Location { get; set; }
        public virtual DbSet<Name> Name { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<PresetPizza> PresetPizza { get; set; }
        public virtual DbSet<Recipe> Recipe { get; set; }
        public virtual DbSet<Size> Size { get; set; }
        public virtual DbSet<Topping> Topping { get; set; }
        public virtual DbSet<Toppings> Toppings { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:p1.database.windows.net,1433;Initial Catalog=p1;Persist Security Info=False;User ID=sqladmin;Password=Password12345;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Crust>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Price).HasColumnType("money");
            });

            modelBuilder.Entity<CustomPizza>(entity =>
            {
                entity.HasOne(d => d.Crust)
                    .WithMany(p => p.CustomPizza)
                    .HasForeignKey(d => d.CrustId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CrustId");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.CustomPizza)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderId");

                entity.HasOne(d => d.Size)
                    .WithMany(p => p.CustomPizza)
                    .HasForeignKey(d => d.SizeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SizeId");

                entity.HasOne(d => d.Toppings)
                    .WithMany(p => p.CustomPizza)
                    .HasForeignKey(d => d.ToppingsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ToppingsId");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.Property(e => e.Province)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Street)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Town)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Name>(entity =>
            {
                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.Date).HasColumnType("date");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LocationId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserId");
            });

            modelBuilder.Entity<Recipe>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Size>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Price).HasColumnType("money");
            });

            modelBuilder.Entity<Topping>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Price).HasColumnType("money");
            });

            modelBuilder.Entity<Toppings>(entity =>
            {
                entity.Property(e => e.List)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.Property(e => e.Price).HasColumnType("money");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.HasOne(d => d.Name)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.NameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NameId");
            });
        }
    }
}
