﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RSA.Data;

#nullable disable

namespace RSA.Migrations
{
    [DbContext(typeof(RSAContext))]
    [Migration("20220104052309_FourthCreate")]
    partial class FourthCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.1");

            modelBuilder.Entity("RSA.Modelos.Chaves.Comum", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Comum");
                });

            modelBuilder.Entity("RSA.Modelos.Chaves.Privada", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("D")
                        .HasColumnType("INTEGER");

                    b.Property<int>("N")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Privada");
                });

            modelBuilder.Entity("RSA.Modelos.Chaves.Publica", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("E")
                        .HasColumnType("INTEGER");

                    b.Property<int>("N")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Publica");
                });

            modelBuilder.Entity("RSA.Modelos.Mensagem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<bool>("Criptografada")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Msg")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("PrivadaId")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("PublicaId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("PrivadaId");

                    b.HasIndex("PublicaId");

                    b.ToTable("Mensagem");
                });

            modelBuilder.Entity("RSA.Modelos.Mensagem", b =>
                {
                    b.HasOne("RSA.Modelos.Chaves.Privada", "ChavePrivada")
                        .WithMany()
                        .HasForeignKey("PrivadaId");

                    b.HasOne("RSA.Modelos.Chaves.Publica", "ChavePublica")
                        .WithMany()
                        .HasForeignKey("PublicaId");

                    b.Navigation("ChavePrivada");

                    b.Navigation("ChavePublica");
                });
#pragma warning restore 612, 618
        }
    }
}
