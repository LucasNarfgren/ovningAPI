using Microsoft.EntityFrameworkCore.Migrations;

namespace ÖvningAPI.Migrations
{
    public partial class addedskilltable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SkillId",
                table: "Persons",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    SkillId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SkillName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.SkillId);
                });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "SkillName" },
                values: new object[] { 1, "Trolla" });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "SkillName" },
                values: new object[] { 2, "Dansa" });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "SkillName" },
                values: new object[] { 3, "Klösa" });

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "PersonId",
                keyValue: 1,
                column: "SkillId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "PersonId",
                keyValue: 2,
                column: "SkillId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "PersonId",
                keyValue: 3,
                column: "SkillId",
                value: 3);

            migrationBuilder.CreateIndex(
                name: "IX_Persons_SkillId",
                table: "Persons",
                column: "SkillId");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Skills_SkillId",
                table: "Persons",
                column: "SkillId",
                principalTable: "Skills",
                principalColumn: "SkillId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Skills_SkillId",
                table: "Persons");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_Persons_SkillId",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "SkillId",
                table: "Persons");
        }
    }
}
