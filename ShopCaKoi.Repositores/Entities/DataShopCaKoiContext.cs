﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ShopCaKoi.Repositores.Entities;

public partial class DataShopCaKoiContext : DbContext
{
    public DataShopCaKoiContext()
    {
    }

    public DataShopCaKoiContext(DbContextOptions<DataShopCaKoiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Booking> Bookings { get; set; }

    public virtual DbSet<CartItem> CartItems { get; set; }

    public virtual DbSet<ConsultingStaff> ConsultingStaffs { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<DeliveringStaff> DeliveringStaffs { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Feedback> Feedbacks { get; set; }

    public virtual DbSet<Koi> Kois { get; set; }

    public virtual DbSet<KoiFarm> KoiFarms { get; set; }

    public virtual DbSet<Manager> Managers { get; set; }

    public virtual DbSet<OrderKoi> OrderKois { get; set; }

    public virtual DbSet<OrderTrip> OrderTrips { get; set; }

    public virtual DbSet<Quotation> Quotations { get; set; }

    public virtual DbSet<SalesStaff> SalesStaffs { get; set; }

    public virtual DbSet<ShopCaKoiAccount> ShopCaKoiAccounts { get; set; }

    public virtual DbSet<Trip> Trips { get; set; }

    public virtual DbSet<ViewCartSummary> ViewCartSummaries { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-NOKPH3JU;Database=DataShopCaKoi;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Booking>(entity =>
        {
            entity.HasKey(e => e.BookingId).HasName("PK__Booking__C6D03BED77393426");

            entity.ToTable("Booking");

            entity.Property(e => e.BookingId)
                .HasMaxLength(50)
                .HasColumnName("bookingID");
            entity.Property(e => e.AccId)
                .HasMaxLength(50)
                .HasColumnName("AccID");
            entity.Property(e => e.ApprovedAt)
                .HasColumnType("datetime")
                .HasColumnName("approved_at");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CustomRequest)
                .HasColumnType("text")
                .HasColumnName("custom_request");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasDefaultValue("Pending")
                .HasColumnName("status");
            entity.Property(e => e.TripId)
                .HasMaxLength(50)
                .HasColumnName("tripID");

            entity.HasOne(d => d.Acc).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.AccId)
                .HasConstraintName("FK__Booking__AccID__6A30C649");

            entity.HasOne(d => d.Trip).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.TripId)
                .HasConstraintName("FK__Booking__tripID__6B24EA82");
        });

        modelBuilder.Entity<CartItem>(entity =>
        {
            entity.HasKey(e => e.CartItemId).HasName("PK__CartItem__488B0B0AC7FA3F0D");

            entity.ToTable("CartItem", tb => tb.HasTrigger("trg_UpdateQuantityOnDuplicateKoiId"));

            entity.Property(e => e.CartItemId)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.KoiId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("koiId");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("price");
            entity.Property(e => e.Total)
                .HasComputedColumnSql("([price]*[Quantity])", true)
                .HasColumnType("decimal(29, 2)");
        });

        modelBuilder.Entity<ConsultingStaff>(entity =>
        {
            entity.HasKey(e => e.Idnv).HasName("PK__Consulti__B87DC9B2E12780E6");

            entity.ToTable("ConsultingStaff");

            entity.Property(e => e.Idnv)
                .HasMaxLength(50)
                .HasColumnName("IDNV");
            entity.Property(e => e.AssignedCustomers)
                .HasColumnType("text")
                .HasColumnName("assignedCustomers");
            entity.Property(e => e.QuotationId)
                .HasMaxLength(50)
                .HasColumnName("quotationID");

            entity.HasOne(d => d.IdnvNavigation).WithOne(p => p.ConsultingStaff)
                .HasForeignKey<ConsultingStaff>(d => d.Idnv)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Consulting__IDNV__6C190EBB");

            entity.HasOne(d => d.Quotation).WithMany(p => p.ConsultingStaffs)
                .HasForeignKey(d => d.QuotationId)
                .HasConstraintName("FK_ConsultingStaff_Quotation");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__B611CB9D896513E7");

            entity.ToTable("Customer");

            entity.Property(e => e.CustomerId)
                .HasMaxLength(50)
                .HasColumnName("customerID");
            entity.Property(e => e.Address).HasMaxLength(200);
            entity.Property(e => e.CustomerPassword).HasMaxLength(50);
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Phone).HasMaxLength(15);
        });

