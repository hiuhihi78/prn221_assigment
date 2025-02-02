﻿using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace WPF_Project.Models;

public partial class ShopDbContext : DbContext
{
	public ShopDbContext()
	{
	}

	public ShopDbContext(DbContextOptions<ShopDbContext> options)
		: base(options)
	{
	}

	public virtual DbSet<Category> Categories { get; set; }

	public virtual DbSet<Import> Imports { get; set; }

	public virtual DbSet<ImportDetail> ImportDetails { get; set; }

	public virtual DbSet<Order> Orders { get; set; }

	public virtual DbSet<OrderDetail> OrderDetails { get; set; }

	public virtual DbSet<Product> Products { get; set; }

	public virtual DbSet<Role> Roles { get; set; }

	public virtual DbSet<Staff> Staff { get; set; }

	public virtual DbSet<Supplier> Suppliers { get; set; }

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		var conf = new ConfigurationBuilder()
			.SetBasePath(Directory.GetCurrentDirectory())
			.AddJsonFile("appsettings.json", true, true)
			.Build();
		if (!optionsBuilder.IsConfigured)
		{
			optionsBuilder.UseSqlServer(conf.GetConnectionString("PRNDB"));

		}

	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Category>(entity =>
		{
			entity.ToTable("Category");

			entity.Property(e => e.Id).HasColumnName("id");
			entity.Property(e => e.Name)
				.HasMaxLength(50)
				.HasColumnName("name");
		});

		modelBuilder.Entity<Import>(entity =>
		{
			entity.ToTable("Import");

			entity.Property(e => e.Id).HasColumnName("id");
			entity.Property(e => e.ImportDate)
				.HasColumnType("date")
				.HasColumnName("import_Date");
			entity.Property(e => e.StaffId).HasColumnName("staffID");
			entity.Property(e => e.SupplierId).HasColumnName("supplierId");
			entity.Property(e => e.TotalAmount).HasColumnName("totalAmount");

			entity.HasOne(d => d.Staff).WithMany(p => p.Imports)
				.HasForeignKey(d => d.StaffId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_Import_Staff");

			entity.HasOne(d => d.Supplier).WithMany(p => p.Imports)
				.HasForeignKey(d => d.SupplierId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_Import_Supplier");
		});

		modelBuilder.Entity<ImportDetail>(entity =>
		{
			entity.HasKey(e => new { e.ImportId, e.ProductId });

			entity.Property(e => e.ImportId).HasColumnName("importID");
			entity.Property(e => e.ProductId).HasColumnName("productID");
			entity.Property(e => e.PriceImport).HasColumnName("price_import");
			entity.Property(e => e.Quantity).HasColumnName("quantity");

			entity.HasOne(d => d.Import).WithMany(p => p.ImportDetails)
				.HasForeignKey(d => d.ImportId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_ImportDetails_Import");

			entity.HasOne(d => d.Product).WithMany(p => p.ImportDetails)
				.HasForeignKey(d => d.ProductId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_ImportDetails_Product");
		});

		modelBuilder.Entity<Order>(entity =>
		{
			entity.Property(e => e.Id).HasColumnName("id");
			entity.Property(e => e.CustomerAddress).HasColumnName("customerAddress");
			entity.Property(e => e.CustomerName)
				.HasMaxLength(150)
				.HasColumnName("customerName");
			entity.Property(e => e.CustomerPhone)
				.HasMaxLength(50)
				.HasColumnName("customerPhone");
			entity.Property(e => e.DeliverDate)
				.HasColumnType("datetime")
				.HasColumnName("deliverDate");
			entity.Property(e => e.OrderDate)
				.HasColumnType("datetime")
				.HasColumnName("orderDate");
			entity.Property(e => e.StaffId).HasColumnName("staffID");
			entity.Property(e => e.TotalAmount).HasColumnName("totalAmount");

			entity.HasOne(d => d.Staff).WithMany(p => p.Orders)
				.HasForeignKey(d => d.StaffId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_Orders_Staff");
		});

		modelBuilder.Entity<OrderDetail>(entity =>
		{
			entity.HasKey(e => new { e.OrderId, e.ProductId });

			entity.Property(e => e.OrderId).HasColumnName("orderID");
			entity.Property(e => e.ProductId).HasColumnName("productID");
			entity.Property(e => e.Discount).HasColumnName("discount");
			entity.Property(e => e.Quantity).HasColumnName("quantity");
			entity.Property(e => e.SellPrice).HasColumnName("sellPrice");

			entity.HasOne(d => d.Order).WithMany(p => p.OrderDetails)
				.HasForeignKey(d => d.OrderId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_OrderDetails_Orders");

			entity.HasOne(d => d.Product).WithMany(p => p.OrderDetails)
				.HasForeignKey(d => d.ProductId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_OrderDetails_Product");
		});

		modelBuilder.Entity<Product>(entity =>
		{
			entity.ToTable("Product");

			entity.Property(e => e.Id).HasColumnName("id");
			entity.Property(e => e.CategoryId).HasColumnName("categoryID");
			entity.Property(e => e.Country).HasColumnName("country");
			entity.Property(e => e.Description).HasColumnName("description");
			entity.Property(e => e.Discount).HasColumnName("discount");
			entity.Property(e => e.Name)
				.HasMaxLength(50)
				.HasColumnName("name");
			entity.Property(e => e.Price).HasColumnName("price");
			entity.Property(e => e.Quantity).HasColumnName("quantity");

			entity.HasOne(d => d.Category).WithMany(p => p.Products)
				.HasForeignKey(d => d.CategoryId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_Product_Category");
		});

		modelBuilder.Entity<Role>(entity =>
		{
			entity.ToTable("Role");

			entity.Property(e => e.Id).HasColumnName("id");
			entity.Property(e => e.Name)
				.HasMaxLength(50)
				.HasColumnName("name");
		});

		modelBuilder.Entity<Staff>(entity =>
		{
			entity.Property(e => e.Id).HasColumnName("id");
			entity.Property(e => e.Address).HasColumnName("address");
			entity.Property(e => e.Fullname)
				.HasMaxLength(150)
				.HasColumnName("fullname");
			entity.Property(e => e.Password)
				.HasMaxLength(50)
				.HasColumnName("password");
			entity.Property(e => e.Phone)
				.HasMaxLength(50)
				.HasColumnName("phone");
			entity.Property(e => e.Role).HasColumnName("role");
			entity.Property(e => e.Status).HasColumnName("status");
			entity.Property(e => e.Username)
				.HasMaxLength(50)
				.HasColumnName("username");

			entity.HasOne(d => d.RoleNavigation).WithMany(p => p.Staff)
				.HasForeignKey(d => d.Role)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_Staff_Role");
		});

		modelBuilder.Entity<Supplier>(entity =>
		{
			entity.ToTable("Supplier");

			entity.Property(e => e.Id).HasColumnName("id");
			entity.Property(e => e.Address).HasColumnName("address");
			entity.Property(e => e.Name)
				.HasMaxLength(100)
				.HasColumnName("name");
			entity.Property(e => e.Phone)
				.HasMaxLength(10)
				.IsFixedLength()
				.HasColumnName("phone");
		});

		OnModelCreatingPartial(modelBuilder);
	}

	partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
