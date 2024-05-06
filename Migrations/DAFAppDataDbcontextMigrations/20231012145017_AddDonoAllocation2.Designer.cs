﻿// <auto-generated />
using System;
using APPR6312_Part1_1_.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace APPR6312_Part1_1_.Migrations.DAFAppDataDbcontextMigrations
{
    [DbContext(typeof(DAFAppDataDbcontext))]
    [Migration("20231012145017_AddDonoAllocation2")]
    partial class AddDonoAllocation2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("APPR6312_Part1_1_.Models.Domain.Disaster", b =>
                {
                    b.Property<Guid>("DisasterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AidType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DisasterDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DisasterName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("DisasterId");

                    b.ToTable("Disasters");
                });

            modelBuilder.Entity("APPR6312_Part1_1_.Models.Domain.DonationAllocation", b =>
                {
                    b.Property<Guid>("DisasterId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("GoodsDonationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AllocationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("NumberOfItems")
                        .HasColumnType("int");

                    b.Property<string>("goodsCategory")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DisasterId", "GoodsDonationId");

                    b.HasIndex("GoodsDonationId");

                    b.ToTable("DonationsAllo");
                });

            modelBuilder.Entity("APPR6312_Part1_1_.Models.Domain.goodsDonation", b =>
                {
                    b.Property<Guid>("goodDonationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DonationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DonorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfItems")
                        .HasColumnType("int");

                    b.Property<string>("goodsCategory")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("goodDonationId");

                    b.ToTable("goodsDonations");
                });

            modelBuilder.Entity("APPR6312_Part1_1_.Models.Domain.MonetaryDonation", b =>
                {
                    b.Property<Guid>("MoneyDonationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("DonationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DonorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MoneyDonationId");

                    b.ToTable("MonetaryDonations");
                });

            modelBuilder.Entity("APPR6312_Part1_1_.Models.Domain.DonationAllocation", b =>
                {
                    b.HasOne("APPR6312_Part1_1_.Models.Domain.Disaster", "Disaster")
                        .WithMany("donationAllocations")
                        .HasForeignKey("DisasterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("APPR6312_Part1_1_.Models.Domain.goodsDonation", "goodsDonation")
                        .WithMany()
                        .HasForeignKey("GoodsDonationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Disaster");

                    b.Navigation("goodsDonation");
                });

            modelBuilder.Entity("APPR6312_Part1_1_.Models.Domain.Disaster", b =>
                {
                    b.Navigation("donationAllocations");
                });
#pragma warning restore 612, 618
        }
    }
}