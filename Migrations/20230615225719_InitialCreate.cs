using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YourAnimeList.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AnimeList",
                columns: table => new
                {
                    AnimeListId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AnimeName = table.Column<string>(type: "TEXT", nullable: true),
                    AnimeRating = table.Column<int>(type: "INTEGER", nullable: false),
                    AnimeRank = table.Column<int>(type: "INTEGER", nullable: false),
                    IsAnimeOnList = table.Column<bool>(type: "INTEGER", nullable: false),
                    AnimeSynopsis = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimeList", x => x.AnimeListId);
                });

            migrationBuilder.CreateTable(
                name: "AnimeCharacters",
                columns: table => new
                {
                    AnimeCharactersId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AnimeCharactersName = table.Column<string>(type: "TEXT", nullable: true),
                    AnimeListId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimeCharacters", x => x.AnimeCharactersId);
                    table.ForeignKey(
                        name: "FK_AnimeCharacters_AnimeList_AnimeListId",
                        column: x => x.AnimeListId,
                        principalTable: "AnimeList",
                        principalColumn: "AnimeListId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VA",
                columns: table => new
                {
                    VAId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    VAName = table.Column<string>(type: "TEXT", nullable: true),
                    AnimeListId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VA", x => x.VAId);
                    table.ForeignKey(
                        name: "FK_VA_AnimeList_AnimeListId",
                        column: x => x.AnimeListId,
                        principalTable: "AnimeList",
                        principalColumn: "AnimeListId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnimeCharacters_AnimeListId",
                table: "AnimeCharacters",
                column: "AnimeListId");

            migrationBuilder.CreateIndex(
                name: "IX_VA_AnimeListId",
                table: "VA",
                column: "AnimeListId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnimeCharacters");

            migrationBuilder.DropTable(
                name: "VA");

            migrationBuilder.DropTable(
                name: "AnimeList");
        }
    }
}
