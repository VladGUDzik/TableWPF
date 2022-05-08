using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WPF_SQL.Models
{
    public partial class Database_FirstBloodContext : DbContext
    {
        public Database_FirstBloodContext()
        {
        }

        public Database_FirstBloodContext(DbContextOptions<Database_FirstBloodContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DiscountTable> DiscountTables { get; set; }
        public virtual DbSet<GiveCash> GiveCashes { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<Mark> Marks { get; set; }
        public virtual DbSet<Rate> Rates { get; set; }
        public virtual DbSet<Resalt> Resalts { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<TakeCash> TakeCashes { get; set; }
        public virtual DbSet<Zachetka> Zachetkas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = Database_FirstBlood; Integrated Security = True; Persist Security Info = False; Pooling = False; MultipleActiveResultSets = False; Connect Timeout = 60; Encrypt = False; TrustServerCertificate = False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<DiscountTable>(entity =>
            {
                entity.ToTable("DiscountTable");

                entity.Property(e => e.Cost).HasColumnType("money");

                entity.Property(e => e.From).HasColumnType("money");

                entity.Property(e => e.To).HasColumnType("money");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.DiscountTables)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DiscountT__Stude__34C8D9D1");
            });

            modelBuilder.Entity<GiveCash>(entity =>
            {
                entity.ToTable("GiveCash");

                entity.Property(e => e.Cost).HasColumnType("money");

                entity.Property(e => e.DataGive).HasColumnType("date");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.GiveCashes)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__GiveCash__Studen__35BCFE0A");
            });

            modelBuilder.Entity<Group>(entity =>
            {
                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Mark>(entity =>
            {
                entity.ToTable("Mark");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Marks)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Mark__StudentId__36B12243");
            });

            modelBuilder.Entity<Rate>(entity =>
            {
                entity.Property(e => e.MakeAt)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Rates)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Rates__StudentId__37A5467C");
            });

            modelBuilder.Entity<Resalt>(entity =>
            {
                entity.ToTable("Resalt");

                entity.HasOne(d => d.RecordBook)
                    .WithMany(p => p.Resalts)
                    .HasForeignKey(d => d.RecordBookId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Resalt__RecordBo__38996AB5");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(e => e.Cost).HasColumnType("money");

                entity.Property(e => e.Dates).HasColumnType("date");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Students__GroupI__398D8EEE");
            });

            modelBuilder.Entity<TakeCash>(entity =>
            {
                entity.ToTable("TakeCash");

                entity.Property(e => e.Comment)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Cost).HasColumnType("money");

                entity.Property(e => e.DataGive).HasColumnType("date");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.TakeCashes)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TakeCash__Studen__3A81B327");
            });

            modelBuilder.Entity<Zachetka>(entity =>
            {
                entity.ToTable("Zachetka");

                entity.HasIndex(e => e.Number, "UQ__Zachetka__78A1A19D78A42B21")
                    .IsUnique();

                entity.Property(e => e.Number)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Zachetkas)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Zachetka__Studen__3B75D760");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
