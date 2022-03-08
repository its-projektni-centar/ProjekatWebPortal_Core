﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjekatWebPortal_Core.Data;

namespace ProjekatWebPortal_Core.Migrations.UsersMaterijal
{
    [DbContext(typeof(UsersMaterijalDbContext))]
    [Migration("20220226160230_predmetiITipPredmeta")]
    partial class predmetiITipPredmeta
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Projekat.Models.AspNetUserCustom", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<int?>("GodinaUpisa")
                        .HasColumnType("int");

                    b.Property<string>("Ime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Prezime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SkolaId")
                        .HasColumnType("int");

                    b.Property<byte[]>("Slika")
                        .HasColumnType("varbinary(max)");

                    b.Property<int?>("SmerId")
                        .HasColumnType("int");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("Uloga")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("ProjekatWebPortal_Core.Models.PredmetModel", b =>
                {
                    b.Property<int>("predmetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("PredmetModelpredmetId")
                        .HasColumnType("int");

                    b.Property<int?>("Razred")
                        .HasColumnType("int");

                    b.Property<string>("predmetNaziv")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("predmetOpis")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("tipId")
                        .HasColumnType("int");

                    b.HasKey("predmetId");

                    b.HasIndex("PredmetModelpredmetId");

                    b.HasIndex("tipId");

                    b.ToTable("predmeti");
                });

            modelBuilder.Entity("ProjekatWebPortal_Core.Models.SkolaModel", b =>
                {
                    b.Property<int>("IdSkole")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NazivSkole")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Skraceno")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdSkole");

                    b.ToTable("Skola");
                });

            modelBuilder.Entity("ProjekatWebPortal_Core.Models.SmerModel", b =>
                {
                    b.Property<int>("smerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("SmerModelsmerId")
                        .HasColumnType("int");

                    b.Property<byte[]>("fajlIts")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("fajlMs")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("fajlNs")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("fileEkstenzijaIts")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("fileEkstenzijaMs")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("fileEkstenzijaNs")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("fileMimeTypeIts")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("fileMimeTypeMs")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("fileMimeTypeNs")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nazivFajlIts")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nazivFajlMs")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nazivFajlNs")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("smerNaziv")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("smerOpis")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("smerSkraceno")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("smerId");

                    b.HasIndex("SmerModelsmerId");

                    b.ToTable("Smer");
                });

            modelBuilder.Entity("ProjekatWebPortal_Core.Models.SmerPoSkoli", b =>
                {
                    b.Property<int>("skolaId")
                        .HasColumnType("int");

                    b.Property<int>("smerId")
                        .HasColumnType("int");

                    b.HasKey("skolaId", "smerId");

                    b.HasIndex("smerId");

                    b.ToTable("smeroviPoSkolama");
                });

            modelBuilder.Entity("ProjekatWebPortal_Core.Models.TipMaterijalModel", b =>
                {
                    b.Property<int>("tipMaterijalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("nazivTipMaterijal")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("tipMaterijalId");

                    b.ToTable("tipMaterijala");
                });

            modelBuilder.Entity("ProjekatWebPortal_Core.Models.TipPredmetaModel", b =>
                {
                    b.Property<int>("tipId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("tipNaziv")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("tipId");

                    b.ToTable("tipPredmeta");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Projekat.Models.AspNetUserCustom", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Projekat.Models.AspNetUserCustom", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Projekat.Models.AspNetUserCustom", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Projekat.Models.AspNetUserCustom", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProjekatWebPortal_Core.Models.PredmetModel", b =>
                {
                    b.HasOne("ProjekatWebPortal_Core.Models.PredmetModel", null)
                        .WithMany("predmeti")
                        .HasForeignKey("PredmetModelpredmetId");

                    b.HasOne("ProjekatWebPortal_Core.Models.TipPredmetaModel", "TipPredmetaModel")
                        .WithMany("predmeti")
                        .HasForeignKey("tipId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TipPredmetaModel");
                });

            modelBuilder.Entity("ProjekatWebPortal_Core.Models.SmerModel", b =>
                {
                    b.HasOne("ProjekatWebPortal_Core.Models.SmerModel", null)
                        .WithMany("smerovi")
                        .HasForeignKey("SmerModelsmerId");
                });

            modelBuilder.Entity("ProjekatWebPortal_Core.Models.SmerPoSkoli", b =>
                {
                    b.HasOne("ProjekatWebPortal_Core.Models.SkolaModel", "SkolaModel")
                        .WithMany()
                        .HasForeignKey("skolaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjekatWebPortal_Core.Models.SmerModel", "SmerModel")
                        .WithMany()
                        .HasForeignKey("smerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SkolaModel");

                    b.Navigation("SmerModel");
                });

            modelBuilder.Entity("ProjekatWebPortal_Core.Models.PredmetModel", b =>
                {
                    b.Navigation("predmeti");
                });

            modelBuilder.Entity("ProjekatWebPortal_Core.Models.SmerModel", b =>
                {
                    b.Navigation("smerovi");
                });

            modelBuilder.Entity("ProjekatWebPortal_Core.Models.TipPredmetaModel", b =>
                {
                    b.Navigation("predmeti");
                });
#pragma warning restore 612, 618
        }
    }
}
