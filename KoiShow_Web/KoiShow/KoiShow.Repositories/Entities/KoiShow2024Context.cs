using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace KoiShow.Repositories.Entities;

public partial class KoiShow2024Context : DbContext
{
    public KoiShow2024Context()
    {
    }

    public KoiShow2024Context(DbContextOptions<KoiShow2024Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Competition> Competitions { get; set; }

    public virtual DbSet<Koicategory> Koicategories { get; set; }

    public virtual DbSet<Koifish> Koifishes { get; set; }

    public virtual DbSet<Koishowaccount> Koishowaccounts { get; set; }

    public virtual DbSet<Koishowparticipation> Koishowparticipations { get; set; }

   protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
      => optionsBuilder.UseMySql("server=127.0.0.1;port=3306;database=KoiShow2024;user=root;password=08102005a", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.4.0-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Competition>(entity =>
        {
            entity.HasKey(e => e.CompetitionId).HasName("PRIMARY");

            entity.ToTable("competition");

            entity.Property(e => e.CompetitionId)
                .ValueGeneratedNever()
                .HasColumnName("CompetitionID");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.StartDate).HasColumnType("datetime");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
        });

        modelBuilder.Entity<Koicategory>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PRIMARY");

            entity.ToTable("koicategory");

            entity.Property(e => e.CategoryId)
                .ValueGeneratedNever()
                .HasColumnName("CategoryID");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(100)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
        });

        modelBuilder.Entity<Koifish>(entity =>
        {
            entity.HasKey(e => e.KoiId).HasName("PRIMARY");

            entity.ToTable("koifish");

            entity.HasIndex(e => e.CategoryId, "CategoryID");

            entity.Property(e => e.KoiId)
                .ValueGeneratedNever()
                .HasColumnName("KoiID");
            entity.Property(e => e.Breed)
                .HasMaxLength(100)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.OwnerId).HasColumnName("OwnerID");

            entity.HasOne(d => d.Category).WithMany(p => p.Koifishes)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("koifish_ibfk_1");
        });

        modelBuilder.Entity<Koishowaccount>(entity =>
        {
            entity.HasKey(e => e.AccountId).HasName("PRIMARY");

            entity.ToTable("koishowaccount");

            entity.Property(e => e.AccountId)
                .ValueGeneratedNever()
                .HasColumnName("AccountID");

            // Thêm chỉ mục duy nhất cho AccountId và Username
            entity.HasIndex(e => e.AccountId)
                .IsUnique();  // Đảm bảo AccountId là duy nhất

            entity.HasIndex(e => e.Username)
                .IsUnique();  // Đảm bảo Username là duy nhất

            entity.Property(e => e.Password)
                .HasMaxLength(90)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");

            entity.Property(e => e.Role)
                .HasMaxLength(50)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");

            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
        });

        modelBuilder.Entity<Koishowparticipation>(entity =>
        {
            entity.HasKey(e => e.ParticipationId).HasName("PRIMARY");

            entity.ToTable("koishowparticipation");

            entity.HasIndex(e => e.CompetitionId, "CompetitionID");

            entity.HasIndex(e => e.KoiId, "KoiID");

            entity.Property(e => e.ParticipationId)
                .ValueGeneratedNever()
                .HasColumnName("ParticipationID");
            entity.Property(e => e.CompetitionId).HasColumnName("CompetitionID");
            entity.Property(e => e.KoiId).HasColumnName("KoiID");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");

            entity.HasOne(d => d.Competition).WithMany(p => p.Koishowparticipations)
                .HasForeignKey(d => d.CompetitionId)
                .HasConstraintName("koishowparticipation_ibfk_1");

            entity.HasOne(d => d.Koi).WithMany(p => p.Koishowparticipations)
                .HasForeignKey(d => d.KoiId)
                .HasConstraintName("koishowparticipation_ibfk_2");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
