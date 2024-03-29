﻿// <auto-generated />
using System;
using CurrencyExchangeCrud.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CurrencyExchangeCrud.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CurrencyExchangeCrud.Data.Models.CountryMaster", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("RefCurrencyId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.HasIndex("RefCurrencyId");

                    b.ToTable("CountryMaster", "Master");
                });

            modelBuilder.Entity("CurrencyExchangeCrud.Data.Models.CurrencyExchangeRate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("ExchangeDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("ExchangeRate")
                        .HasColumnType("float");

                    b.Property<int>("RefSourceCurrencyId")
                        .HasColumnType("int");

                    b.Property<int>("RefTargetCurrencyId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RefSourceCurrencyId");

                    b.HasIndex("RefTargetCurrencyId");

                    b.ToTable("CurrencyExchangeRate", "Master");
                });

            modelBuilder.Entity("CurrencyExchangeCrud.Data.Models.CurrencyMaster", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.ToTable("CurrencyMaster", "Master");
                });

            modelBuilder.Entity("CurrencyExchangeCrud.Data.Models.CountryMaster", b =>
                {
                    b.HasOne("CurrencyExchangeCrud.Data.Models.CurrencyMaster", "RefCurrencyMaster")
                        .WithMany()
                        .HasForeignKey("RefCurrencyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RefCurrencyMaster");
                });

            modelBuilder.Entity("CurrencyExchangeCrud.Data.Models.CurrencyExchangeRate", b =>
                {
                    b.HasOne("CurrencyExchangeCrud.Data.Models.CurrencyMaster", "RefSourceCurrencyMaster")
                        .WithMany()
                        .HasForeignKey("RefSourceCurrencyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CurrencyExchangeCrud.Data.Models.CurrencyMaster", "RefTargetCurrencyMaster")
                        .WithMany()
                        .HasForeignKey("RefTargetCurrencyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RefSourceCurrencyMaster");

                    b.Navigation("RefTargetCurrencyMaster");
                });
#pragma warning restore 612, 618
        }
    }
}
