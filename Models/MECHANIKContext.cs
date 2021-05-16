using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace FirmaDeweloperskaWeb
{
    public partial class MECHANIKContext : DbContext
    {
        public MECHANIKContext()
        {
        }

        public MECHANIKContext(DbContextOptions<MECHANIKContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Part> Parts { get; set; }
        public virtual DbSet<Request> Requests { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Status> Statuses { get; set; }
        public virtual DbSet<TransactionIndex372a7b84Bfbd4079Aa4739a1eaf4a819> TransactionIndex372a7b84Bfbd4079Aa4739a1eaf4a819s { get; set; }
        public virtual DbSet<Type> Types { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Vehicle> Vehicles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Trusted_Connection=True; Database=MECHANIK");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Polish_CI_AS");

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .IsClustered(false);

                entity.ToTable("ORDER");

                entity.HasIndex(e => e.StatusId, "ORDER-STATUS_FK");

                entity.HasIndex(e => e.UsrId, "USER-ORDER_FK");

                entity.Property(e => e.OrderId)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("order_id");

                entity.Property(e => e.OrderAccepted)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("order_accepted");

                entity.Property(e => e.OrderDate)
                    .HasColumnType("datetime")
                    .HasColumnName("order_date");

                entity.Property(e => e.OrderDesc)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("order_desc");

                entity.Property(e => e.OrderName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("order_name");

                entity.Property(e => e.StatusId)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("status_id");

                entity.Property(e => e.UsrId)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("usr_id");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ORDER_ORDER-STA_STATUS");

                entity.HasOne(d => d.Usr)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UsrId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ORDER_USER-ORDE_USER");
            });

            modelBuilder.Entity<Part>(entity =>
            {
                entity.HasKey(e => e.PartId)
                    .IsClustered(false);

                entity.ToTable("PART");

                entity.HasIndex(e => e.TypeId, "PART-TYPE_FK");

                entity.HasIndex(e => e.VehId, "PART-VEHICLE_FK");

                entity.Property(e => e.PartId)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("part_id");

                entity.Property(e => e.PartAmount).HasColumnName("part_amount");

                entity.Property(e => e.PartDesc)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("part_desc");

                entity.Property(e => e.PartName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("part_name");

                entity.Property(e => e.PartPrice)
                    .HasColumnType("money")
                    .HasColumnName("part_price");

                entity.Property(e => e.TypeId)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("type_id");

                entity.Property(e => e.VehId)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("veh_id");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Parts)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PART_PART-TYPE_TYPE");

                entity.HasOne(d => d.Veh)
                    .WithMany(p => p.Parts)
                    .HasForeignKey(d => d.VehId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PART_PART-VEHI_VEHICLE");
            });

            modelBuilder.Entity<Request>(entity =>
            {
                entity.HasKey(e => e.ReqId)
                    .IsClustered(false);

                entity.ToTable("REQUEST");

                entity.HasIndex(e => e.OrderId, "ORDER-REQUEST_FK");

                entity.HasIndex(e => e.PartId, "PART-REQUEST_FK");

                entity.Property(e => e.ReqId)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("req_id");

                entity.Property(e => e.OrderId)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("order_id");

                entity.Property(e => e.PartId)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("part_id");

                entity.Property(e => e.ReqAmount).HasColumnName("req_amount");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Requests)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_REQUEST_ORDER-REQ_ORDER");

                entity.HasOne(d => d.Part)
                    .WithMany(p => p.Requests)
                    .HasForeignKey(d => d.PartId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_REQUEST_PART-REQU_PART");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.RoleId)
                    .IsClustered(false);

                entity.ToTable("ROLE");

                entity.Property(e => e.RoleId)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("role_id");

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("role_name");
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.HasKey(e => e.StatusId)
                    .IsClustered(false);

                entity.ToTable("STATUS");

                entity.Property(e => e.StatusId)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("status_id");

                entity.Property(e => e.StatusName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("status_name");
            });

            modelBuilder.Entity<TransactionIndex372a7b84Bfbd4079Aa4739a1eaf4a819>(entity =>
            {
                entity.ToTable("_TransactionIndex_372a7b84-bfbd-4079-aa47-39a1eaf4a819");

                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<Type>(entity =>
            {
                entity.HasKey(e => e.TypeId)
                    .IsClustered(false);

                entity.ToTable("TYPE");

                entity.Property(e => e.TypeId)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("type_id");

                entity.Property(e => e.TypeName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("type_name");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UsrId)
                    .IsClustered(false);

                entity.ToTable("USER");

                entity.HasIndex(e => e.RoleId, "Relationship_1_FK");

                entity.Property(e => e.UsrId)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("usr_id");

                entity.Property(e => e.RoleId)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("role_id");

                entity.Property(e => e.UsrAddress)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("usr_address");

                entity.Property(e => e.UsrEmail)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("usr_email");

                entity.Property(e => e.UsrLastName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("usr_lastName");

                entity.Property(e => e.UsrLogin)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("usr_login");

                entity.Property(e => e.UsrName)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("usr_name");

                entity.Property(e => e.UsrPasswd)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("usr_passwd");

                entity.Property(e => e.UsrPesel).HasColumnName("usr_pesel");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_USER_RELATIONS_ROLE");
            });

            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.HasKey(e => e.VehId)
                    .IsClustered(false);

                entity.ToTable("VEHICLE");

                entity.Property(e => e.VehId)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("veh_id");

                entity.Property(e => e.VehName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("veh_name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
