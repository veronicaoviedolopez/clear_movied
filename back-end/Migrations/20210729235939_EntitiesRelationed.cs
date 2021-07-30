using Microsoft.EntityFrameworkCore.Migrations;

namespace back_end.Migrations
{
    public partial class EntitiesRelationed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Orden",
                table: "MoviesActors");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Orden",
                table: "MoviesActors",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
