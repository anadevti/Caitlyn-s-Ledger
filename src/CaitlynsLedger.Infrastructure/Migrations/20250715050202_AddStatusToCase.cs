using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CaitlynsLedgerAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddStatusToCase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Adicionar colunas CreatedAt e ClosedAt à tabela Cases
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Cases",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2025, 1, 1));

            migrationBuilder.AddColumn<DateTime>(
                name: "ClosedAt",
                table: "Cases",
                type: "TEXT",
                nullable: true);

            // Adicionar colunas que estão faltando na tabela Clues
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Clues",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DiscoveryDate",
                table: "Clues",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2025, 1, 1));

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Clues",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            // Adicionar colunas que estão faltando na tabela Suspects
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Suspects",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Suspects",
                type: "TEXT",
                nullable: false,
                defaultValue: "Ativo");

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Suspects",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2025, 1, 1));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Suspects",
                type: "INTEGER",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<int>(
                name: "CaseId",
                table: "Suspects",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Cases
            migrationBuilder.DropColumn(name: "CreatedAt", table: "Cases");
            migrationBuilder.DropColumn(name: "ClosedAt", table: "Cases");

            // Clues
            migrationBuilder.DropColumn(name: "Title", table: "Clues");
            migrationBuilder.DropColumn(name: "DiscoveryDate", table: "Clues");
            migrationBuilder.DropColumn(name: "Location", table: "Clues");

            // Suspects
            migrationBuilder.DropColumn(name: "Description", table: "Suspects");
            migrationBuilder.DropColumn(name: "Status", table: "Suspects");
            migrationBuilder.DropColumn(name: "StartDate", table: "Suspects");
            migrationBuilder.DropColumn(name: "IsActive", table: "Suspects");
            migrationBuilder.DropColumn(name: "CaseId", table: "Suspects");
        }
    }
}
