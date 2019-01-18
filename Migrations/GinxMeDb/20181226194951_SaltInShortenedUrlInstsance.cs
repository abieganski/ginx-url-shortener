using Microsoft.EntityFrameworkCore.Migrations;

namespace ginx.me.Migrations.GinxMeDb
{
    public partial class SaltInShortenedUrlInstsance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Salt",
                table: "ShortenedUrlInstances",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Salt",
                table: "ShortenedUrlInstances");
        }
    }
}
