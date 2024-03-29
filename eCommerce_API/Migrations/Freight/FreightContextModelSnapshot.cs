﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using eCommerce_API.Data;

namespace eCommerce_API_RST.Migrations.Freight
{
    [DbContext(typeof(FreightContext))]
    partial class FreightContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("eCommerce_API.Models.FreightSettings", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("Active")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnName("active")
                        .HasDefaultValueSql("((1))");

                    b.Property<decimal>("FreeshippingActiveAmount")
                        .HasColumnName("freeshipping_active_amount")
                        .HasColumnType("money");

                    b.Property<decimal>("Freight")
                        .HasColumnName("freight")
                        .HasColumnType("money");

                    b.Property<decimal>("FreightRangeEnd1");

                    b.Property<decimal>("FreightRangeEnd2");

                    b.Property<decimal>("FreightRangeEnd3");

                    b.Property<decimal>("FreightRangeStart1");

                    b.Property<decimal>("FreightRangeStart2");

                    b.Property<decimal>("FreightRangeStart3");

                    b.Property<string>("Region")
                        .HasColumnName("region")
                        .HasMaxLength(250);

                    b.HasKey("Id");

                    b.ToTable("freight_settings");
                });

            modelBuilder.Entity("eCommerce_API.Models.Settings", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Access")
                        .HasColumnName("access");

                    b.Property<bool?>("BoolValue")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnName("bool_value")
                        .HasDefaultValueSql("(0)");

                    b.Property<string>("Cat")
                        .HasColumnName("cat")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("Description")
                        .HasColumnName("description")
                        .HasMaxLength(1024)
                        .IsUnicode(false);

                    b.Property<bool?>("Hidden")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnName("hidden")
                        .HasDefaultValueSql("(0)");

                    b.Property<string>("Name")
                        .HasColumnName("name")
                        .HasMaxLength(64)
                        .IsUnicode(false);

                    b.Property<string>("Value")
                        .HasColumnName("value")
                        .HasMaxLength(1024)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.HasIndex("Cat")
                        .HasName("IDX_settings_cat");

                    b.HasIndex("Hidden")
                        .HasName("IDX_settings_hidden");

                    b.HasIndex("Name")
                        .HasName("IDX_settings_name");

                    b.ToTable("settings");
                });
#pragma warning restore 612, 618
        }
    }
}
