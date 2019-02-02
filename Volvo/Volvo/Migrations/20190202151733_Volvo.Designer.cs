﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Volvo.Repository.Context;

namespace Volvo.Migrations
{
    [DbContext(typeof(TruckContext))]
    [Migration("20190202151733_Volvo")]
    partial class Volvo
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Volvo.Models.Truck", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Chassis")
                        .IsRequired();

                    b.Property<DateTime>("DateTimeCreate");

                    b.Property<DateTime>("DateTimeModification");

                    b.Property<DateTime>("ManufactureYear");

                    b.Property<int>("ResponsableId");

                    b.Property<bool>("Status");

                    b.HasKey("Id");

                    b.ToTable("Truck");
                });

            modelBuilder.Entity("Volvo.Models.TruckModel", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<Guid>("TruckId");

                    b.Property<string>("Color");

                    b.Property<DateTime>("DateTimeCreate");

                    b.Property<DateTime>("DateTimeModification");

                    b.Property<string>("Engine");

                    b.Property<DateTime>("ModelYear");

                    b.Property<string>("Potence");

                    b.Property<int>("ResponsableId");

                    b.Property<bool>("Status");

                    b.HasKey("Id", "TruckId");

                    b.HasAlternateKey("Id");

                    b.HasIndex("TruckId")
                        .IsUnique();

                    b.ToTable("TruckModel");
                });

            modelBuilder.Entity("Volvo.Models.TruckModel", b =>
                {
                    b.HasOne("Volvo.Models.Truck", "Truck")
                        .WithOne("TruckModel")
                        .HasForeignKey("Volvo.Models.TruckModel", "TruckId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
