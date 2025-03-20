using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServicePet.DataEntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class RenameFieldAccountIdToProfileId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AccountId",
                table: "PetProfiles",
                newName: "ProfileId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProfileId",
                table: "PetProfiles",
                newName: "AccountId");
        }
    }
}
