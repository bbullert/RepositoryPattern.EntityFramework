using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RepositoryPattern.Data.Migrations
{
    /// <inheritdoc />
    public partial class d9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Audits",
                newName: "Audit");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Audit",
                newName: "Audits");
        }
    }
}
