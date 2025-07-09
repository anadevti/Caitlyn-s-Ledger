using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CaitlynsLedgerAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEntityModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Suspects_Cases_CaseId",
                table: "Suspects");

            migrationBuilder.RenameColumn(
                name: "Alibi",
                table: "Suspects",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "Relevance",
                table: "Clues",
                newName: "Title");

            migrationBuilder.AlterColumn<int>(
                name: "CaseId",
                table: "Suspects",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Suspects",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Suspects",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Suspects",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DiscoveryDate",
                table: "Clues",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Clues",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "ClosedAt",
                table: "Cases",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Cases",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_Suspects_Cases_CaseId",
                table: "Suspects",
                column: "CaseId",
                principalTable: "Cases",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Suspects_Cases_CaseId",
                table: "Suspects");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Suspects");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Suspects");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Suspects");

            migrationBuilder.DropColumn(
                name: "DiscoveryDate",
                table: "Clues");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Clues");

            migrationBuilder.DropColumn(
                name: "ClosedAt",
                table: "Cases");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Cases");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Suspects",
                newName: "Alibi");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Clues",
                newName: "Relevance");

            migrationBuilder.AlterColumn<int>(
                name: "CaseId",
                table: "Suspects",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Suspects_Cases_CaseId",
                table: "Suspects",
                column: "CaseId",
                principalTable: "Cases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
