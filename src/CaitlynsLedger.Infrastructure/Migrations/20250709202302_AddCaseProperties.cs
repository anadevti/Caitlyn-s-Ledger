using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CaitlynsLedgerAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddCaseProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Cases");

            migrationBuilder.AddColumn<bool>(
                name: "IsArchived",
                table: "Cases",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsClosed",
                table: "Cases",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsArchived",
                table: "Cases");

            migrationBuilder.DropColumn(
                name: "IsClosed",
                table: "Cases");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Cases",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
