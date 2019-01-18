using Microsoft.EntityFrameworkCore.Migrations;

namespace ginx.me.Migrations.GinxMeDb
{
    public partial class UniqueIndexOnUniqueId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UniqueId",
                table: "ShortenedUrlInstances",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ShortenedUrlInstances_UniqueId",
                table: "ShortenedUrlInstances",
                column: "UniqueId",
                unique: true,
                filter: "[UniqueId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ShortenedUrlInstances_UniqueId",
                table: "ShortenedUrlInstances");

            migrationBuilder.AlterColumn<string>(
                name: "UniqueId",
                table: "ShortenedUrlInstances",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
