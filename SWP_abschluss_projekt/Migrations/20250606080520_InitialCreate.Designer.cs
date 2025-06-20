﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace SWP_abschluss_projekt.Migrations
{
    [DbContext(typeof(SchulDbContext))]
    [Migration("20250606080520_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.5");

            modelBuilder.Entity("SWP_abschluss_projekt.Models.Fach", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Bezeichnung")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("LehrerId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("LehrerId");

                    b.ToTable("Faecher");
                });

            modelBuilder.Entity("SWP_abschluss_projekt.Models.Klasse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("KlassenvorstandId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("KlassenvorstandId");

                    b.ToTable("Klassen");
                });

            modelBuilder.Entity("SWP_abschluss_projekt.Models.Note", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("FachId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("SchuelerId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Wert")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("FachId");

                    b.HasIndex("SchuelerId");

                    b.ToTable("Noten");
                });

            modelBuilder.Entity("SWP_abschluss_projekt.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nachname")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PersonTyp")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("TEXT");

                    b.Property<string>("Vorname")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Person");

                    b.HasDiscriminator<string>("PersonTyp").HasValue("Person");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("SWP_abschluss_projekt.Models.Raum", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Bezeichnung")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Raeume");
                });

            modelBuilder.Entity("SWP_abschluss_projekt.Models.StundenplanEintrag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("End")
                        .HasColumnType("TEXT");

                    b.Property<int?>("FachId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("KlasseId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("RaumId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Start")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("FachId");

                    b.HasIndex("KlasseId");

                    b.HasIndex("RaumId");

                    b.ToTable("Stundenplaene");
                });

            modelBuilder.Entity("SWP_abschluss_projekt.Models.Lehrer", b =>
                {
                    b.HasBaseType("SWP_abschluss_projekt.Models.Person");

                    b.HasDiscriminator().HasValue("Lehrer");
                });

            modelBuilder.Entity("SWP_abschluss_projekt.Models.Schueler", b =>
                {
                    b.HasBaseType("SWP_abschluss_projekt.Models.Person");

                    b.Property<int?>("KlasseId")
                        .HasColumnType("INTEGER");

                    b.HasIndex("KlasseId");

                    b.HasDiscriminator().HasValue("Schueler");
                });

            modelBuilder.Entity("SWP_abschluss_projekt.Models.Fach", b =>
                {
                    b.HasOne("SWP_abschluss_projekt.Models.Lehrer", "Lehrer")
                        .WithMany("Faecher")
                        .HasForeignKey("LehrerId");

                    b.Navigation("Lehrer");
                });

            modelBuilder.Entity("SWP_abschluss_projekt.Models.Klasse", b =>
                {
                    b.HasOne("SWP_abschluss_projekt.Models.Lehrer", "Klassenvorstand")
                        .WithMany("KlassenAlsKV")
                        .HasForeignKey("KlassenvorstandId");

                    b.Navigation("Klassenvorstand");
                });

            modelBuilder.Entity("SWP_abschluss_projekt.Models.Note", b =>
                {
                    b.HasOne("SWP_abschluss_projekt.Models.Fach", "Fach")
                        .WithMany("Noten")
                        .HasForeignKey("FachId");

                    b.HasOne("SWP_abschluss_projekt.Models.Schueler", "Schueler")
                        .WithMany("Noten")
                        .HasForeignKey("SchuelerId");

                    b.Navigation("Fach");

                    b.Navigation("Schueler");
                });

            modelBuilder.Entity("SWP_abschluss_projekt.Models.StundenplanEintrag", b =>
                {
                    b.HasOne("SWP_abschluss_projekt.Models.Fach", "Fach")
                        .WithMany()
                        .HasForeignKey("FachId");

                    b.HasOne("SWP_abschluss_projekt.Models.Klasse", "Klasse")
                        .WithMany()
                        .HasForeignKey("KlasseId");

                    b.HasOne("SWP_abschluss_projekt.Models.Raum", "Raum")
                        .WithMany()
                        .HasForeignKey("RaumId");

                    b.Navigation("Fach");

                    b.Navigation("Klasse");

                    b.Navigation("Raum");
                });

            modelBuilder.Entity("SWP_abschluss_projekt.Models.Schueler", b =>
                {
                    b.HasOne("SWP_abschluss_projekt.Models.Klasse", "Klasse")
                        .WithMany("Schueler")
                        .HasForeignKey("KlasseId");

                    b.Navigation("Klasse");
                });

            modelBuilder.Entity("SWP_abschluss_projekt.Models.Fach", b =>
                {
                    b.Navigation("Noten");
                });

            modelBuilder.Entity("SWP_abschluss_projekt.Models.Klasse", b =>
                {
                    b.Navigation("Schueler");
                });

            modelBuilder.Entity("SWP_abschluss_projekt.Models.Lehrer", b =>
                {
                    b.Navigation("Faecher");

                    b.Navigation("KlassenAlsKV");
                });

            modelBuilder.Entity("SWP_abschluss_projekt.Models.Schueler", b =>
                {
                    b.Navigation("Noten");
                });
#pragma warning restore 612, 618
        }
    }
}
