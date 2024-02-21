using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace medicaton.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "medications",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EnglishName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    usedfor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    about = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medications", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "warnings",
                columns: table => new
                {
                    WarningName = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_warnings", x => x.WarningName);
                });

            migrationBuilder.CreateTable(
                name: "medicationWarningJoins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedicationName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    WarningName = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medicationWarningJoins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_medicationWarningJoins_medications_MedicationName",
                        column: x => x.MedicationName,
                        principalTable: "medications",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_medicationWarningJoins_warnings_WarningName",
                        column: x => x.WarningName,
                        principalTable: "warnings",
                        principalColumn: "WarningName",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_medicationWarningJoins_MedicationName",
                table: "medicationWarningJoins",
                column: "MedicationName");

            migrationBuilder.CreateIndex(
                name: "IX_medicationWarningJoins_WarningName",
                table: "medicationWarningJoins",
                column: "WarningName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "medicationWarningJoins");

            migrationBuilder.DropTable(
                name: "medications");

            migrationBuilder.DropTable(
                name: "warnings");
        }
    }
}
