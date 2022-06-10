using Microsoft.EntityFrameworkCore.Migrations;

namespace Projekt_Sii_WK.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Klienci",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nazwisko = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Numer_tel = table.Column<int>(type: "int", maxLength: 9, nullable: false),
                    PojazdId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klienci", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pojazdy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rejestracja = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    Marka = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pojazdy", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Serwis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Garaz = table.Column<int>(type: "int", nullable: false),
                    Pracownik = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rodzaj_wady = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PojazdId = table.Column<int>(type: "int", nullable: false),
                    KlientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Serwis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Serwis_Klienci_KlientId",
                        column: x => x.KlientId,
                        principalTable: "Klienci",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Serwis_Pojazdy_PojazdId",
                        column: x => x.PojazdId,
                        principalTable: "Pojazdy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Serwis_KlientId",
                table: "Serwis",
                column: "KlientId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Serwis_PojazdId",
                table: "Serwis",
                column: "PojazdId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Serwis");

            migrationBuilder.DropTable(
                name: "Klienci");

            migrationBuilder.DropTable(
                name: "Pojazdy");
        }
    }
}
