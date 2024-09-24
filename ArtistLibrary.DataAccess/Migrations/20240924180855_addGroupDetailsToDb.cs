using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtistLibrary.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addGroupDetailsToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GroupDetails",
                columns: table => new
                {
                    MemberId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberStageName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MemberRealName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MemberAnniversary = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MemberNationality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MemberPosition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MemberPhoto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MemberInstagram = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GroupId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupDetails", x => x.MemberId);
                    table.ForeignKey(
                        name: "FK_GroupDetails_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "GroupId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GroupDetails_GroupId",
                table: "GroupDetails",
                column: "GroupId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroupDetails");
        }
    }
}
