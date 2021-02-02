using Microsoft.EntityFrameworkCore.Migrations;

namespace QnA.Migrations
{
    public partial class renamed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProfileSource",
                table: "AspNetUsers",
                newName: "ProfileImageUrl");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProfileImageUrl",
                table: "AspNetUsers",
                newName: "ProfileSource");
        }
    }
}
