﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApi_ForoUnidad1.Entities;

#nullable disable

namespace WebApi_ForoUnidad1.Migrations.DbContextValoracionesMigrations
{
    [DbContext(typeof(DbContextValoraciones))]
    [Migration("20231024145505_tablaDePromedios")]
    partial class tablaDePromedios
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebApi_ForoUnidad1.Entities.Valoracion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Comentario")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("comentario");

                    b.Property<int>("ProductoId")
                        .HasColumnType("int")
                        .HasColumnName("producto_id");

                    b.Property<int>("Puntuacion")
                        .HasColumnType("int")
                        .HasColumnName("puntuacion");

                    b.HasKey("Id");

                    b.ToTable("valoraciones");
                });

            modelBuilder.Entity("WebApi_ForoUnidad1.Entities.ValoracionPromedio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ProductoId")
                        .HasColumnType("int")
                        .HasColumnName("nombre");

                    b.Property<int>("Promedio")
                        .HasColumnType("int")
                        .HasColumnName("promedio");

                    b.HasKey("Id");

                    b.ToTable("valoracion_promedio");
                });
#pragma warning restore 612, 618
        }
    }
}