using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Oxu.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class jasdjkas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrimaryLanguage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NewsAndTag",
                columns: table => new
                {
                    NewsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TagId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NewsId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TagId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsAndTag", x => new { x.NewsId, x.TagId });
                    table.ForeignKey(
                        name: "FK_NewsAndTag_News_NewsId",
                        column: x => x.NewsId,
                        principalTable: "News",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NewsAndTag_News_NewsId1",
                        column: x => x.NewsId1,
                        principalTable: "News",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NewsAndTag_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NewsAndTag_Tags_TagId1",
                        column: x => x.TagId1,
                        principalTable: "Tags",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_NewsAndTag_NewsId1",
                table: "NewsAndTag",
                column: "NewsId1");

            migrationBuilder.CreateIndex(
                name: "IX_NewsAndTag_TagId",
                table: "NewsAndTag",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_NewsAndTag_TagId1",
                table: "NewsAndTag",
                column: "TagId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NewsAndTag");

            migrationBuilder.DropTable(
                name: "Tags");
        }
    }
}
