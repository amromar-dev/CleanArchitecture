﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using CleanArchitecture.Infrastructure.Persistence.EntityFramework;

#nullable disable

namespace CleanArchitecture.Infrastructure.Persistence.EntityFramework.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240823182515_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CleanArchitecture.Domain.Samples.Sample", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Samples", (string)null);
                });

            modelBuilder.Entity("CleanArchitecture.Domain.Samples.Sample", b =>
                {
                    b.OwnsOne("CleanArchitecture.Domain.Base.ValueTypes.Auditing", "Auditing", b1 =>
                        {
                            b1.Property<int>("SampleId")
                                .HasColumnType("int");

                            b1.Property<DateTimeOffset>("CreatedAt")
                                .HasColumnType("datetimeoffset")
                                .HasColumnName("CreatedAt");

                            b1.Property<int>("CreatedBy")
                                .HasColumnType("int")
                                .HasColumnName("CreatedBy");

                            b1.Property<DateTimeOffset?>("DeletedAt")
                                .HasColumnType("datetimeoffset")
                                .HasColumnName("DeletedAt");

                            b1.Property<int?>("DeletedBy")
                                .HasColumnType("int")
                                .HasColumnName("DeletedBy");

                            b1.Property<bool>("IsDeleted")
                                .HasColumnType("bit")
                                .HasColumnName("IsDeleted");

                            b1.Property<DateTimeOffset?>("ModifiedAt")
                                .HasColumnType("datetimeoffset")
                                .HasColumnName("ModifiedAt");

                            b1.Property<int?>("ModifiedBy")
                                .HasColumnType("int")
                                .HasColumnName("ModifiedBy");

                            b1.HasKey("SampleId");

                            b1.ToTable("Samples");

                            b1.WithOwner()
                                .HasForeignKey("SampleId");
                        });

                    b.Navigation("Auditing");
                });
#pragma warning restore 612, 618
        }
    }
}
