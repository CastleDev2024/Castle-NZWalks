using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalksAPI.Migrations
{
    /// <inheritdoc />
    public partial class BaseData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("04bab3cb-2a9d-4c99-9644-23870a885b00"), "Easy" },
                    { new Guid("89cb3e26-d668-41d2-a177-04a3cb2f4db3"), "Medium" },
                    { new Guid("d31e5887-07a2-4494-aefb-837ef904e64d"), "Hard" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("0565d05f-6397-4d70-853b-fe4fbea1c712"), "AKL", "Auckland", null },
                    { new Guid("5d73d793-c52f-47f4-878a-0e89494341ec"), "BOP", "Bay of Plenty", null },
                    { new Guid("6bb31fa4-4bf2-4881-ac65-9f53c5d5a33d"), "NSN", "Nelson", null },
                    { new Guid("78fc08c3-c4b0-4023-b8af-28b2bd7a0346"), "NTL", "Northland", null },
                    { new Guid("853f7cb2-9815-462f-b434-baa1cc795f10"), "WGN", "Wellington", null },
                    { new Guid("883ea05d-befa-447f-9512-191ef201392c"), "STL", "Southland", null },
                    { new Guid("8fc1728e-1a44-4d99-a12a-642ad57fc0da"), "BOP", "Bay of Plenty", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("04bab3cb-2a9d-4c99-9644-23870a885b00"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("89cb3e26-d668-41d2-a177-04a3cb2f4db3"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("d31e5887-07a2-4494-aefb-837ef904e64d"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("0565d05f-6397-4d70-853b-fe4fbea1c712"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("5d73d793-c52f-47f4-878a-0e89494341ec"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("6bb31fa4-4bf2-4881-ac65-9f53c5d5a33d"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("78fc08c3-c4b0-4023-b8af-28b2bd7a0346"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("853f7cb2-9815-462f-b434-baa1cc795f10"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("883ea05d-befa-447f-9512-191ef201392c"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("8fc1728e-1a44-4d99-a12a-642ad57fc0da"));
        }
    }
}
