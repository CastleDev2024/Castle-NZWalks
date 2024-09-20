using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NZWalksAPI.Migrations.NZWalksAuthDB
{
    /// <inheritdoc />
    public partial class AuthorisationRolesAddedModified : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "36ed0cf3-a025-4052-bb05-c3bbf7b999b6",
                column: "NormalizedName",
                value: "WRITER");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d307a0a4-9e99-45f1-a28a-af1ca37a8dff",
                column: "NormalizedName",
                value: "READER");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "36ed0cf3-a025-4052-bb05-c3bbf7b999b6",
                column: "NormalizedName",
                value: "writer");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d307a0a4-9e99-45f1-a28a-af1ca37a8dff",
                column: "NormalizedName",
                value: "reader");
        }
    }
}
