using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RepositoryPattern.Data.Migrations
{
    /// <inheritdoc />
    public partial class d2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Audits",
                columns: table => new
                {
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Table = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    Property = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Audits");
        }
    }
}
