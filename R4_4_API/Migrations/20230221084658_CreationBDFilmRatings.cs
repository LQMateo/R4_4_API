using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace R4_4_API.Migrations
{
    /// <inheritdoc />
    public partial class CreationBDFilmRatings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "r41_4");

            migrationBuilder.CreateTable(
                name: "film",
                schema: "r41_4",
                columns: table => new
                {
                    flm_id = table.Column<int>(type: "integer", nullable: false, defaultValueSql: "nextval('film_id_seq'::regclass)"),
                    flm_titre = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    flm_resume = table.Column<string>(type: "text", nullable: true),
                    flm_datesortie = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    flm_duree = table.Column<decimal>(type: "numeric(3,0)", nullable: true),
                    flm_genre = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_film", x => x.flm_id);
                });

            migrationBuilder.CreateTable(
                name: "utilisateur",
                schema: "r41_4",
                columns: table => new
                {
                    utl_id = table.Column<int>(type: "integer", nullable: false, defaultValueSql: "nextval('utilisateur_id_seq'::regclass)"),
                    utl_nom = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    utl_prenom = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    utl_mobile = table.Column<string>(type: "char(10)", nullable: true),
                    utl_mail = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    utl_pwd = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true),
                    utl_rue = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    utl_cp = table.Column<string>(type: "char(5)", nullable: true),
                    utl_ville = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    utl_pays = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true, defaultValue: "France"),
                    utl_latitude = table.Column<float>(type: "real", nullable: true),
                    utl_longitude = table.Column<float>(type: "real", nullable: true),
                    utl_datecreation = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "current_date")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_utilisateur", x => x.utl_id);
                });

            migrationBuilder.CreateTable(
                name: "Avis",
                columns: table => new
                {
                    utl_id = table.Column<int>(type: "integer", nullable: false),
                    flm_id = table.Column<int>(type: "integer", nullable: false),
                    not_note = table.Column<int>(type: "integer", nullable: false),
                    FilmNotationId = table.Column<int>(type: "integer", nullable: false),
                    UtilisateurNotationId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_notation", x => new { x.utl_id, x.flm_id });
                    table.CheckConstraint("ck_notation_note", "not_note between 0 and 5");
                    table.ForeignKey(
                        name: "fk_notation_film",
                        column: x => x.FilmNotationId,
                        principalSchema: "r41_4",
                        principalTable: "film",
                        principalColumn: "flm_id");
                    table.ForeignKey(
                        name: "fk_notation_utilisateur",
                        column: x => x.UtilisateurNotationId,
                        principalSchema: "r41_4",
                        principalTable: "utilisateur",
                        principalColumn: "utl_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Avis_FilmNotationId",
                table: "Avis",
                column: "FilmNotationId");

            migrationBuilder.CreateIndex(
                name: "IX_Avis_UtilisateurNotationId",
                table: "Avis",
                column: "UtilisateurNotationId");

            migrationBuilder.CreateIndex(
                name: "IX_utilisateur_utl_mail",
                schema: "r41_4",
                table: "utilisateur",
                column: "utl_mail",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Avis");

            migrationBuilder.DropTable(
                name: "film",
                schema: "r41_4");

            migrationBuilder.DropTable(
                name: "utilisateur",
                schema: "r41_4");
        }
    }
}
