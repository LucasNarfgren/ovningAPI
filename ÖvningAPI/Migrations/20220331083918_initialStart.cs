using Microsoft.EntityFrameworkCore.Migrations;

namespace ÖvningAPI.Migrations
{
    public partial class initialStart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Adresses",
                columns: table => new
                {
                    AdressId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kommun = table.Column<string>(nullable: true),
                    GatuNamn = table.Column<string>(nullable: true),
                    PostCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adresses", x => x.AdressId);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    PersonId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 25, nullable: false),
                    LastName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: false),
                    ConfirmPassword = table.Column<string>(nullable: false),
                    AdressId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.PersonId);
                    table.ForeignKey(
                        name: "FK_Persons_Adresses_AdressId",
                        column: x => x.AdressId,
                        principalTable: "Adresses",
                        principalColumn: "AdressId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Adresses",
                columns: new[] { "AdressId", "GatuNamn", "Kommun", "PostCode" },
                values: new object[] { 1, "Hertings Alle 5A", "Falkenberg", "311 45" });

            migrationBuilder.InsertData(
                table: "Adresses",
                columns: new[] { "AdressId", "GatuNamn", "Kommun", "PostCode" },
                values: new object[] { 2, "Varbergs Gatan 17", "Varberg", "432 00" });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "PersonId", "AdressId", "ConfirmPassword", "FirstName", "LastName", "Password" },
                values: new object[] { 1, 1, "hemlis123", "Lucas", "Narfgren", "hemlis123" });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "PersonId", "AdressId", "ConfirmPassword", "FirstName", "LastName", "Password" },
                values: new object[] { 3, 1, "hemlis123", "Mimmi", "Narfgren", "hemlis123" });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "PersonId", "AdressId", "ConfirmPassword", "FirstName", "LastName", "Password" },
                values: new object[] { 2, 2, "hemlis123", "Johnny", "Karlsson", "hemlis123" });

            migrationBuilder.CreateIndex(
                name: "IX_Persons_AdressId",
                table: "Persons",
                column: "AdressId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "Adresses");
        }
    }
}
