﻿// <auto-generated />
using System;
using DeliveryServiceDomain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DeliveryServiceDomain.Migrations
{
    [DbContext(typeof(DeliveryServiceContext))]
    [Migration("20220317214910_idk")]
    partial class idk
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.14")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DeliveryServiceDomain.AdditionalService", b =>
                {
                    b.Property<int>("AdditionalServiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("AdditionalServiceId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AdditionalServiceName")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("varchar(40)")
                        .HasColumnName("AdditionalServiceName");

                    b.Property<double>("AdditionalServicePrice")
                        .HasColumnType("float")
                        .HasColumnName("AdditionalServicePrice");

                    b.HasKey("AdditionalServiceId");

                    b.ToTable("AdditionalService");

                    b.HasData(
                        new
                        {
                            AdditionalServiceId = 1,
                            AdditionalServiceName = "Signed delivery note",
                            AdditionalServicePrice = 50.0
                        },
                        new
                        {
                            AdditionalServiceId = 2,
                            AdditionalServiceName = "Return receipt",
                            AdditionalServicePrice = 50.0
                        },
                        new
                        {
                            AdditionalServiceId = 3,
                            AdditionalServiceName = "Additional packaging",
                            AdditionalServicePrice = 60.0
                        },
                        new
                        {
                            AdditionalServiceId = 4,
                            AdditionalServiceName = "Personal delivery",
                            AdditionalServicePrice = 60.0
                        },
                        new
                        {
                            AdditionalServiceId = 5,
                            AdditionalServiceName = "Value insurance",
                            AdditionalServicePrice = 80.0
                        },
                        new
                        {
                            AdditionalServiceId = 6,
                            AdditionalServiceName = "Email report",
                            AdditionalServicePrice = 30.0
                        },
                        new
                        {
                            AdditionalServiceId = 7,
                            AdditionalServiceName = "SMS report",
                            AdditionalServicePrice = 30.0
                        },
                        new
                        {
                            AdditionalServiceId = 8,
                            AdditionalServiceName = "Delivery today for tomorrow until 12h",
                            AdditionalServicePrice = 90.0
                        },
                        new
                        {
                            AdditionalServiceId = 9,
                            AdditionalServiceName = "Delivery today for tomorrow until 19h",
                            AdditionalServicePrice = 70.0
                        });
                });

            modelBuilder.Entity("DeliveryServiceDomain.AdditionalServiceShipment", b =>
                {
                    b.Property<int>("AdditionalServiceId")
                        .HasColumnType("int")
                        .HasColumnName("AdditionalServiceId");

                    b.Property<int>("ShipmentId")
                        .HasColumnType("int")
                        .HasColumnName("ShipmentId");

                    b.HasKey("AdditionalServiceId", "ShipmentId");

                    b.HasIndex("ShipmentId");

                    b.ToTable("AdditionalServiceShipments");
                });

            modelBuilder.Entity("DeliveryServiceDomain.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("PostalCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("DeliveryServiceDomain.Deliverer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfEmployment")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Deliverer");
                });

            modelBuilder.Entity("DeliveryServiceDomain.Location", b =>
                {
                    b.Property<int>("LocationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("LocationId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("LocationName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("varchar(25)")
                        .HasColumnName("LocationName");

                    b.HasKey("LocationId");

                    b.ToTable("Locations");

                    b.HasData(
                        new
                        {
                            LocationId = 1,
                            LocationName = "Beograd"
                        },
                        new
                        {
                            LocationId = 2,
                            LocationName = "Valjevo"
                        },
                        new
                        {
                            LocationId = 3,
                            LocationName = "Vranje"
                        },
                        new
                        {
                            LocationId = 4,
                            LocationName = "Zaječar"
                        },
                        new
                        {
                            LocationId = 5,
                            LocationName = "Zrenjanin"
                        },
                        new
                        {
                            LocationId = 6,
                            LocationName = "Jagodina"
                        },
                        new
                        {
                            LocationId = 7,
                            LocationName = "Kragujevac"
                        },
                        new
                        {
                            LocationId = 8,
                            LocationName = "Kraljevo"
                        },
                        new
                        {
                            LocationId = 9,
                            LocationName = "Kruševac"
                        },
                        new
                        {
                            LocationId = 10,
                            LocationName = "Leskovac"
                        },
                        new
                        {
                            LocationId = 11,
                            LocationName = "Loznica"
                        },
                        new
                        {
                            LocationId = 12,
                            LocationName = "Niš"
                        },
                        new
                        {
                            LocationId = 13,
                            LocationName = "Novi Pazar"
                        },
                        new
                        {
                            LocationId = 14,
                            LocationName = "Novi Sad"
                        },
                        new
                        {
                            LocationId = 15,
                            LocationName = "Pančevo"
                        },
                        new
                        {
                            LocationId = 16,
                            LocationName = "Požarevac"
                        },
                        new
                        {
                            LocationId = 17,
                            LocationName = "Priština"
                        },
                        new
                        {
                            LocationId = 18,
                            LocationName = "Smederevo"
                        },
                        new
                        {
                            LocationId = 19,
                            LocationName = "Sombor"
                        },
                        new
                        {
                            LocationId = 20,
                            LocationName = "Sremska Mitrovica"
                        },
                        new
                        {
                            LocationId = 21,
                            LocationName = "Subotica"
                        },
                        new
                        {
                            LocationId = 22,
                            LocationName = "Užice"
                        },
                        new
                        {
                            LocationId = 23,
                            LocationName = "Čačak"
                        },
                        new
                        {
                            LocationId = 24,
                            LocationName = "Šabac"
                        },
                        new
                        {
                            LocationId = 25,
                            LocationName = "Pirot"
                        });
                });

            modelBuilder.Entity("DeliveryServiceDomain.Shipment", b =>
                {
                    b.Property<int>("ShipmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ShipmentId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ContactPersonName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("ContactPersonName");

                    b.Property<string>("ContactPersonPhone")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)")
                        .HasColumnName("ContactPersonPhone");

                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("UserId")
                        .HasDefaultValueSql("(CONVERT([int],session_context(N'PersonId')))");

                    b.Property<int>("DelivererId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("DelivererId")
                        .HasDefaultValueSql("(CONVERT([int],session_context(N'PersonId')))");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Note");

                    b.Property<string>("PostalNo")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("varchar(5)")
                        .HasColumnName("PostalNo");

                    b.Property<double>("Price")
                        .HasColumnType("float")
                        .HasColumnName("Price");

                    b.Property<int>("ReceivingLocationId")
                        .HasColumnType("int")
                        .HasColumnName("ReceivingLocationId");

                    b.Property<int>("SendingLocationId")
                        .HasColumnType("int")
                        .HasColumnName("SendingLocationId");

                    b.Property<string>("ShipmentCode")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("varchar(12)")
                        .HasColumnName("ShipmentCode");

                    b.Property<string>("ShipmentContent")
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)")
                        .HasColumnName("ShipmentContent");

                    b.Property<int>("ShipmentTypeId")
                        .HasColumnType("int")
                        .HasColumnName("ShipmentTypeId");

                    b.Property<double>("ShipmentWeight")
                        .HasColumnType("float")
                        .HasColumnName("ShipmentWeight");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)")
                        .HasColumnName("Street");

                    b.HasKey("ShipmentId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("DelivererId");

                    b.HasIndex("ReceivingLocationId");

                    b.HasIndex("SendingLocationId");

                    b.HasIndex("ShipmentTypeId");

                    b.ToTable("Shipments");
                });

            modelBuilder.Entity("DeliveryServiceDomain.ShipmentType", b =>
                {
                    b.Property<int>("ShipmentTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ShipmentTypeId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ShipmentTypeName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("ShipmentTypeName");

                    b.Property<double>("ShipmentTypePrice")
                        .HasColumnType("float")
                        .HasColumnName("ShipmentTypePrice");

                    b.HasKey("ShipmentTypeId");

                    b.ToTable("ShipmentTypes");

                    b.HasData(
                        new
                        {
                            ShipmentTypeId = 1,
                            ShipmentTypeName = "Standard",
                            ShipmentTypePrice = 220.0
                        },
                        new
                        {
                            ShipmentTypeId = 2,
                            ShipmentTypeName = "Special",
                            ShipmentTypePrice = 350.0
                        },
                        new
                        {
                            ShipmentTypeId = 3,
                            ShipmentTypeName = "International",
                            ShipmentTypePrice = 900.0
                        });
                });

            modelBuilder.Entity("DeliveryServiceDomain.Status", b =>
                {
                    b.Property<int>("StatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("StatusId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("StatusName")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("varchar(40)")
                        .HasColumnName("StatusName");

                    b.HasKey("StatusId");

                    b.ToTable("Statuses");

                    b.HasData(
                        new
                        {
                            StatusId = 1,
                            StatusName = "Scheduled"
                        },
                        new
                        {
                            StatusId = 2,
                            StatusName = "On the packaging"
                        },
                        new
                        {
                            StatusId = 3,
                            StatusName = "Stored for shipping"
                        },
                        new
                        {
                            StatusId = 4,
                            StatusName = "At the courier"
                        },
                        new
                        {
                            StatusId = 5,
                            StatusName = "In transport"
                        },
                        new
                        {
                            StatusId = 6,
                            StatusName = "Delivered"
                        },
                        new
                        {
                            StatusId = 7,
                            StatusName = "Stored on hold"
                        },
                        new
                        {
                            StatusId = 8,
                            StatusName = "Rejected"
                        },
                        new
                        {
                            StatusId = 9,
                            StatusName = "Returned to sender"
                        });
                });

            modelBuilder.Entity("DeliveryServiceDomain.StatusShipment", b =>
                {
                    b.Property<int>("StatusId")
                        .HasColumnType("int")
                        .HasColumnName("StatusId");

                    b.Property<int>("ShipmentId")
                        .HasColumnType("int")
                        .HasColumnName("ShipmentId");

                    b.Property<DateTime>("StatusTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("StatusTime")
                        .HasDefaultValueSql("(getdate())");

                    b.HasKey("StatusId", "ShipmentId");

                    b.HasIndex("ShipmentId");

                    b.ToTable("StatusShipments");
                });

            modelBuilder.Entity("DeliveryServiceDomain.AdditionalServiceShipment", b =>
                {
                    b.HasOne("DeliveryServiceDomain.AdditionalService", "AdditionalService")
                        .WithMany("Shipments")
                        .HasForeignKey("AdditionalServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DeliveryServiceDomain.Shipment", "Shipment")
                        .WithMany("AdditionalServices")
                        .HasForeignKey("ShipmentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("AdditionalService");

                    b.Navigation("Shipment");
                });

            modelBuilder.Entity("DeliveryServiceDomain.Shipment", b =>
                {
                    b.HasOne("DeliveryServiceDomain.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DeliveryServiceDomain.Deliverer", "Deliverer")
                        .WithMany()
                        .HasForeignKey("DelivererId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DeliveryServiceDomain.Location", "ReceivingLocation")
                        .WithMany("ReceivingShipments")
                        .HasForeignKey("ReceivingLocationId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DeliveryServiceDomain.Location", "SendingLocation")
                        .WithMany("SendingShipments")
                        .HasForeignKey("SendingLocationId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DeliveryServiceDomain.ShipmentType", "ShipmentType")
                        .WithMany("Shipments")
                        .HasForeignKey("ShipmentTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Deliverer");

                    b.Navigation("ReceivingLocation");

                    b.Navigation("SendingLocation");

                    b.Navigation("ShipmentType");
                });

            modelBuilder.Entity("DeliveryServiceDomain.StatusShipment", b =>
                {
                    b.HasOne("DeliveryServiceDomain.Shipment", "Shipment")
                        .WithMany("ShipmentStatuses")
                        .HasForeignKey("ShipmentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DeliveryServiceDomain.Status", "Status")
                        .WithMany("Shipments")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Shipment");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("DeliveryServiceDomain.AdditionalService", b =>
                {
                    b.Navigation("Shipments");
                });

            modelBuilder.Entity("DeliveryServiceDomain.Location", b =>
                {
                    b.Navigation("ReceivingShipments");

                    b.Navigation("SendingShipments");
                });

            modelBuilder.Entity("DeliveryServiceDomain.Shipment", b =>
                {
                    b.Navigation("AdditionalServices");

                    b.Navigation("ShipmentStatuses");
                });

            modelBuilder.Entity("DeliveryServiceDomain.ShipmentType", b =>
                {
                    b.Navigation("Shipments");
                });

            modelBuilder.Entity("DeliveryServiceDomain.Status", b =>
                {
                    b.Navigation("Shipments");
                });
#pragma warning restore 612, 618
        }
    }
}
