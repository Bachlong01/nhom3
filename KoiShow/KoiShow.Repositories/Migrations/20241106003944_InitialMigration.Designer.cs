﻿// <auto-generated />
using System;
using KoiShow.Repositories.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace KoiShow.Repositories.Migrations
{
    [DbContext(typeof(KoiShow2024Context))]
    [Migration("20241106003944_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseCollation("utf8mb4_0900_ai_ci")
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.HasCharSet(modelBuilder, "utf8mb4");
            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("KoiShow.Repositories.Entities.Competition", b =>
                {
                    b.Property<int>("CompetitionId")
                        .HasColumnType("int")
                        .HasColumnName("CompetitionID");

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .UseCollation("utf8mb3_general_ci");

                    MySqlPropertyBuilderExtensions.HasCharSet(b.Property<string>("Description"), "utf8mb3");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Status")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .UseCollation("utf8mb3_general_ci");

                    MySqlPropertyBuilderExtensions.HasCharSet(b.Property<string>("Status"), "utf8mb3");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .UseCollation("utf8mb3_general_ci");

                    MySqlPropertyBuilderExtensions.HasCharSet(b.Property<string>("Title"), "utf8mb3");

                    b.HasKey("CompetitionId")
                        .HasName("PRIMARY");

                    b.ToTable("competition", (string)null);
                });

            modelBuilder.Entity("KoiShow.Repositories.Entities.Koicategory", b =>
                {
                    b.Property<int>("CategoryId")
                        .HasColumnType("int")
                        .HasColumnName("CategoryID");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .UseCollation("utf8mb3_general_ci");

                    MySqlPropertyBuilderExtensions.HasCharSet(b.Property<string>("CategoryName"), "utf8mb3");

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .UseCollation("utf8mb3_general_ci");

                    MySqlPropertyBuilderExtensions.HasCharSet(b.Property<string>("Description"), "utf8mb3");

                    b.HasKey("CategoryId")
                        .HasName("PRIMARY");

                    b.ToTable("koicategory", (string)null);
                });

            modelBuilder.Entity("KoiShow.Repositories.Entities.Koifish", b =>
                {
                    b.Property<int>("KoiId")
                        .HasColumnType("int")
                        .HasColumnName("KoiID");

                    b.Property<int?>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Breed")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .UseCollation("utf8mb3_general_ci");

                    MySqlPropertyBuilderExtensions.HasCharSet(b.Property<string>("Breed"), "utf8mb3");

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int")
                        .HasColumnName("CategoryID");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .UseCollation("utf8mb3_general_ci");

                    MySqlPropertyBuilderExtensions.HasCharSet(b.Property<string>("Name"), "utf8mb3");

                    b.Property<int?>("OwnerId")
                        .HasColumnType("int")
                        .HasColumnName("OwnerID");

                    b.Property<float?>("Size")
                        .HasColumnType("float");

                    b.HasKey("KoiId")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "CategoryId" }, "CategoryID");

                    b.ToTable("koifish", (string)null);
                });

            modelBuilder.Entity("KoiShow.Repositories.Entities.Koishowaccount", b =>
                {
                    b.Property<int>("AccountId")
                        .HasColumnType("int")
                        .HasColumnName("AccountID");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(90)
                        .HasColumnType("varchar(90)")
                        .UseCollation("utf8mb3_general_ci");

                    MySqlPropertyBuilderExtensions.HasCharSet(b.Property<string>("Password"), "utf8mb3");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .UseCollation("utf8mb3_general_ci");

                    MySqlPropertyBuilderExtensions.HasCharSet(b.Property<string>("Role"), "utf8mb3");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .UseCollation("utf8mb3_general_ci");

                    MySqlPropertyBuilderExtensions.HasCharSet(b.Property<string>("Username"), "utf8mb3");

                    b.HasKey("AccountId")
                        .HasName("PRIMARY");

                    b.ToTable("koishowaccount", (string)null);
                });

            modelBuilder.Entity("KoiShow.Repositories.Entities.Koishowparticipation", b =>
                {
                    b.Property<int>("ParticipationId")
                        .HasColumnType("int")
                        .HasColumnName("ParticipationID");

                    b.Property<int?>("CompetitionId")
                        .HasColumnType("int")
                        .HasColumnName("CompetitionID");

                    b.Property<int?>("KoiId")
                        .HasColumnType("int")
                        .HasColumnName("KoiID");

                    b.Property<string>("Status")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .UseCollation("utf8mb3_general_ci");

                    MySqlPropertyBuilderExtensions.HasCharSet(b.Property<string>("Status"), "utf8mb3");

                    b.HasKey("ParticipationId")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "CompetitionId" }, "CompetitionID");

                    b.HasIndex(new[] { "KoiId" }, "KoiID");

                    b.ToTable("koishowparticipation", (string)null);
                });

            modelBuilder.Entity("KoiShow.Repositories.Entities.Koifish", b =>
                {
                    b.HasOne("KoiShow.Repositories.Entities.Koicategory", "Category")
                        .WithMany("Koifishes")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("koifish_ibfk_1");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("KoiShow.Repositories.Entities.Koishowparticipation", b =>
                {
                    b.HasOne("KoiShow.Repositories.Entities.Competition", "Competition")
                        .WithMany("Koishowparticipations")
                        .HasForeignKey("CompetitionId")
                        .HasConstraintName("koishowparticipation_ibfk_1");

                    b.HasOne("KoiShow.Repositories.Entities.Koifish", "Koi")
                        .WithMany("Koishowparticipations")
                        .HasForeignKey("KoiId")
                        .HasConstraintName("koishowparticipation_ibfk_2");

                    b.Navigation("Competition");

                    b.Navigation("Koi");
                });

            modelBuilder.Entity("KoiShow.Repositories.Entities.Competition", b =>
                {
                    b.Navigation("Koishowparticipations");
                });

            modelBuilder.Entity("KoiShow.Repositories.Entities.Koicategory", b =>
                {
                    b.Navigation("Koifishes");
                });

            modelBuilder.Entity("KoiShow.Repositories.Entities.Koifish", b =>
                {
                    b.Navigation("Koishowparticipations");
                });
#pragma warning restore 612, 618
        }
    }
}
