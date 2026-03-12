using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewsApplicationV2.Migrations
{
    /// <inheritdoc />
    public partial class AddnavigationAndFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "Articles",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_CreatedById",
                table: "Articles",
                column: "CreatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_AspNetUsers_CreatedById",
                table: "Articles",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_AspNetUsers_CreatedById",
                table: "Articles");

            migrationBuilder.DropIndex(
                name: "IX_Articles_CreatedById",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Articles");
        }
    }
}
