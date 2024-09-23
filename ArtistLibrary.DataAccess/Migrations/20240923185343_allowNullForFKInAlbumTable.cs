using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtistLibrary.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class allowNullForFKInAlbumTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Albums_Groups_GroupId",
                table: "Albums");

            migrationBuilder.DropForeignKey(
                name: "FK_Albums_Solists_SolistId",
                table: "Albums");

            migrationBuilder.AlterColumn<int>(
                name: "SolistId",
                table: "Albums",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "GroupId",
                table: "Albums",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Albums_Groups_GroupId",
                table: "Albums",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Albums_Solists_SolistId",
                table: "Albums",
                column: "SolistId",
                principalTable: "Solists",
                principalColumn: "SolistId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Albums_Groups_GroupId",
                table: "Albums");

            migrationBuilder.DropForeignKey(
                name: "FK_Albums_Solists_SolistId",
                table: "Albums");

            migrationBuilder.AlterColumn<int>(
                name: "SolistId",
                table: "Albums",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GroupId",
                table: "Albums",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Albums_Groups_GroupId",
                table: "Albums",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "GroupId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Albums_Solists_SolistId",
                table: "Albums",
                column: "SolistId",
                principalTable: "Solists",
                principalColumn: "SolistId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
