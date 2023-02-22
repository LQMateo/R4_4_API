using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace R4_4_API.Migrations
{
    public partial class v3CreationFilm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "utl_datecreation",
                schema: "r41_4",
                table: "utilisateur",
                type: "date",
                nullable: true,
                defaultValueSql: "current_date",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "current_date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "flm_datesortie",
                schema: "r41_4",
                table: "film",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "utl_datecreation",
                schema: "r41_4",
                table: "utilisateur",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "current_date",
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldNullable: true,
                oldDefaultValueSql: "current_date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "flm_datesortie",
                schema: "r41_4",
                table: "film",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldNullable: true);
        }
    }
}
