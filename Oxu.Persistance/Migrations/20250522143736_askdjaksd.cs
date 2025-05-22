using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Oxu.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class askdjaksd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HeadBannerTranslations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LanguageType = table.Column<int>(type: "int", nullable: false),
                    HeadBannerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeadBannerTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HeadBannerTranslations_HeadBanners_HeadBannerId",
                        column: x => x.HeadBannerId,
                        principalTable: "HeadBanners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HeadBannerTranslations_HeadBannerId",
                table: "HeadBannerTranslations",
                column: "HeadBannerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HeadBannerTranslations");
        }
    }
}
