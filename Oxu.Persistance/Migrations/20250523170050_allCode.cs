using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Oxu.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class allCode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NewsTranslations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NewsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LanguageType = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NewsTranslations_News_NewsId",
                        column: x => x.NewsId,
                        principalTable: "News",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NewsTranslations_NewsId",
                table: "NewsTranslations",
                column: "NewsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NewsTranslations");
        }
    }
}
