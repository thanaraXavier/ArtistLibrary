using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtistLibrary.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddSolistDetailsToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SolistDetails",
                columns: table => new
                {
                    SolistDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SolistRealName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SolistAnniversary = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SolistNationality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SolistInstagram = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SolistPhoto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SolistId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SolistDetails", x => x.SolistDetailId);
                    table.ForeignKey(
                        name: "FK_SolistDetails_Solists_SolistId",
                        column: x => x.SolistId,
                        principalTable: "Solists",
                        principalColumn: "SolistId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SolistDetails_SolistId",
                table: "SolistDetails",
                column: "SolistId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SolistDetails");
        }
    }
}
