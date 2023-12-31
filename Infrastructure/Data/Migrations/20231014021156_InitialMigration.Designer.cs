﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    [DbContext(typeof(AnimalsContext))]
    [Migration("20231014021156_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Core.Entities.Cita", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("date");

                    b.Property<TimeSpan>("Hora")
                        .HasColumnType("time");

                    b.Property<int>("IdCliente")
                        .HasColumnType("int");

                    b.Property<int>("IdMascota")
                        .HasColumnType("int");

                    b.Property<int>("IdServicio")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdCliente");

                    b.HasIndex("IdMascota");

                    b.HasIndex("IdServicio");

                    b.ToTable("cita", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Ciudad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("IdDepartamento")
                        .HasColumnType("int");

                    b.Property<string>("NombreCiudad")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("IdDepartamento");

                    b.ToTable("Ciudad", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("IdClienteDireccion")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Cliente", (string)null);
                });

            modelBuilder.Entity("Core.Entities.ClienteDireccion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Bis")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("varchar(3)");

                    b.Property<string>("Cardinal")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("varchar(4)");

                    b.Property<string>("CardinalSec")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("varchar(4)");

                    b.Property<string>("CodigoPostal")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<int>("IdCiudad")
                        .HasColumnType("int");

                    b.Property<int>("IdCliente")
                        .HasColumnType("int");

                    b.Property<string>("Letra")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("varchar(2)");

                    b.Property<string>("LetraSec")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("varchar(2)");

                    b.Property<int>("NumeroPri")
                        .HasMaxLength(3)
                        .HasColumnType("int");

                    b.Property<int>("NumeroSec")
                        .HasMaxLength(3)
                        .HasColumnType("int");

                    b.Property<int>("NumeroTer")
                        .HasMaxLength(3)
                        .HasColumnType("int");

                    b.Property<string>("Provincia")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("IdCiudad")
                        .IsUnique();

                    b.HasIndex("IdCliente")
                        .IsUnique();

                    b.ToTable("ClienteDireccion", (string)null);
                });

            modelBuilder.Entity("Core.Entities.ClienteTelefono", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("IdCliente")
                        .HasColumnType("int");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.HasKey("Id");

                    b.HasIndex("IdCliente");

                    b.ToTable("ClienteTelefono", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Departamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("IdPais")
                        .HasColumnType("int");

                    b.Property<string>("NombreDepartamento")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("IdPais");

                    b.ToTable("Departamento", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Mascota", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Especie")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("datetime");

                    b.Property<int>("IdCliente")
                        .HasColumnType("int");

                    b.Property<int>("IdRaza")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("IdCliente");

                    b.HasIndex("IdRaza")
                        .IsUnique();

                    b.ToTable("Mascota", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Pais", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("NombrePais")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Pais", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Raza", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("NombreRaza")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Raza", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Servicio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<double>("Precio")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.ToTable("Servicio", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Cita", b =>
                {
                    b.HasOne("Core.Entities.Cliente", "Clientes")
                        .WithMany("Citas")
                        .HasForeignKey("IdCliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Mascota", "Mascotas")
                        .WithMany("Citas")
                        .HasForeignKey("IdMascota")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Servicio", "Servicios")
                        .WithMany("Citas")
                        .HasForeignKey("IdServicio")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Clientes");

                    b.Navigation("Mascotas");

                    b.Navigation("Servicios");
                });

            modelBuilder.Entity("Core.Entities.Ciudad", b =>
                {
                    b.HasOne("Core.Entities.Departamento", "Departamentos")
                        .WithMany("Ciudades")
                        .HasForeignKey("IdDepartamento")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Departamentos");
                });

            modelBuilder.Entity("Core.Entities.ClienteDireccion", b =>
                {
                    b.HasOne("Core.Entities.Ciudad", "Ciudades")
                        .WithOne("ClienteDireccion")
                        .HasForeignKey("Core.Entities.ClienteDireccion", "IdCiudad")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Cliente", "Clientes")
                        .WithOne("ClienteDireccion")
                        .HasForeignKey("Core.Entities.ClienteDireccion", "IdCliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ciudades");

                    b.Navigation("Clientes");
                });

            modelBuilder.Entity("Core.Entities.ClienteTelefono", b =>
                {
                    b.HasOne("Core.Entities.Cliente", "Clientes")
                        .WithMany("ClienteTelefonos")
                        .HasForeignKey("IdCliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Clientes");
                });

            modelBuilder.Entity("Core.Entities.Departamento", b =>
                {
                    b.HasOne("Core.Entities.Pais", "Paises")
                        .WithMany("Departamentos")
                        .HasForeignKey("IdPais")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Paises");
                });

            modelBuilder.Entity("Core.Entities.Mascota", b =>
                {
                    b.HasOne("Core.Entities.Cliente", "Clientes")
                        .WithMany("Mascotas")
                        .HasForeignKey("IdCliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Raza", "Raza")
                        .WithOne("Mascotas")
                        .HasForeignKey("Core.Entities.Mascota", "IdRaza")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Clientes");

                    b.Navigation("Raza");
                });

            modelBuilder.Entity("Core.Entities.Ciudad", b =>
                {
                    b.Navigation("ClienteDireccion");
                });

            modelBuilder.Entity("Core.Entities.Cliente", b =>
                {
                    b.Navigation("Citas");

                    b.Navigation("ClienteDireccion");

                    b.Navigation("ClienteTelefonos");

                    b.Navigation("Mascotas");
                });

            modelBuilder.Entity("Core.Entities.Departamento", b =>
                {
                    b.Navigation("Ciudades");
                });

            modelBuilder.Entity("Core.Entities.Mascota", b =>
                {
                    b.Navigation("Citas");
                });

            modelBuilder.Entity("Core.Entities.Pais", b =>
                {
                    b.Navigation("Departamentos");
                });

            modelBuilder.Entity("Core.Entities.Raza", b =>
                {
                    b.Navigation("Mascotas");
                });

            modelBuilder.Entity("Core.Entities.Servicio", b =>
                {
                    b.Navigation("Citas");
                });
#pragma warning restore 612, 618
        }
    }
}
