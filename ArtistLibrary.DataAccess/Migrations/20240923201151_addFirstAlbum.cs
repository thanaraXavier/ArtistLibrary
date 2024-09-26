using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtistLibrary.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addFirstAlbum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Albums",
                columns: new[] { "AlbumId", "AlbumCover", "AlbumName", "AlbumRelease", "AlbumTracklist", "GroupId", "SolistId" },
                values: new object[] { 1, "https://i.imgur.com/zLLwFoq.jpeg", "O Menino Que Queria Ser Deus", new DateTime(2018, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Átipico, Junho de 94, UFA, 1010, Solto, Canção para meu filho, Corra, Estouro, De lá, Eterno.", null, 5 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Albums",
                keyColumn: "AlbumId",
                keyValue: 1);
        }
    }
}
