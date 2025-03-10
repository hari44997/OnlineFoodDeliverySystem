﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OnlineFoodDeliverySystem.Data;

#nullable disable

namespace OnlineFoodDeliverySystem.Migrations
{
    [DbContext(typeof(FoodDbContext))]
    [Migration("20250308171407_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("OnlineFoodDeliverySystem.Customer", b =>
                {
                    b.Property<int>("CustomerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerID"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Phone")
                        .HasColumnType("int");

                    b.HasKey("CustomerID");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("OnlineFoodDeliverySystem.MenuItem", b =>
                {
                    b.Property<int>("ItemID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ItemID"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("RestaruntID")
                        .HasColumnType("int");

                    b.HasKey("ItemID");

                    b.HasIndex("RestaruntID");

                    b.ToTable("MenuItems");
                });

            modelBuilder.Entity("OnlineFoodDeliverySystem.Models.Agent", b =>
                {
                    b.Property<int>("AgentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AgentID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.HasKey("AgentID");

                    b.ToTable("Agents");
                });

            modelBuilder.Entity("OnlineFoodDeliverySystem.Models.Delivery", b =>
                {
                    b.Property<int>("DeliveryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DeliveryID"));

                    b.Property<int>("AgentID")
                        .HasColumnType("int");

                    b.Property<DateTime>("EstimatedTimeOfArrival")
                        .HasColumnType("datetime2");

                    b.Property<int>("OrderID")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DeliveryID");

                    b.HasIndex("AgentID");

                    b.HasIndex("OrderID")
                        .IsUnique();

                    b.ToTable("Deliveries");
                });

            modelBuilder.Entity("OnlineFoodDeliverySystem.Models.OrderItem", b =>
                {
                    b.Property<int>("OrderItemID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderItemID"));

                    b.Property<int>("ItemID")
                        .HasColumnType("int");

                    b.Property<int>("OrderID")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("OrderItemID");

                    b.HasIndex("ItemID");

                    b.HasIndex("OrderID");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("OnlineFoodDeliverySystem.Models.Payment", b =>
                {
                    b.Property<int>("PaymentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PaymentID"));

                    b.Property<int>("OrderID")
                        .HasColumnType("int");

                    b.Property<string>("PaymentMethod")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PaymentID");

                    b.HasIndex("OrderID")
                        .IsUnique();

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("OnlineFoodDeliverySystem.Models.Restaurant", b =>
                {
                    b.Property<int>("RestaurantID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RestaurantID"));

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<string>("RestaurantName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RestaurantID");

                    b.ToTable("Restaurants");
                });

            modelBuilder.Entity("OnlineFoodDeliverySystem.Order", b =>
                {
                    b.Property<int>("OrderID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderID"));

                    b.Property<int>("CustomerID")
                        .HasColumnType("int");

                    b.Property<int>("RestaurantID")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("TotalAmount")
                        .HasColumnType("float");

                    b.HasKey("OrderID");

                    b.HasIndex("CustomerID");

                    b.HasIndex("RestaurantID");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("OnlineFoodDeliverySystem.MenuItem", b =>
                {
                    b.HasOne("OnlineFoodDeliverySystem.Models.Restaurant", "Restaurant")
                        .WithMany("MenuItems")
                        .HasForeignKey("RestaruntID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("OnlineFoodDeliverySystem.Models.Delivery", b =>
                {
                    b.HasOne("OnlineFoodDeliverySystem.Models.Agent", "Agent")
                        .WithMany("Deliveries")
                        .HasForeignKey("AgentID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("OnlineFoodDeliverySystem.Order", "Order")
                        .WithOne("Delivery")
                        .HasForeignKey("OnlineFoodDeliverySystem.Models.Delivery", "OrderID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Agent");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("OnlineFoodDeliverySystem.Models.OrderItem", b =>
                {
                    b.HasOne("OnlineFoodDeliverySystem.MenuItem", "MenuItem")
                        .WithMany("OrderItems")
                        .HasForeignKey("ItemID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("OnlineFoodDeliverySystem.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MenuItem");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("OnlineFoodDeliverySystem.Models.Payment", b =>
                {
                    b.HasOne("OnlineFoodDeliverySystem.Order", "Order")
                        .WithOne("Payment")
                        .HasForeignKey("OnlineFoodDeliverySystem.Models.Payment", "OrderID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("OnlineFoodDeliverySystem.Order", b =>
                {
                    b.HasOne("OnlineFoodDeliverySystem.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineFoodDeliverySystem.Models.Restaurant", "Restaurant")
                        .WithMany("Orders")
                        .HasForeignKey("RestaurantID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("OnlineFoodDeliverySystem.Customer", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("OnlineFoodDeliverySystem.MenuItem", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("OnlineFoodDeliverySystem.Models.Agent", b =>
                {
                    b.Navigation("Deliveries");
                });

            modelBuilder.Entity("OnlineFoodDeliverySystem.Models.Restaurant", b =>
                {
                    b.Navigation("MenuItems");

                    b.Navigation("Orders");
                });

            modelBuilder.Entity("OnlineFoodDeliverySystem.Order", b =>
                {
                    b.Navigation("Delivery")
                        .IsRequired();

                    b.Navigation("OrderItems");

                    b.Navigation("Payment")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
