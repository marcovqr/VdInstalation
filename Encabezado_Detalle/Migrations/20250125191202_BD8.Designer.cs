﻿// <auto-generated />
using System;
using Encabezado_Detalle.BD;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Encabezado_Detalle.Migrations
{
    [DbContext(typeof(CotContext))]
    [Migration("20250125191202_BD8")]
    partial class BD8
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Encabezado_Detalle.Models.Persona", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("apellidos")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("direccion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("nit")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("nombres")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("persona", (string)null);
                });

            modelBuilder.Entity("Encabezado_Detalle.Models.cot_cotizacion", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Po")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("adress")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("customer")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("id_persona")
                        .HasColumnType("int");

                    b.Property<string>("telf")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("id");

                    b.HasIndex("id_persona");

                    b.ToTable("cot_cotizacion", (string)null);
                });

            modelBuilder.Entity("Encabezado_Detalle.Models.cot_cotizacion_item", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<decimal>("Cantidad")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("Fecha")
                        .HasColumnType("datetime");

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ProductoNombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Store")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("id_cot_cotizacion")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("id_cot_cotizacion");

                    b.ToTable("cot_cotizacion_item", (string)null);
                });

            modelBuilder.Entity("Encabezado_Detalle.Models.cot_cotizacion", b =>
                {
                    b.HasOne("Encabezado_Detalle.Models.Persona", "personas")
                        .WithMany()
                        .HasForeignKey("id_persona")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("personas");
                });

            modelBuilder.Entity("Encabezado_Detalle.Models.cot_cotizacion_item", b =>
                {
                    b.HasOne("Encabezado_Detalle.Models.cot_cotizacion", "encabezado")
                        .WithMany("detalles")
                        .HasForeignKey("id_cot_cotizacion")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("encabezado");
                });

            modelBuilder.Entity("Encabezado_Detalle.Models.cot_cotizacion", b =>
                {
                    b.Navigation("detalles");
                });
#pragma warning restore 612, 618
        }
    }
}
