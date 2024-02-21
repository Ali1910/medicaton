﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using medicaton;

#nullable disable

namespace medicaton.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240221092843_update")]
    partial class update
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("medicaton.models.Medication", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("EnglishName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("about")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("usedfor")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Name");

                    b.ToTable("medications");
                });

            modelBuilder.Entity("medicaton.models.MedicationWarningJoin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("MedicationName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("WarningName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("MedicationName");

                    b.HasIndex("WarningName");

                    b.ToTable("medicationWarningJoins");
                });

            modelBuilder.Entity("medicaton.models.Warning", b =>
                {
                    b.Property<string>("WarningName")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("WarningName");

                    b.ToTable("warnings");
                });

            modelBuilder.Entity("medicaton.models.MedicationWarningJoin", b =>
                {
                    b.HasOne("medicaton.models.Medication", "medication")
                        .WithMany("medicationWarningJoins")
                        .HasForeignKey("MedicationName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("medicaton.models.Warning", "warning")
                        .WithMany("medicationWarningJoins")
                        .HasForeignKey("WarningName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("medication");

                    b.Navigation("warning");
                });

            modelBuilder.Entity("medicaton.models.Medication", b =>
                {
                    b.Navigation("medicationWarningJoins");
                });

            modelBuilder.Entity("medicaton.models.Warning", b =>
                {
                    b.Navigation("medicationWarningJoins");
                });
#pragma warning restore 612, 618
        }
    }
}
