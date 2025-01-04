using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServicePet.DataEntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class RenameColumnYearsIntoAgeInPet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Years",
                table: "PetProfiles",
                newName: "Age");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Age",
                table: "PetProfiles",
                newName: "Years");
        }
    }
}
