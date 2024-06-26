﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SelfCheckoutMachine.Infrastructure;

#nullable disable

namespace SelfCheckoutMachine.Infrastructure.Migrations
{
    [DbContext(typeof(SelfCheckoutMachineDbContext))]
    partial class SelfCheckoutMachineDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SelfCheckoutMachine.Domain.Models.Checkout", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Payed")
                        .HasColumnType("int");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("Return")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Checkouts");
                });

            modelBuilder.Entity("SelfCheckoutMachine.Domain.Models.Stock", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<int>("MoneyValue")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Stocks", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
