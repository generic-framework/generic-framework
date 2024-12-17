using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Main.Server.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class mg01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IssueTitle",
                table: "TaskEntities",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IssueTitle",
                table: "TaskEntities");
        }
    }
}
