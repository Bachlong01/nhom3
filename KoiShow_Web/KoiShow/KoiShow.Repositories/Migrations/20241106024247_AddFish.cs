using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KoiShow.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class AddFish : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Fish");

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "Fish",
                type: "longblob",
                nullable: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Fish");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Fish",
                type: "longtext",
                nullable: false,
                collation: "utf8mb4_0900_ai_ci")
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