        modelBuilder.Entity<DeliveringStaff>(entity =>
        {
            entity.HasKey(e => e.Idnv).HasName("PK__Deliveri__B87DC9B2E77EFF4B");

            entity.ToTable("DeliveringStaff");

            entity.Property(e => e.Idnv)
                .HasMaxLength(50)
                .HasColumnName("IDNV");
            entity.Property(e => e.AssignedDeliveries)
                .HasColumnType("text")
                .HasColumnName("assignedDeliveries");

            entity.HasOne(d => d.IdnvNavigation).WithOne(p => p.DeliveringStaff)
                .HasForeignKey<DeliveringStaff>(d => d.Idnv)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Delivering__IDNV__6E01572D");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Idnv);

            entity.ToTable("Employee");

            entity.Property(e => e.Idnv)
                .HasMaxLength(50)
                .HasColumnName("IDNV");
            entity.Property(e => e.NameNv)
                .HasMaxLength(100)
                .HasColumnName("NameNV");
            entity.Property(e => e.Role).HasMaxLength(50);
        });

        modelBuilder.Entity<Feedback>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Feedback__3213E83FDD799718");

            entity.ToTable("Feedback");

            entity.Property(e => e.Id)
                .HasMaxLength(50)
                .HasColumnName("id");
            entity.Property(e => e.Comment)
                .HasMaxLength(1000)
                .HasColumnName("comment");
            entity.Property(e => e.CustomerId)
                .HasMaxLength(50)
                .HasColumnName("customerID");
            entity.Property(e => e.Rating).HasColumnName("rating");

