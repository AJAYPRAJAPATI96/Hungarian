using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hungarian.Data.Migrations
{
    public partial class Step : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Feedback",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Contact = table.Column<string>(nullable: false),
                    Message = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedback", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FoodMagager",
                columns: table => new
                {
                    FId = table.Column<string>(nullable: false),
                    Fcode = table.Column<string>(nullable: true),
                    FName = table.Column<string>(nullable: true),
                    FPrice = table.Column<float>(nullable: false),
                    FDisc = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    Atri = table.Column<string>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodMagager", x => x.FId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Feedback");

            migrationBuilder.DropTable(
                name: "FoodMagager");
        }
    }
}
