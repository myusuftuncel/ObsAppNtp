﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OgrenciBilgilendirmeApp.Context;

#nullable disable

namespace ObsApp.Migrations
{
    [DbContext(typeof(ObsDbContext))]
    [Migration("20241230210509_denememig")]
    partial class denememig
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("OgrenciBilgilendirmeApp.Model.Dersler", b =>
                {
                    b.Property<int>("DersId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DersId"));

                    b.Property<string>("DersAdi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DersKodu")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DersId");

                    b.ToTable("Derslers");
                });

            modelBuilder.Entity("OgrenciBilgilendirmeApp.Model.OgrenciDersler", b =>
                {
                    b.Property<int?>("OgrenciId")
                        .HasColumnType("int");

                    b.Property<int?>("DersId")
                        .HasColumnType("int");

                    b.HasKey("OgrenciId", "DersId");

                    b.HasIndex("DersId");

                    b.ToTable("OgrenciDerslers");
                });

            modelBuilder.Entity("OgrenciBilgilendirmeApp.Model.Ogrenciler", b =>
                {
                    b.Property<int>("OgrenciId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OgrenciId"));

                    b.Property<string>("OgrenciAd")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OgrenciNumara")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OgrenciSoyad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SinifId")
                        .HasColumnType("int");

                    b.HasKey("OgrenciId");

                    b.HasIndex("SinifId");

                    b.ToTable("Ogrencilers");
                });

            modelBuilder.Entity("OgrenciBilgilendirmeApp.Model.Siniflar", b =>
                {
                    b.Property<int>("SinifId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SinifId"));

                    b.Property<int>("Kontenjan")
                        .HasColumnType("int");

                    b.Property<string>("SinifAdi")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SinifId");

                    b.ToTable("Siniflars");
                });

            modelBuilder.Entity("OgrenciBilgilendirmeApp.Model.OgrenciDersler", b =>
                {
                    b.HasOne("OgrenciBilgilendirmeApp.Model.Dersler", "Dersler")
                        .WithMany("derslers")
                        .HasForeignKey("DersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OgrenciBilgilendirmeApp.Model.Ogrenciler", "Ogrenciler")
                        .WithMany("ogrenciDerslers")
                        .HasForeignKey("OgrenciId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dersler");

                    b.Navigation("Ogrenciler");
                });

            modelBuilder.Entity("OgrenciBilgilendirmeApp.Model.Ogrenciler", b =>
                {
                    b.HasOne("OgrenciBilgilendirmeApp.Model.Siniflar", "Siniflar")
                        .WithMany("ogrencilers")
                        .HasForeignKey("SinifId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Siniflar");
                });

            modelBuilder.Entity("OgrenciBilgilendirmeApp.Model.Dersler", b =>
                {
                    b.Navigation("derslers");
                });

            modelBuilder.Entity("OgrenciBilgilendirmeApp.Model.Ogrenciler", b =>
                {
                    b.Navigation("ogrenciDerslers");
                });

            modelBuilder.Entity("OgrenciBilgilendirmeApp.Model.Siniflar", b =>
                {
                    b.Navigation("ogrencilers");
                });
#pragma warning restore 612, 618
        }
    }
}
