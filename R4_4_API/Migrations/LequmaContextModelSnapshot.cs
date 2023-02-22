﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using R4_4_API.Models.EntityFramework;

#nullable disable

namespace R4_4_API.Migrations
{
    [DbContext(typeof(LequmaContext))]
    partial class LequmaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("R4_4_API.Models.EntityFramework.Film", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("flm_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("Datesortie")
                        .HasColumnType("date")
                        .HasColumnName("flm_datesortie");

                    b.Property<decimal?>("Duree")
                        .HasColumnType("numeric(3,0)")
                        .HasColumnName("flm_duree");

                    b.Property<string>("Genre")
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)")
                        .HasColumnName("flm_genre");

                    b.Property<string>("Resume")
                        .HasColumnType("text")
                        .HasColumnName("flm_resume");

                    b.Property<string>("Titre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("flm_titre");

                    b.HasKey("Id")
                        .HasName("pk_film");

                    b.ToTable("film", "r41_4");
                });

            modelBuilder.Entity("R4_4_API.Models.EntityFramework.Notation", b =>
                {
                    b.Property<int>("Utl_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("utl_id");

                    b.Property<int>("Flm_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("flm_id");

                    b.Property<int>("note")
                        .HasColumnType("integer")
                        .HasColumnName("not_note");

                    b.HasKey("Utl_id", "Flm_id")
                        .HasName("pk_notation");

                    b.HasIndex("Flm_id");

                    b.ToTable("notation", "r41_4");

                    b.HasCheckConstraint("ck_notation_note", "not_note between 0 and 5");
                });

            modelBuilder.Entity("R4_4_API.Models.EntityFramework.Utilisateur", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("utl_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Cp")
                        .HasColumnType("char(5)")
                        .HasColumnName("utl_cp");

                    b.Property<DateTime?>("Datecreation")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("date")
                        .HasColumnName("utl_datecreation")
                        .HasDefaultValueSql("current_date");

                    b.Property<float?>("Latitude")
                        .HasColumnType("real")
                        .HasColumnName("utl_latitude");

                    b.Property<float?>("Longitude")
                        .HasColumnType("real")
                        .HasColumnName("utl_longitude");

                    b.Property<string>("Mail")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("utl_mail");

                    b.Property<string>("Mobile")
                        .HasColumnType("char(10)")
                        .HasColumnName("utl_mobile");

                    b.Property<string>("Nom")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("utl_nom");

                    b.Property<string>("Pays")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasDefaultValue("France")
                        .HasColumnName("utl_pays");

                    b.Property<string>("Prenom")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("utl_prenom");

                    b.Property<string>("Pwd")
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)")
                        .HasColumnName("utl_pwd");

                    b.Property<string>("Rue")
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasColumnName("utl_rue");

                    b.Property<string>("Ville")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("utl_ville");

                    b.HasKey("Id")
                        .HasName("pk_utilisateur");

                    b.HasIndex("Mail")
                        .IsUnique();

                    b.ToTable("utilisateur", "r41_4");
                });

            modelBuilder.Entity("R4_4_API.Models.EntityFramework.Notation", b =>
                {
                    b.HasOne("R4_4_API.Models.EntityFramework.Film", "FilmNotation")
                        .WithMany("NotationFilm")
                        .HasForeignKey("Flm_id")
                        .IsRequired()
                        .HasConstraintName("fk_notation_film");

                    b.HasOne("R4_4_API.Models.EntityFramework.Utilisateur", "UtilisateurNotation")
                        .WithMany("NotationUtilisateur")
                        .HasForeignKey("Utl_id")
                        .IsRequired()
                        .HasConstraintName("fk_notation_utilisateur");

                    b.Navigation("FilmNotation");

                    b.Navigation("UtilisateurNotation");
                });

            modelBuilder.Entity("R4_4_API.Models.EntityFramework.Film", b =>
                {
                    b.Navigation("NotationFilm");
                });

            modelBuilder.Entity("R4_4_API.Models.EntityFramework.Utilisateur", b =>
                {
                    b.Navigation("NotationUtilisateur");
                });
#pragma warning restore 612, 618
        }
    }
}
