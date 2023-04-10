﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OrdersManagment.DataAccess;

#nullable disable

namespace OrdersManagment.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("OrdersManagment.Models.Tables.Status", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Status");
                });

            modelBuilder.Entity("OrdersManagment.Models.Tables.Tasks", b =>
                {
                    b.Property<int>("orderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("orderId"));

                    b.Property<double>("COD")
                        .HasColumnType("float");

                    b.Property<int?>("assinedTo")
                        .HasColumnType("int");

                    b.Property<double>("orderAmount")
                        .HasColumnType("float");

                    b.Property<int?>("orderStatus")
                        .HasColumnType("int");

                    b.HasKey("orderId");

                    b.HasIndex("assinedTo");

                    b.HasIndex("orderStatus");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("OrdersManagment.Models.Tables.Users", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<string>("deviceToken")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("userName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("userPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("OrdersManagment.Models.Tables.Tasks", b =>
                {
                    b.HasOne("OrdersManagment.Models.Tables.Users", "user")
                        .WithMany()
                        .HasForeignKey("assinedTo");

                    b.HasOne("OrdersManagment.Models.Tables.Status", "status")
                        .WithMany()
                        .HasForeignKey("orderStatus");

                    b.Navigation("status");

                    b.Navigation("user");
                });
#pragma warning restore 612, 618
        }
    }
}
