using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RepositoryPattern.Data.Migrations
{
    /// <inheritdoc />
    public partial class d7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BrithDate",
                table: "User",
                newName: "BirthDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BirthDate",
                table: "User",
                newName: "BrithDate");
        }
    }
}
