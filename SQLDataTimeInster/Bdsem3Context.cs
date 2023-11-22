using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SQLDataTimeInster;

public partial class Bdsem3Context : DbContext
{
    public Bdsem3Context()
    {
    }

    public Bdsem3Context(DbContextOptions<Bdsem3Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Building> Buildings { get; set; }

    public virtual DbSet<FacilitiesAvailabilityHistory> FacilitiesAvailabilityHistories { get; set; }

    public virtual DbSet<FacilitiesType> FacilitiesTypes { get; set; }

    public virtual DbSet<Facility> Facilities { get; set; }

    public virtual DbSet<FacilityReservation> FacilityReservations { get; set; }

    public virtual DbSet<FeedBack> FeedBacks { get; set; }

    public virtual DbSet<Guest> Guests { get; set; }

    public virtual DbSet<Lux> Luxes { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<RegulaService> RegulaServices { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<RoomAvailabilityHistory> RoomAvailabilityHistories { get; set; }

    public virtual DbSet<RoomReservation> RoomReservations { get; set; }

    public virtual DbSet<RoomService> RoomServices { get; set; }

    public virtual DbSet<RoomServicesCatalog> RoomServicesCatalogs { get; set; }

    public virtual DbSet<RoomType> RoomTypes { get; set; }

    public virtual DbSet<SeasonPrice> SeasonPrices { get; set; }

    public virtual DbSet<SensorsDatum> SensorsData { get; set; }

    public virtual DbSet<Staff> Staff { get; set; }

    public virtual DbSet<StockKeepingUnit> StockKeepingUnits { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server= LAPTOP-J5R1H9E6; Database=BDSem3; Trusted_Connection=True; Trust Server Certificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Building>(entity =>
        {
            entity
                .ToTable("Building")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("BuildingHistory", "dbo");
                        ttb
                            .HasPeriodStart("ValidFrom")
                            .HasColumnName("ValidFrom");
                        ttb
                            .HasPeriodEnd("ValidTo")
                            .HasColumnName("ValidTo");
                    }));

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Adress)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("adress");
        });

        modelBuilder.Entity<FacilitiesAvailabilityHistory>(entity =>
        {
            entity.ToTable("FacilitiesAvailabilityHistory", tb => tb.HasTrigger("INSERT_date"));

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FacilitiesId).HasColumnName("facilities_id");
            entity.Property(e => e.IsAvailable).HasColumnName("isAvailable");
            entity.Property(e => e.WritingDate).HasColumnName("writingDate");

            entity.HasOne(d => d.Facilities).WithMany(p => p.FacilitiesAvailabilityHistories)
                .HasForeignKey(d => d.FacilitiesId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FacilitiesAvailabilityHistory_Facilities");
        });

