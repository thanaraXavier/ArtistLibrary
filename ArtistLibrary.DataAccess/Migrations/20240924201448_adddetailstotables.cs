using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtistLibrary.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class adddetailstotables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "GroupDetails",
                columns: new[] { "MemberId", "GroupId", "MemberAnniversary", "MemberInstagram", "MemberNationality", "MemberPhoto", "MemberPosition", "MemberRealName", "MemberStageName" },
                values: new object[] { 1, 7, "02/07/1992", "felpcacife", "Brazilian", "https://i.imgur.com/LDapGbF.jpeg", "Vocalist", "Felipe Laurindo de Carvalho", "Felp22" });

            migrationBuilder.InsertData(
                table: "SolistDetails",
                columns: new[] { "SolistDetailId", "SolistAnniversary", "SolistId", "SolistInstagram", "SolistNationality", "SolistPhoto", "SolistRealName" },
                values: new object[] { 1, "21/06/1985", 2, "honeymoon", "American", "https://i.imgur.com/SLwB5GO.jpeg", "Elizabeth Woolridge Grant" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "GroupDetails",
                keyColumn: "MemberId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SolistDetails",
                keyColumn: "SolistDetailId",
                keyValue: 1);
        }
    }
}
