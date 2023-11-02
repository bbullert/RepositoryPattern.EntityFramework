using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RepositoryPattern.Data.Migrations
{
    /// <inheritdoc />
    public partial class d4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Property",
                table: "Audits");

            migrationBuilder.DropColumn(
                name: "Table",
                table: "Audits");

            migrationBuilder.RenameColumn(
                name: "ModifyDate",
                table: "Audits",
                newName: "ModifyDateTime");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Audits",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "TableName",
                table: "Audits",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Values",
                table: "Audits",
                type: "nvarchar",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "Audits");

            migrationBuilder.DropColumn(
                name: "TableName",
                table: "Audits");

            migrationBuilder.DropColumn(
                name: "Values",
                table: "Audits");

            migrationBuilder.RenameColumn(
                name: "ModifyDateTime",
                table: "Audits",
                newName: "ModifyDate");

            migrationBuilder.AddColumn<string>(
                name: "Property",
                table: "Audits",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Table",
                table: "Audits",
                type: "varchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");
        }
    }
}
