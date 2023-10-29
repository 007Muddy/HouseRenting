using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseRenting.Migrations
{
    public partial class ImageUpload2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "House",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "House");
        }
    }
}
