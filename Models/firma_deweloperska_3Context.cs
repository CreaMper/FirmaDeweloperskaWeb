using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace FirmaDeweloperskaWeb
{
    public partial class firma_deweloperska_3Context : DbContext
    {
        public firma_deweloperska_3Context()
        {
        }

        public firma_deweloperska_3Context(DbContextOptions<firma_deweloperska_3Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Pracownicy> Pracownicies { get; set; }
        public virtual DbSet<Priorytety> Prioryteties { get; set; }
        public virtual DbSet<Przeplywgotowki> Przeplywgotowkis { get; set; }
        public virtual DbSet<Przeznaczenie> Przeznaczenies { get; set; }
        public virtual DbSet<Sprzet> Sprzets { get; set; }
        public virtual DbSet<Umowy> Umowies { get; set; }
        public virtual DbSet<Wydatki> Wydatkis { get; set; }
        public virtual DbSet<Zespoly> Zespolies { get; set; }
        public virtual DbSet<Zlecenium> Zlecenia { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=DESKTOP-EJFO5TA\\SQLEXPRESS;Trusted_Connection=true; Database=firma_deweloperska_3");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Pracownicy>(entity =>
            {
                entity.HasKey(e => e.PracId);

                entity.ToTable("PRACOWNICY");

                entity.HasIndex(e => e.ZespId, "RELATIONSHIP_6_FK");

                entity.Property(e => e.PracId)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("PRAC_ID");

                entity.Property(e => e.PracAdres)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("PRAC_ADRES");

                entity.Property(e => e.PracEmail)
                    .HasColumnType("text")
                    .HasColumnName("PRAC_EMAIL");

                entity.Property(e => e.PracImie)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("PRAC_IMIE");

                entity.Property(e => e.PracNazwisko)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("PRAC_NAZWISKO");

                entity.Property(e => e.PracPesel)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("PRAC_PESEL");

                entity.Property(e => e.PracStanowsko)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("PRAC_STANOWSKO");

                entity.Property(e => e.PracTelefon)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("PRAC_TELEFON");

                entity.Property(e => e.ZespId)
                    .HasColumnType("numeric(5, 0)")
                    .HasColumnName("ZESP_ID");

                entity.HasOne(d => d.Zesp)
                    .WithMany(p => p.Pracownicies)
                    .HasForeignKey(d => d.ZespId)
                    .HasConstraintName("FK_PRACOWNI_RELATIONS_ZESPOLY");
            });

            modelBuilder.Entity<Priorytety>(entity =>
            {
                entity.HasKey(e => e.PrioId);

                entity.ToTable("PRIORYTETY");

                entity.Property(e => e.PrioId)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("PRIO_ID");

                entity.Property(e => e.PrioNazwa)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("PRIO_NAZWA");

                entity.Property(e => e.PrioPremiaDlaZespolu)
                    .HasColumnType("money")
                    .HasColumnName("PRIO_PREMIA_DLA_ZESPOLU");
            });

            modelBuilder.Entity<Przeplywgotowki>(entity =>
            {
                entity.HasKey(e => e.PrzepId);

                entity.ToTable("PRZEPLYWGOTOWKI");

                entity.HasIndex(e => e.ZlecId, "RELATIONSHIP_9_FK");

                entity.Property(e => e.PrzepId)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("PRZEP_ID");

                entity.Property(e => e.PrzepKwota)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("PRZEP_KWOTA");

                entity.Property(e => e.PrzepOpis)
                    .HasColumnType("text")
                    .HasColumnName("PRZEP_OPIS");

                entity.Property(e => e.ZlecId)
                    .HasColumnType("numeric(10, 0)")
                    .HasColumnName("ZLEC_ID");

                entity.HasOne(d => d.Zlec)
                    .WithMany(p => p.Przeplywgotowkis)
                    .HasForeignKey(d => d.ZlecId)
                    .HasConstraintName("FK_PRZEPLYW_RELATIONS_ZLECENIA");
            });

            modelBuilder.Entity<Przeznaczenie>(entity =>
            {
                entity.HasKey(e => e.PrzezId);

                entity.ToTable("PRZEZNACZENIE");

                entity.HasIndex(e => e.WydId, "RELATIONSHIP_18_FK");

                entity.Property(e => e.PrzezId)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("PRZEZ_ID");

                entity.Property(e => e.PrzezAktywnaDo)
                    .HasColumnType("datetime")
                    .HasColumnName("PRZEZ_AKTYWNA_DO");

                entity.Property(e => e.PrzezNazwa)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("PRZEZ_NAZWA");

                entity.Property(e => e.PrzezNumerSeryjny)
                    .HasColumnType("numeric(20, 0)")
                    .HasColumnName("PRZEZ_NUMER_SERYJNY");

                entity.Property(e => e.WydId)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("WYD_ID");

                entity.HasOne(d => d.Wyd)
                    .WithMany(p => p.Przeznaczenies)
                    .HasForeignKey(d => d.WydId)
                    .HasConstraintName("FK_PRZEZNAC_RELATIONS_WYDATKI");
            });

            modelBuilder.Entity<Sprzet>(entity =>
            {
                entity.ToTable("SPRZET");

                entity.Property(e => e.SprzetId)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("SPRZET_ID");

                entity.Property(e => e.SprzetIlosc).HasColumnName("SPRZET_ILOSC");

                entity.Property(e => e.SrzetNazwa)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("SRZET_NAZWA");

                entity.Property(e => e.ZespId)
                    .HasColumnType("numeric(5, 0)")
                    .HasColumnName("ZESP_ID");

                entity.HasOne(d => d.Zesp)
                    .WithMany(p => p.Sprzets)
                    .HasForeignKey(d => d.ZespId)
                    .HasConstraintName("FK_SPRZET_RELATIONS_ZESPOLY");
            });

            modelBuilder.Entity<Umowy>(entity =>
            {
                entity.HasKey(e => e.UmowaId);

                entity.ToTable("UMOWY");

                entity.HasIndex(e => e.PracId, "RELATIONSHIP_19_FK");

                entity.Property(e => e.UmowaId)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("UMOWA_ID");

                entity.Property(e => e.PracId)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("PRAC_ID");

                entity.Property(e => e.UmowaDoKiedy)
                    .HasColumnType("datetime")
                    .HasColumnName("UMOWA_DO_KIEDY");

                entity.Property(e => e.UmowaOdKiedy)
                    .HasColumnType("datetime")
                    .HasColumnName("UMOWA_OD_KIEDY");

                entity.Property(e => e.UmowaPensja)
                    .HasColumnType("money")
                    .HasColumnName("UMOWA_PENSJA");

                entity.HasOne(d => d.Prac)
                    .WithMany(p => p.Umowies)
                    .HasForeignKey(d => d.PracId)
                    .HasConstraintName("FK_UMOWY_RELATIONS_PRACOWNI");
            });

            modelBuilder.Entity<Wydatki>(entity =>
            {
                entity.HasKey(e => e.WydId);

                entity.ToTable("WYDATKI");

                entity.HasIndex(e => e.PracId, "RELATIONSHIP_17_FK");

                entity.Property(e => e.WydId)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("WYD_ID");

                entity.Property(e => e.PracId)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("PRAC_ID");

                entity.Property(e => e.WydData)
                    .HasColumnType("datetime")
                    .HasColumnName("WYD_DATA");

                entity.Property(e => e.WydKwota)
                    .HasColumnType("money")
                    .HasColumnName("WYD_KWOTA");

                entity.HasOne(d => d.Prac)
                    .WithMany(p => p.Wydatkis)
                    .HasForeignKey(d => d.PracId)
                    .HasConstraintName("FK_WYDATKI_RELATIONS_PRACOWNI");
            });

            modelBuilder.Entity<Zespoly>(entity =>
            {
                entity.HasKey(e => e.ZespId);

                entity.ToTable("ZESPOLY");

                entity.Property(e => e.ZespId)
                    .HasColumnType("numeric(5, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ZESP_ID");

                entity.Property(e => e.ZespNazwa)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("ZESP_NAZWA");
            });

            modelBuilder.Entity<Zlecenium>(entity =>
            {
                entity.HasKey(e => e.ZlecId);

                entity.ToTable("ZLECENIA");

                entity.HasIndex(e => e.PrioId, "RELATIONSHIP_26_FK");

                entity.HasIndex(e => e.ZespId, "RELATIONSHIP_8_FK");

                entity.Property(e => e.ZlecId)
                    .HasColumnType("numeric(10, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ZLEC_ID");

                entity.Property(e => e.PrioId)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("PRIO_ID");

                entity.Property(e => e.ZespId)
                    .HasColumnType("numeric(5, 0)")
                    .HasColumnName("ZESP_ID");

                entity.Property(e => e.ZlecOpis).HasColumnName("ZLEC_OPIS");

                entity.Property(e => e.ZlecRozpoczecie)
                    .HasColumnType("datetime")
                    .HasColumnName("ZLEC_ROZPOCZECIE");

                entity.Property(e => e.ZlecZakonczono).HasColumnName("ZLEC_ZAKONCZONO");

                entity.HasOne(d => d.Prio)
                    .WithMany(p => p.Zlecenia)
                    .HasForeignKey(d => d.PrioId)
                    .HasConstraintName("FK_ZLECENIA_RELATIONS_PRIORYTE");

                entity.HasOne(d => d.Zesp)
                    .WithMany(p => p.Zlecenia)
                    .HasForeignKey(d => d.ZespId)
                    .HasConstraintName("FK_ZLECENIA_RELATIONS_ZESPOLY");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
