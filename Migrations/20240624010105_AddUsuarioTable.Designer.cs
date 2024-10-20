﻿// <auto-generated />
using System;
using CidadeLimpa.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;

#nullable disable

namespace CidadeLimpa.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20240624010105_AddUsuarioTable")]
    partial class AddUsuarioTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            OracleModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CidadeLimpa.Models.CaminhaoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Capacidade")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("IdRota")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR2(50)");

                    b.Property<string>("Placa")
                        .IsRequired()
                        .HasMaxLength(7)
                        .HasColumnType("NVARCHAR2(7)");

                    b.HasKey("Id");

                    b.HasIndex("IdRota");

                    b.ToTable("Caminhao", (string)null);
                });

            modelBuilder.Entity("CidadeLimpa.Models.ColetaModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("DataColeta")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("NVARCHAR2(10)");

                    b.Property<int>("IdCaminhao")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("IdLixeira")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("Id");

                    b.HasIndex("IdCaminhao");

                    b.HasIndex("IdLixeira");

                    b.ToTable("Coleta", (string)null);
                });

            modelBuilder.Entity("CidadeLimpa.Models.LixeiraModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Capacidade")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("Localizacao")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("NVARCHAR2(100)");

                    b.Property<decimal>("Ocupacao")
                        .HasPrecision(3, 2)
                        .HasColumnType("DECIMAL(3,2)");

                    b.HasKey("Id");

                    b.ToTable("Lixeira", (string)null);
                });

            modelBuilder.Entity("CidadeLimpa.Models.LixeiraParaColetaModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Ativo")
                        .HasColumnType("number(1)");

                    b.Property<DateTime>("DataLimite")
                        .HasColumnType("date");

                    b.Property<DateTime>("DataSolicitacao")
                        .HasColumnType("date");

                    b.Property<int>("IdLixeira")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("Id");

                    b.HasIndex("IdLixeira");

                    b.ToTable("LixeiraParaColeta", (string)null);
                });

            modelBuilder.Entity("CidadeLimpa.Models.PontoColetaModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("IdRota")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("Ponto")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("NVARCHAR2(40)");

                    b.HasKey("Id");

                    b.HasIndex("IdRota");

                    b.ToTable("PontoColeta", (string)null);
                });

            modelBuilder.Entity("CidadeLimpa.Models.RotaModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("HorarioFim")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("NVARCHAR2(5)");

                    b.Property<string>("HorarioInicio")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("NVARCHAR2(5)");

                    b.HasKey("Id");

                    b.ToTable("Rota", (string)null);
                });

            modelBuilder.Entity("CidadeLimpa.Models.UsuarioModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("NVARCHAR2(100)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("NVARCHAR2(255)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Usuario", (string)null);
                });

            modelBuilder.Entity("CidadeLimpa.Models.CaminhaoModel", b =>
                {
                    b.HasOne("CidadeLimpa.Models.RotaModel", "Rota")
                        .WithMany()
                        .HasForeignKey("IdRota")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rota");
                });

            modelBuilder.Entity("CidadeLimpa.Models.ColetaModel", b =>
                {
                    b.HasOne("CidadeLimpa.Models.CaminhaoModel", "Caminhao")
                        .WithMany()
                        .HasForeignKey("IdCaminhao")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CidadeLimpa.Models.LixeiraModel", "Lixeira")
                        .WithMany()
                        .HasForeignKey("IdLixeira")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Caminhao");

                    b.Navigation("Lixeira");
                });

            modelBuilder.Entity("CidadeLimpa.Models.LixeiraParaColetaModel", b =>
                {
                    b.HasOne("CidadeLimpa.Models.LixeiraModel", "Lixeira")
                        .WithMany()
                        .HasForeignKey("IdLixeira")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lixeira");
                });

            modelBuilder.Entity("CidadeLimpa.Models.PontoColetaModel", b =>
                {
                    b.HasOne("CidadeLimpa.Models.RotaModel", "Rota")
                        .WithMany("ListaPontosColeta")
                        .HasForeignKey("IdRota")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rota");
                });

            modelBuilder.Entity("CidadeLimpa.Models.RotaModel", b =>
                {
                    b.Navigation("ListaPontosColeta");
                });
#pragma warning restore 612, 618
        }
    }
}
