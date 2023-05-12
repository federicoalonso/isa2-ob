﻿// <auto-generated />
using System;
using ArenaGestor.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ArenaGestor.DataAccess.Migrations
{
    [DbContext(typeof(ArenaGestorContext))]
    partial class ArenaGestorContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.15")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ArenaGestor.Domain.Artist", b =>
                {
                    b.Property<int>("ArtistId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ArtistId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("UserId");

                    b.ToTable("Artist");
                });

            modelBuilder.Entity("ArenaGestor.Domain.ArtistBand", b =>
                {
                    b.Property<int>("ArtistId")
                        .HasColumnType("int");

                    b.Property<int>("MusicalProtagonistId")
                        .HasColumnType("int");

                    b.Property<int>("RoleArtistId")
                        .HasColumnType("int");

                    b.HasKey("ArtistId", "MusicalProtagonistId");

                    b.HasIndex("MusicalProtagonistId");

                    b.HasIndex("RoleArtistId");

                    b.ToTable("ArtistBand");
                });

            modelBuilder.Entity("ArenaGestor.Domain.Concert", b =>
                {
                    b.Property<int>("ConcertId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("LocationId")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("TicketCount")
                        .HasColumnType("int");

                    b.Property<string>("TourName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ConcertId");

                    b.HasIndex("LocationId");

                    b.ToTable("Concert");
                });

            modelBuilder.Entity("ArenaGestor.Domain.ConcertProtagonist", b =>
                {
                    b.Property<int>("ConcertId")
                        .HasColumnType("int");

                    b.Property<int>("MusicalProtagonistId")
                        .HasColumnType("int");

                    b.HasKey("ConcertId", "MusicalProtagonistId");

                    b.HasIndex("MusicalProtagonistId");

                    b.ToTable("ConcertProtagonist");
                });

            modelBuilder.Entity("ArenaGestor.Domain.Country", b =>
                {
                    b.Property<int>("CountryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("CountryId");

                    b.ToTable("Countrys");

                    b.HasData(
                        new
                        {
                            CountryId = 1,
                            Name = "Uruguay"
                        },
                        new
                        {
                            CountryId = 2,
                            Name = "Argentina"
                        });
                });

            modelBuilder.Entity("ArenaGestor.Domain.Gender", b =>
                {
                    b.Property<int>("GenderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("GenderId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Gender");
                });

            modelBuilder.Entity("ArenaGestor.Domain.Location", b =>
                {
                    b.Property<int>("LocationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<string>("Place")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("LocationId");

                    b.HasIndex("CountryId");

                    b.ToTable("Location");
                });

            modelBuilder.Entity("ArenaGestor.Domain.MusicalProtagonist", b =>
                {
                    b.Property<int>("MusicalProtagonistId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GenderId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("MusicalProtagonistId");

                    b.HasIndex("GenderId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("MusicalProtagonist");
                });

            modelBuilder.Entity("ArenaGestor.Domain.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("RoleId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Role");

                    b.HasData(
                        new
                        {
                            RoleId = 1,
                            Name = "Administrador"
                        },
                        new
                        {
                            RoleId = 2,
                            Name = "Vendedor"
                        },
                        new
                        {
                            RoleId = 3,
                            Name = "Acomodador"
                        },
                        new
                        {
                            RoleId = 4,
                            Name = "Espectador"
                        },
                        new
                        {
                            RoleId = 5,
                            Name = "Artista"
                        });
                });

            modelBuilder.Entity("ArenaGestor.Domain.RoleArtist", b =>
                {
                    b.Property<int>("RoleArtistId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("RoleArtistId");

                    b.ToTable("RoleArtist");

                    b.HasData(
                        new
                        {
                            RoleArtistId = 1,
                            Name = "Cantante"
                        },
                        new
                        {
                            RoleArtistId = 2,
                            Name = "Baterista"
                        },
                        new
                        {
                            RoleArtistId = 3,
                            Name = "Bajista"
                        },
                        new
                        {
                            RoleArtistId = 4,
                            Name = "Guitarrista"
                        },
                        new
                        {
                            RoleArtistId = 5,
                            Name = "Coro"
                        });
                });

            modelBuilder.Entity("ArenaGestor.Domain.Session", b =>
                {
                    b.Property<int>("SessionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Token")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("SessionId");

                    b.HasIndex("UserId");

                    b.ToTable("Session");
                });

            modelBuilder.Entity("ArenaGestor.Domain.Snack", b =>
                {
                    b.Property<int>("SnackId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("SnackId");

                    b.HasIndex("SnackId")
                        .IsUnique();

                    b.ToTable("Snack");
                });

            modelBuilder.Entity("ArenaGestor.Domain.Ticket", b =>
                {
                    b.Property<Guid>("TicketId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int>("ConcertId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TicketStatusId")
                        .HasColumnType("int");

                    b.HasKey("TicketId");

                    b.HasIndex("ConcertId");

                    b.HasIndex("TicketStatusId");

                    b.ToTable("Ticket");
                });

            modelBuilder.Entity("ArenaGestor.Domain.TicketStatus", b =>
                {
                    b.Property<int>("TicketStatusId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("TicketStatusId");

                    b.HasIndex("Status")
                        .IsUnique();

                    b.ToTable("TicketStatus");

                    b.HasData(
                        new
                        {
                            TicketStatusId = 1,
                            Status = "Comprado"
                        },
                        new
                        {
                            TicketStatusId = 2,
                            Status = "Utilizado"
                        });
                });

            modelBuilder.Entity("ArenaGestor.Domain.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("UserId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("User");
                });

            modelBuilder.Entity("ArenaGestor.Domain.UserRole", b =>
                {
                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("RoleId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("RoleUser");
                });

            modelBuilder.Entity("ArenaGestor.Domain.Band", b =>
                {
                    b.HasBaseType("ArenaGestor.Domain.MusicalProtagonist");

                    b.ToTable("Band");
                });

            modelBuilder.Entity("ArenaGestor.Domain.Soloist", b =>
                {
                    b.HasBaseType("ArenaGestor.Domain.MusicalProtagonist");

                    b.Property<int>("ArtistId")
                        .HasColumnType("int");

                    b.Property<int>("RoleArtistId")
                        .HasColumnType("int");

                    b.HasIndex("ArtistId");

                    b.HasIndex("RoleArtistId");

                    b.ToTable("Soloist");
                });

            modelBuilder.Entity("ArenaGestor.Domain.Artist", b =>
                {
                    b.HasOne("ArenaGestor.Domain.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ArenaGestor.Domain.ArtistBand", b =>
                {
                    b.HasOne("ArenaGestor.Domain.Artist", "Artist")
                        .WithMany("Bands")
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ArenaGestor.Domain.Band", "Band")
                        .WithMany("Artists")
                        .HasForeignKey("MusicalProtagonistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ArenaGestor.Domain.RoleArtist", "RoleArtist")
                        .WithMany()
                        .HasForeignKey("RoleArtistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Artist");

                    b.Navigation("Band");

                    b.Navigation("RoleArtist");
                });

            modelBuilder.Entity("ArenaGestor.Domain.Concert", b =>
                {
                    b.HasOne("ArenaGestor.Domain.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Location");
                });

            modelBuilder.Entity("ArenaGestor.Domain.ConcertProtagonist", b =>
                {
                    b.HasOne("ArenaGestor.Domain.Concert", "Concert")
                        .WithMany("Protagonists")
                        .HasForeignKey("ConcertId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ArenaGestor.Domain.MusicalProtagonist", "Protagonist")
                        .WithMany("Concerts")
                        .HasForeignKey("MusicalProtagonistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Concert");

                    b.Navigation("Protagonist");
                });

            modelBuilder.Entity("ArenaGestor.Domain.Location", b =>
                {
                    b.HasOne("ArenaGestor.Domain.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("ArenaGestor.Domain.MusicalProtagonist", b =>
                {
                    b.HasOne("ArenaGestor.Domain.Gender", "Gender")
                        .WithMany("MusicalProtagonists")
                        .HasForeignKey("GenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Gender");
                });

            modelBuilder.Entity("ArenaGestor.Domain.Session", b =>
                {
                    b.HasOne("ArenaGestor.Domain.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ArenaGestor.Domain.Ticket", b =>
                {
                    b.HasOne("ArenaGestor.Domain.Concert", "Concert")
                        .WithMany("Tickets")
                        .HasForeignKey("ConcertId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ArenaGestor.Domain.TicketStatus", "TicketStatus")
                        .WithMany()
                        .HasForeignKey("TicketStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Concert");

                    b.Navigation("TicketStatus");
                });

            modelBuilder.Entity("ArenaGestor.Domain.UserRole", b =>
                {
                    b.HasOne("ArenaGestor.Domain.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ArenaGestor.Domain.User", "User")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ArenaGestor.Domain.Band", b =>
                {
                    b.HasOne("ArenaGestor.Domain.MusicalProtagonist", null)
                        .WithOne()
                        .HasForeignKey("ArenaGestor.Domain.Band", "MusicalProtagonistId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ArenaGestor.Domain.Soloist", b =>
                {
                    b.HasOne("ArenaGestor.Domain.Artist", "Artist")
                        .WithMany("Soloists")
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ArenaGestor.Domain.MusicalProtagonist", null)
                        .WithOne()
                        .HasForeignKey("ArenaGestor.Domain.Soloist", "MusicalProtagonistId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("ArenaGestor.Domain.RoleArtist", "RoleArtist")
                        .WithMany()
                        .HasForeignKey("RoleArtistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Artist");

                    b.Navigation("RoleArtist");
                });

            modelBuilder.Entity("ArenaGestor.Domain.Artist", b =>
                {
                    b.Navigation("Bands");

                    b.Navigation("Soloists");
                });

            modelBuilder.Entity("ArenaGestor.Domain.Concert", b =>
                {
                    b.Navigation("Protagonists");

                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("ArenaGestor.Domain.Gender", b =>
                {
                    b.Navigation("MusicalProtagonists");
                });

            modelBuilder.Entity("ArenaGestor.Domain.MusicalProtagonist", b =>
                {
                    b.Navigation("Concerts");
                });

            modelBuilder.Entity("ArenaGestor.Domain.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("ArenaGestor.Domain.User", b =>
                {
                    b.Navigation("Roles");
                });

            modelBuilder.Entity("ArenaGestor.Domain.Band", b =>
                {
                    b.Navigation("Artists");
                });
#pragma warning restore 612, 618
        }
    }
}