        modelBuilder.Entity<FacilitiesType>(entity =>
        {
            entity.ToTable("FacilitiesType");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Type)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("type");
        });

        modelBuilder.Entity<Facility>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FacilitiesTypeId).HasColumnName("facilitiesType_id");
            entity.Property(e => e.StockKeepingUnitId).HasColumnName("stockKeepingUnit_id");

            entity.HasOne(d => d.FacilitiesType).WithMany(p => p.Facilities)
                .HasForeignKey(d => d.FacilitiesTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Facilities_FacilitiesType");

            entity.HasOne(d => d.StockKeepingUnit).WithMany(p => p.Facilities)
                .HasForeignKey(d => d.StockKeepingUnitId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Facilities_StockKeepingUnit");
        });

        modelBuilder.Entity<FacilityReservation>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FacilityId).HasColumnName("facility_id");
            entity.Property(e => e.GuestId).HasColumnName("guest_id");
            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.ReservationDate).HasColumnName("reservationDate");

            entity.HasOne(d => d.Facility).WithMany(p => p.FacilityReservations)
                .HasForeignKey(d => d.FacilityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FacilityReservations_Facilities");

            entity.HasOne(d => d.Guest).WithMany(p => p.FacilityReservations)
                .HasForeignKey(d => d.GuestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FacilityReservations_Guests");

            entity.HasOne(d => d.Order).WithMany(p => p.FacilityReservations)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FacilityReservations_Order");
        });

        modelBuilder.Entity<FeedBack>(entity =>
        {
            entity.ToTable("FeedBack");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Comments)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("comments");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.GuestId).HasColumnName("guest_id");

            entity.HasOne(d => d.Guest).WithMany(p => p.FeedBacks)
                .HasForeignKey(d => d.GuestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FeedBack_Guests");
        });

        modelBuilder.Entity<Guest>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("firstName");
            entity.Property(e => e.LastName)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("lastName");
            entity.Property(e => e.Phone).HasColumnName("phone");
        });

        modelBuilder.Entity<Lux>(entity =>
        {
            entity
                .ToTable("Lux")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("LuxHistory", "dbo");
                        ttb
                            .HasPeriodStart("ValidFrom")
                            .HasColumnName("ValidFrom");
                        ttb
                            .HasPeriodEnd("ValidTo")
                            .HasColumnName("ValidTo");
                    }));

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Type)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("type");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity
                .ToTable("Order")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("OrderHistory", "dbo");
                        ttb
                            .HasPeriodStart("ValidFrom")
                            .HasColumnName("ValidFrom");
                        ttb
                            .HasPeriodEnd("ValidTo")
                            .HasColumnName("ValidTo");
                    }));

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.PaymentId).HasColumnName("payment_id");
            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity.HasOne(d => d.Payment).WithMany(p => p.Orders)
                .HasForeignKey(d => d.PaymentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order_Payments");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("PaymentsHistory", "dbo");
                        ttb
                            .HasPeriodStart("ValidFrom")
                            .HasColumnName("ValidFrom");
                        ttb
                            .HasPeriodEnd("ValidTo")
                            .HasColumnName("ValidTo");
                    }));

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.PaymentDate).HasColumnName("paymentDate");
            entity.Property(e => e.PaymentMethod)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("paymentMethod");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("price");
            entity.Property(e => e.Result)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("result");
        });

        modelBuilder.Entity<RegulaService>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IntervalDays).HasColumnName("Interval(days)");
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.ToTable(tb =>
                {
                    tb.HasTrigger("trg_CheckRoomNumberUniqueInBuilding");
                    tb.HasTrigger("trg_ValidateArea");
                    tb.HasTrigger("trg_ValidateFlour");
                    tb.HasTrigger("trg_ValidateMaxPersons");
                    tb.HasTrigger("trg_ValidateRoomData");
                });

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Area)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("area");
            entity.Property(e => e.BuildingId).HasColumnName("building_id");
            entity.Property(e => e.Dilikes).HasColumnName("dilikes");
            entity.Property(e => e.Flour).HasColumnName("flour");
            entity.Property(e => e.Likes).HasColumnName("likes");
            entity.Property(e => e.LuxId).HasColumnName("lux_id");
            entity.Property(e => e.MaxPersons).HasColumnName("maxPersons");
            entity.Property(e => e.Photo)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("photo");
            entity.Property(e => e.RoomNumber).HasColumnName("roomNumber");
            entity.Property(e => e.RoomTypeId).HasColumnName("roomType_id");
            entity.Property(e => e.Video)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("video");

            entity.HasOne(d => d.Building).WithMany(p => p.Rooms)
                .HasForeignKey(d => d.BuildingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Rooms_Building");

            entity.HasOne(d => d.Lux).WithMany(p => p.Rooms)
                .HasForeignKey(d => d.LuxId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Rooms_Lux");

            entity.HasOne(d => d.RoomType).WithMany(p => p.Rooms)
                .HasForeignKey(d => d.RoomTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Rooms_RoomTypes");
        });

        modelBuilder.Entity<RoomAvailabilityHistory>(entity =>
        {
            entity.ToTable("RoomAvailabilityHistory", tb => tb.HasTrigger("INSERT_RoomAvailabilityHistory"));

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IsAvailable).HasColumnName("isAvailable");
            entity.Property(e => e.RoomId).HasColumnName("room_id");
            entity.Property(e => e.WritingDate).HasColumnName("writingDate");

            entity.HasOne(d => d.Room).WithMany(p => p.RoomAvailabilityHistories)
                .HasForeignKey(d => d.RoomId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RoomAvailabilityHistory_Rooms");
        });

        modelBuilder.Entity<RoomReservation>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CheckInDate).HasColumnName("checkInDate");
            entity.Property(e => e.CheckOutDate).HasColumnName("checkOutDate");
            entity.Property(e => e.GuestId).HasColumnName("guest_id");
            entity.Property(e => e.PaymentId).HasColumnName("payment_id");
            entity.Property(e => e.RoomId).HasColumnName("room_id");

            entity.HasOne(d => d.Guest).WithMany(p => p.RoomReservations)
                .HasForeignKey(d => d.GuestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RoomReservations_Guests");

            entity.HasOne(d => d.Payment).WithMany(p => p.RoomReservations)
                .HasForeignKey(d => d.PaymentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RoomReservations_Payments");

            entity.HasOne(d => d.Room).WithMany(p => p.RoomReservations)
                .HasForeignKey(d => d.RoomId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RoomReservations_Rooms");
        });

        modelBuilder.Entity<RoomService>(entity =>
        {
            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.RoomId).HasColumnName("room_id");
            entity.Property(e => e.RoomServicesCatalogId).HasColumnName("roomServicesCatalog_id");
            entity.Property(e => e.ServiceDate).HasColumnName("serviceDate");
            entity.Property(e => e.StaffId).HasColumnName("staff_id");

            entity.HasOne(d => d.Room).WithMany(p => p.RoomServices)
                .HasForeignKey(d => d.RoomId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RoomServices_Rooms");

            entity.HasOne(d => d.RoomServicesCatalog).WithMany(p => p.RoomServices)
                .HasForeignKey(d => d.RoomServicesCatalogId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RoomServices_RoomServicesCatalog");

            entity.HasOne(d => d.Staff).WithMany(p => p.RoomServices)
                .HasForeignKey(d => d.StaffId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RoomServices_Staff");
        });

        modelBuilder.Entity<RoomServicesCatalog>(entity =>
        {
            entity.ToTable("RoomServicesCatalog");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Duration)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("duration");
            entity.Property(e => e.RegulaServicesId).HasColumnName("regulaServices_id");
            entity.Property(e => e.Type)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("type");

            entity.HasOne(d => d.RegulaServices).WithMany(p => p.RoomServicesCatalogs)
                .HasForeignKey(d => d.RegulaServicesId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RoomServicesCatalog_RegulaServices");
        });

        modelBuilder.Entity<RoomType>(entity =>
        {
            entity.ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("RoomTypesHistory", "dbo");
                        ttb
                            .HasPeriodStart("ValidFrom")
                            .HasColumnName("ValidFrom");
                        ttb
                            .HasPeriodEnd("ValidTo")
                            .HasColumnName("ValidTo");
                    }));

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Type)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("type");
        });

        modelBuilder.Entity<SeasonPrice>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SeasonPr__3213E83FA4DB88D2");

            entity
                .ToTable("SeasonPrice")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("SeasonPriceHistory", "dbo");
                        ttb
                            .HasPeriodStart("ValidFrom")
                            .HasColumnName("ValidFrom");
                        ttb
                            .HasPeriodEnd("ValidTo")
                            .HasColumnName("ValidTo");
                    }));

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.EndDate).HasColumnName("endDate");
            entity.Property(e => e.LuxId).HasColumnName("lux_id");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("price");
            entity.Property(e => e.RoomTypeId).HasColumnName("roomType_id");
            entity.Property(e => e.StartDate).HasColumnName("startDate");

            entity.HasOne(d => d.Lux).WithMany(p => p.SeasonPrices)
                .HasForeignKey(d => d.LuxId)
                .HasConstraintName("FK_SeasonPrice_Lux");

            entity.HasOne(d => d.RoomType).WithMany(p => p.SeasonPrices)
                .HasForeignKey(d => d.RoomTypeId)
                .HasConstraintName("FK_SeasonPrice_RoomTypes");
        });

        modelBuilder.Entity<SensorsDatum>(entity =>
        {
            //entity.Property(e => e.Id)
            //    .ValueGeneratedNever()
            //    .HasColumnName("id");
            entity.Property(e => e.DateTime).HasColumnType("datetime");
            entity.Property(e => e.Humidity).HasColumnName("humidity");
            entity.Property(e => e.Pressure).HasColumnName("pressure");
            entity.Property(e => e.RoomId).HasColumnName("room_id");
            entity.Property(e => e.Temperature).HasColumnName("temperature");

            entity.HasOne(d => d.Room).WithMany(p => p.SensorsData)
                .HasForeignKey(d => d.RoomId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SensorsData_Rooms");
        });

        modelBuilder.Entity<Staff>(entity =>
        {
            entity.ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("StaffHistory", "dbo");
                        ttb
                            .HasPeriodStart("ValidFrom")
                            .HasColumnName("ValidFrom");
                        ttb
                            .HasPeriodEnd("ValidTo")
                            .HasColumnName("ValidTo");
                    }));

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FirstName)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("firstName");
            entity.Property(e => e.HireDate).HasColumnName("hireDate");
            entity.Property(e => e.LastName)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("lastName");
            entity.Property(e => e.Position)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("position");
            entity.Property(e => e.Salary)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("salary");
        });

        modelBuilder.Entity<StockKeepingUnit>(entity =>
        {
            entity.ToTable("StockKeepingUnit");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("description");
            entity.Property(e => e.Dislikes).HasColumnName("dislikes");
            entity.Property(e => e.Likes).HasColumnName("likes");
            entity.Property(e => e.Photo)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("photo");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("price");
            entity.Property(e => e.Video)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("video");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