            entity.HasOne(d => d.Customer).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__Feedback__custom__6EF57B66");
        });

        modelBuilder.Entity<Koi>(entity =>
        {
            entity.HasKey(e => e.KoiId).HasName("PK__Koi__915924EF2CD37FAD");

            entity.ToTable("Koi");

            entity.Property(e => e.KoiId)
                .HasMaxLength(50)
                .HasColumnName("koiID");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("price");
            entity.Property(e => e.Size)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("size");
            entity.Property(e => e.Species)
                .HasMaxLength(50)
                .HasColumnName("species");
        });

        modelBuilder.Entity<KoiFarm>(entity =>
        {
            entity.HasKey(e => e.FarmId).HasName("PK_farm");

            entity.ToTable("KoiFarm");

            entity.Property(e => e.FarmId)
                .HasMaxLength(50)
                .HasColumnName("farm_id");
            entity.Property(e => e.ContactInfo)
                .HasMaxLength(100)
                .HasColumnName("contact_info");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.KoiId)
                .HasMaxLength(50)
                .HasColumnName("koiID");
            entity.Property(e => e.Location)
                .HasMaxLength(255)
                .HasColumnName("location");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");

            entity.HasOne(d => d.Koi).WithMany(p => p.KoiFarms)
                .HasForeignKey(d => d.KoiId)
                .HasConstraintName("FK_KoiFarm_Koi");
        });

        modelBuilder.Entity<Manager>(entity =>
        {
            entity.HasKey(e => e.Idnv).HasName("PK__Manager__B87DC9B2CF0147CB");

            entity.ToTable("Manager");

            entity.Property(e => e.Idnv)
                .HasMaxLength(50)
                .HasColumnName("IDNV");
            entity.Property(e => e.PendingQuotations).HasColumnName("pendingQuotations");
            entity.Property(e => e.QuotationId)
                .HasMaxLength(50)
                .HasColumnName("quotationID");

            entity.HasOne(d => d.IdnvNavigation).WithOne(p => p.Manager)
                .HasForeignKey<Manager>(d => d.Idnv)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Manager__IDNV__70DDC3D8");

            entity.HasOne(d => d.Quotation).WithMany(p => p.Managers)
                .HasForeignKey(d => d.QuotationId)
                .HasConstraintName("FK_Manager_Quotation");
        });

        modelBuilder.Entity<OrderKoi>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__OrderKoi__0809337D2DCC965B");

            entity.ToTable("OrderKoi");

            entity.Property(e => e.OrderId)
                .HasMaxLength(50)
                .HasColumnName("orderID");
            entity.Property(e => e.CustomerId)
                .HasMaxLength(50)
                .HasColumnName("customerID");
            entity.Property(e => e.KoiId)
                .HasMaxLength(50)
                .HasColumnName("koiID");
            entity.Property(e => e.OrderDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("orderDate");
            entity.Property(e => e.PaymentStatus)
                .HasMaxLength(50)
                .HasColumnName("paymentStatus");
            entity.Property(e => e.QuotationId)
                .HasMaxLength(50)
                .HasColumnName("quotationID");

            entity.HasOne(d => d.Customer).WithMany(p => p.OrderKois)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__OrderKoi__custom__72C60C4A");

            entity.HasOne(d => d.Quotation).WithMany(p => p.OrderKois)
                .HasForeignKey(d => d.QuotationId)
                .HasConstraintName("FK_OrderKoi_Quotation");
        });

        modelBuilder.Entity<OrderTrip>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__OrderTri__C3905BAF7BD5C8EB");

            entity.ToTable("OrderTrip");

            entity.Property(e => e.OrderId)
                .HasMaxLength(50)
                .HasColumnName("OrderID");
            entity.Property(e => e.CustomerId)
                .HasMaxLength(50)
                .HasColumnName("customerID");
            entity.Property(e => e.OrderDate).HasColumnName("orderDate");
            entity.Property(e => e.PaymentStatus)
                .HasMaxLength(50)
                .HasColumnName("paymentStatus");
            entity.Property(e => e.QuotationId)
                .HasMaxLength(50)
                .HasColumnName("quotationID");
            entity.Property(e => e.TripId)
                .HasMaxLength(50)
                .HasColumnName("tripID");

            entity.HasOne(d => d.Customer).WithMany(p => p.OrderTrips)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__OrderTrip__custo__74AE54BC");

            entity.HasOne(d => d.Quotation).WithMany(p => p.OrderTrips)
                .HasForeignKey(d => d.QuotationId)
                .HasConstraintName("FK__OrderTrip__quota__75A278F5");

            entity.HasOne(d => d.Trip).WithMany(p => p.OrderTrips)
                .HasForeignKey(d => d.TripId)
                .HasConstraintName("FK__OrderTrip__tripI__76969D2E");
        });

        modelBuilder.Entity<Quotation>(entity =>
        {
            entity.HasKey(e => e.QuotationId).HasName("PK__Quotatio__7536E3723E29A21C");

            entity.ToTable("Quotation");

            entity.Property(e => e.QuotationId)
                .HasMaxLength(50)
                .HasColumnName("quotationID");
            entity.Property(e => e.Amount)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("amount");
            entity.Property(e => e.ApproveStatus)
                .HasMaxLength(50)
                .HasColumnName("approveStatus");
            entity.Property(e => e.OrderId)
                .HasMaxLength(50)
                .HasColumnName("orderID");
        });

        modelBuilder.Entity<SalesStaff>(entity =>
        {
            entity.HasKey(e => e.Idnv).HasName("PK__SalesSta__B87DC9B2E644AA6F");

            entity.ToTable("SalesStaff");

            entity.Property(e => e.Idnv)
                .HasMaxLength(50)
                .HasColumnName("IDNV");
            entity.Property(e => e.AssignedOrders).HasColumnName("assignedOrders");
            entity.Property(e => e.QuotationId)
                .HasMaxLength(50)
                .HasColumnName("quotationID");

            entity.HasOne(d => d.IdnvNavigation).WithOne(p => p.SalesStaff)
                .HasForeignKey<SalesStaff>(d => d.Idnv)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SalesStaff__IDNV__778AC167");

            entity.HasOne(d => d.Quotation).WithMany(p => p.SalesStaffs)
                .HasForeignKey(d => d.QuotationId)
                .HasConstraintName("FK_SalesStaff_Quotation");
        });

        modelBuilder.Entity<ShopCaKoiAccount>(entity =>
        {
            entity.HasKey(e => e.AccId).HasName("PK__ShopCaKo__91CBC398D886D4B0");

            entity.ToTable("ShopCaKoiAccount");

            entity.HasIndex(e => e.EmailAddress, "UQ__ShopCaKo__49A1474063BF7DDA").IsUnique();

            entity.Property(e => e.AccId)
                .HasMaxLength(50)
                .HasColumnName("AccID");
            entity.Property(e => e.Description).HasMaxLength(140);
            entity.Property(e => e.EmailAddress).HasMaxLength(90);
            entity.Property(e => e.Password).HasMaxLength(90);
        });

        modelBuilder.Entity<Trip>(entity =>
        {
            entity.HasKey(e => e.TripId).HasName("PK_tour");

            entity.ToTable("Trip");

            entity.Property(e => e.TripId)
                .HasMaxLength(50)
                .HasColumnName("tripID");
            entity.Property(e => e.ArrivalDate).HasColumnName("arrivalDate");
            entity.Property(e => e.DepartureDate).HasColumnName("departureDate");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.FarmId)
                .HasMaxLength(50)
                .HasColumnName("farm_id");
            entity.Property(e => e.KoiId)
                .HasMaxLength(50)
                .HasColumnName("koiID");
            entity.Property(e => e.Price).HasColumnName("price");

            entity.HasOne(d => d.Farm).WithMany(p => p.Trips)
                .HasForeignKey(d => d.FarmId)
                .HasConstraintName("FK_Trip_KoiFarm");
        });

        modelBuilder.Entity<ViewCartSummary>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("ViewCartSummary");

            entity.Property(e => e.TotalAmount).HasColumnType("decimal(38, 2)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
