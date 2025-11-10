using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    // MIGRATION DOSYALARINA MANUAL DEĞIŞIKLIK YAPILMAMALI!
    /// <inheritdoc />
    public partial class UpdateBrandEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LogoUrl",
                table: "Brands",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "Premium",
                table: "Brands",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<double>(
                name: "Rating",
                table: "Brands",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LogoUrl",
                table: "Brands");

            migrationBuilder.DropColumn(
                name: "Premium",
                table: "Brands");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Brands");
        }
    }
}
