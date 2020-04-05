using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace project1.data.Entities
{
    public partial class restaurantContext : DbContext
    {
        public restaurantContext()
        {
        }

        public restaurantContext(DbContextOptions<restaurantContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Food> Food { get; set; }
        public virtual DbSet<FoodOrder> FoodOrder { get; set; }
        public virtual DbSet<Inventory> Inventory { get; set; }
        public virtual DbSet<Location> Location { get; set; }
        public virtual DbSet<OrderItem> OrderItem { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("DbConnect");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.Name)
                    .HasName("PK__customer__72E12F1A27459E5C");

                entity.ToTable("customer", "rest");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(20);

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(50);

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Storenum).HasColumnName("storenum");

                entity.HasOne(d => d.StorenumNavigation)
                    .WithMany(p => p.Customer)
                    .HasForeignKey(d => d.Storenum)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__customer__storen__5441852A");
            });

            modelBuilder.Entity<Food>(entity =>
            {
                entity.HasKey(e => e.Name)
                    .HasName("PK__food__72E12F1ADFCDA293");

                entity.ToTable("food", "rest");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(20);

                entity.Property(e => e.Foodtype)
                    .HasColumnName("foodtype")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("smallmoney");
            });

            modelBuilder.Entity<FoodOrder>(entity =>
            {
                entity.HasKey(e => e.Ordernum)
                    .HasName("PK__foodOrde__725C7E1250FC4FE8");

                entity.ToTable("foodOrder", "rest");

                entity.Property(e => e.Ordernum)
                    .HasColumnName("ordernum")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(20);

                entity.Property(e => e.Ordertime)
                    .HasColumnName("ordertime")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.NameNavigation)
                    .WithMany(p => p.FoodOrder)
                    .HasForeignKey(d => d.Name)
                    .HasConstraintName("FK__foodOrder__name__4D94879B");
            });

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.HasKey(e => new { e.Storenum, e.Item })
                    .HasName("PK__inventor__EF27FEF09F5452C0");

                entity.ToTable("inventory", "rest");

                entity.Property(e => e.Storenum).HasColumnName("storenum");

                entity.Property(e => e.Item)
                    .HasColumnName("item")
                    .HasMaxLength(15);

                entity.Property(e => e.Quantity)
                    .HasColumnName("quantity")
                    .HasColumnType("decimal(12, 2)");

                entity.HasOne(d => d.StorenumNavigation)
                    .WithMany(p => p.Inventory)
                    .HasForeignKey(d => d.Storenum)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__inventory__store__6383C8BA");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.HasKey(e => e.Storenum)
                    .HasName("PK__location__46BC76D248A39D37");

                entity.ToTable("location", "rest");

                entity.Property(e => e.Storenum).HasColumnName("storenum");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.HasKey(e => new { e.Ordernum, e.Item })
                    .HasName("PK__orderIte__DBC7F630D7183031");

                entity.ToTable("orderItem", "rest");

                entity.Property(e => e.Ordernum).HasColumnName("ordernum");

                entity.Property(e => e.Item)
                    .HasColumnName("item")
                    .HasMaxLength(20);

                entity.HasOne(d => d.ItemNavigation)
                    .WithMany(p => p.OrderItem)
                    .HasForeignKey(d => d.Item)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__orderItem__item__5165187F");

                entity.HasOne(d => d.OrdernumNavigation)
                    .WithMany(p => p.OrderItem)
                    .HasForeignKey(d => d.Ordernum)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__orderItem__order__5070F446");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
