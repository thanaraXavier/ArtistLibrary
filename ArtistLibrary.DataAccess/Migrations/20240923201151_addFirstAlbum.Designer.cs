﻿// <auto-generated />
using System;
using ArtistLibrary.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ArtistLibrary.DataAccess.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240923201151_addFirstAlbum")]
    partial class addFirstAlbum
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ArtistLibrary.Models.Models.Album", b =>
                {
                    b.Property<int>("AlbumId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AlbumId"));

                    b.Property<string>("AlbumCover")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AlbumName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("AlbumRelease")
                        .HasColumnType("datetime2");

                    b.Property<string>("AlbumTracklist")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("GroupId")
                        .HasColumnType("int");

                    b.Property<int?>("SolistId")
                        .HasColumnType("int");

                    b.HasKey("AlbumId");

                    b.HasIndex("GroupId");

                    b.HasIndex("SolistId");

                    b.ToTable("Albums");

                    b.HasData(
                        new
                        {
                            AlbumId = 1,
                            AlbumCover = "https://i.imgur.com/zLLwFoq.jpeg",
                            AlbumName = "O Menino Que Queria Ser Deus",
                            AlbumRelease = new DateTime(2018, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            AlbumTracklist = "Átipico, Junho de 94, UFA, 1010, Solto, Canção para meu filho, Corra, Estouro, De lá, Eterno.",
                            SolistId = 5
                        });
                });

            modelBuilder.Entity("ArtistLibrary.Models.Models.Group", b =>
                {
                    b.Property<int>("GroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GroupId"));

                    b.Property<string>("GroupDebutDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GroupMusicGenre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GroupName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GroupPhoto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GroupId");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("ArtistLibrary.Models.Models.Solist", b =>
                {
                    b.Property<int>("SolistId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SolistId"));

                    b.Property<string>("SolistDebutDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SolistMusicGenre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SolistName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SolistPhoto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SolistId");

                    b.ToTable("Solists");
                });

            modelBuilder.Entity("ArtistLibrary.Models.Models.Album", b =>
                {
                    b.HasOne("ArtistLibrary.Models.Models.Group", "Group")
                        .WithMany()
                        .HasForeignKey("GroupId");

                    b.HasOne("ArtistLibrary.Models.Models.Solist", "Solist")
                        .WithMany()
                        .HasForeignKey("SolistId");

                    b.Navigation("Group");

                    b.Navigation("Solist");
                });
#pragma warning restore 612, 618
        }
    }
}
