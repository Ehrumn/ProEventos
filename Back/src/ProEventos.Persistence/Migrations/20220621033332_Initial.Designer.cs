﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ProEventos.Persistence.Contextos;

namespace ProEventos.Persistence.Migrations
{
    [DbContext(typeof(ProEventosContext))]
    [Migration("20220621033332_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            modelBuilder.Entity("ProEventos.Domain.Evento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

                    b.Property<DateTime?>("DataEvento")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("ImagemURL")
                        .HasColumnType("text");

                    b.Property<string>("Local")
                        .HasColumnType("text");

                    b.Property<int>("QtdPessoas")
                        .HasColumnType("integer");

                    b.Property<string>("Telefone")
                        .HasColumnType("text");

                    b.Property<string>("Tema")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Eventos");
                });

            modelBuilder.Entity("ProEventos.Domain.Lote", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

                    b.Property<DateTime?>("DataFim")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("DataInicio")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("EventoId")
                        .HasColumnType("integer");

                    b.Property<string>("Nome")
                        .HasColumnType("text");

                    b.Property<decimal>("Preco")
                        .HasColumnType("numeric");

                    b.Property<int>("Quantidade")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("EventoId");

                    b.ToTable("Lotes");
                });

            modelBuilder.Entity("ProEventos.Domain.Palestrante", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("ImagemURL")
                        .HasColumnType("text");

                    b.Property<string>("MiniCurriculo")
                        .HasColumnType("text");

                    b.Property<string>("Nome")
                        .HasColumnType("text");

                    b.Property<string>("Telefone")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Palestrantes");
                });

            modelBuilder.Entity("ProEventos.Domain.PalestranteEvento", b =>
                {
                    b.Property<int>("EventoId")
                        .HasColumnType("integer");

                    b.Property<int>("PalestranteId")
                        .HasColumnType("integer");

                    b.HasKey("EventoId", "PalestranteId");

                    b.HasIndex("PalestranteId");

                    b.ToTable("PalestrantesEventos");
                });

            modelBuilder.Entity("ProEventos.Domain.RedeSocial", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

                    b.Property<int?>("EventoId")
                        .HasColumnType("integer");

                    b.Property<string>("Nome")
                        .HasColumnType("text");

                    b.Property<int?>("PalestranteId")
                        .HasColumnType("integer");

                    b.Property<string>("URL")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.HasIndex("EventoId");

                    b.HasIndex("PalestranteId");

                    b.ToTable("RedeSocials");
                });

            modelBuilder.Entity("ProEventos.Domain.Lote", b =>
                {
                    b.HasOne("ProEventos.Domain.Evento", "Evento")
                        .WithMany("Lote")
                        .HasForeignKey("EventoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Evento");
                });

            modelBuilder.Entity("ProEventos.Domain.PalestranteEvento", b =>
                {
                    b.HasOne("ProEventos.Domain.Evento", "Evento")
                        .WithMany("PalestrantesEventos")
                        .HasForeignKey("EventoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProEventos.Domain.Palestrante", "Palestrante")
                        .WithMany("PalestrantesEventos")
                        .HasForeignKey("PalestranteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Evento");

                    b.Navigation("Palestrante");
                });

            modelBuilder.Entity("ProEventos.Domain.RedeSocial", b =>
                {
                    b.HasOne("ProEventos.Domain.Evento", "Evento")
                        .WithMany("RedesSociais")
                        .HasForeignKey("EventoId");

                    b.HasOne("ProEventos.Domain.Palestrante", "Palestrante")
                        .WithMany("RedesSociais")
                        .HasForeignKey("PalestranteId");

                    b.Navigation("Evento");

                    b.Navigation("Palestrante");
                });

            modelBuilder.Entity("ProEventos.Domain.Evento", b =>
                {
                    b.Navigation("Lote");

                    b.Navigation("PalestrantesEventos");

                    b.Navigation("RedesSociais");
                });

            modelBuilder.Entity("ProEventos.Domain.Palestrante", b =>
                {
                    b.Navigation("PalestrantesEventos");

                    b.Navigation("RedesSociais");
                });
#pragma warning restore 612, 618
        }
    }
}
