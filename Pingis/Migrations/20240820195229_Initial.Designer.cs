﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Pingis.Models;

#nullable disable

namespace Pingis.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240820195229_Initial")]
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

            modelBuilder.Entity("Pingis.Models.TableTennisSet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsPlayer1Serve")
                        .HasColumnType("bit");

                    b.Property<int>("Player1Score")
                        .HasColumnType("int");

                    b.Property<int>("Player2Score")
                        .HasColumnType("int");

                    b.Property<int>("ServeCounter")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Sets");
                });
#pragma warning restore 612, 618
        }
    }
}
