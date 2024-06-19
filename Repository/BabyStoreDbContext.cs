using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Entities;
namespace Repository;

public partial class BabyStoreDbContext : DbContext
{
    public BabyStoreDbContext()
    {
    }

    public BabyStoreDbContext(DbContextOptions<BabyStoreDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderItem> OrderItems { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=srv2\\PUPILS;Initial Catalog=BabyStore__DB;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.Entity<Category>(entity =>
        //{
        //    entity.Property(e => e.CategoryName)
        //        .HasMaxLength(20)
        //        .IsFixedLength();
        //});

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasOne(d => d.User).WithMany(p => p.Orders)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderUser");
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.HasOne(d => d.Order).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderItemOrder");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderProduct");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(200)
                .IsFixedLength();
            entity.Property(e => e.ProductName)
                .HasMaxLength(10)
                .IsFixedLength();

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CategoryProduct");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.Email)
                .HasMaxLength(20)
                .IsFixedLength();
            entity.Property(e => e.FirstName)
                .HasMaxLength(15)
                .IsFixedLength();
            entity.Property(e => e.LastName)
                .HasMaxLength(15)
                .IsFixedLength();
            entity.Property(e => e.Password)
                .HasMaxLength(20)
                .IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
