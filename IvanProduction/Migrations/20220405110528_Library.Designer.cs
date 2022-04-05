﻿// <auto-generated />
using System;
using IvanProduction.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace IvanProduction.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220405110528_Library")]
    partial class Library
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.23");

            modelBuilder.Entity("IvanProduction.Model.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("AccountHolderId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("StatusId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("AccountHolderId");

                    b.HasIndex("StatusId");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("IvanProduction.Model.HistoryTransactions", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("AccountId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("ActiveTransaction")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("ReturnTime")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("TakeTime")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("Histories");
                });

            modelBuilder.Entity("IvanProduction.Model.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("Score")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Status");
                });

            modelBuilder.Entity("IvanProduction.Model.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Email")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .HasColumnType("TEXT");

                    b.Property<string>("Surname")
                        .HasColumnType("TEXT");

                    b.Property<string>("Username")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasDiscriminator<string>("Discriminator").HasValue("User");
                });

            modelBuilder.Entity("IvanProduction.Model.Admin", b =>
                {
                    b.HasBaseType("IvanProduction.Model.User");

                    b.Property<string>("JobPosition")
                        .HasColumnType("TEXT");

                    b.HasDiscriminator().HasValue("Admin");
                });

            modelBuilder.Entity("IvanProduction.Model.Account", b =>
                {
                    b.HasOne("IvanProduction.Model.User", "AccountHolder")
                        .WithMany()
                        .HasForeignKey("AccountHolderId");

                    b.HasOne("IvanProduction.Model.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId");
                });

            modelBuilder.Entity("IvanProduction.Model.HistoryTransactions", b =>
                {
                    b.HasOne("IvanProduction.Model.Account", "Account")
                        .WithMany("historyTransactions")
                        .HasForeignKey("AccountId");

                    b.OwnsOne("IvanProduction.Model.Book", "Book", b1 =>
                        {
                            b1.Property<int>("HistoryTransactionsId")
                                .HasColumnType("INTEGER");

                            b1.Property<string>("Author")
                                .HasColumnType("TEXT");

                            b1.Property<int>("Count")
                                .HasColumnType("INTEGER");

                            b1.Property<int>("Id")
                                .HasColumnType("INTEGER");

                            b1.Property<string>("Name")
                                .HasColumnType("TEXT");

                            b1.HasKey("HistoryTransactionsId");

                            b1.ToTable("Books");

                            b1.WithOwner()
                                .HasForeignKey("HistoryTransactionsId");
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
