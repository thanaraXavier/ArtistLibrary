using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtistLibrary.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addAlbumsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Albums",
                columns: table => new
                {
                    AlbumId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlbumName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AlbumTracklist = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AlbumRelease = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AlbumCover = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GroupId = table.Column<int>(type: "int", nullable: false),
                    SolistId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Albums", x => x.AlbumId);
                    table.ForeignKey(
                        name: "FK_Albums_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "GroupId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Albums_Solists_SolistId",
                        column: x => x.SolistId,
                        principalTable: "Solists",
                        principalColumn: "SolistId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Albums_GroupId",
                table: "Albums",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Albums_SolistId",
                table: "Albums",
                column: "SolistId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Albums");
        }
    }
}
