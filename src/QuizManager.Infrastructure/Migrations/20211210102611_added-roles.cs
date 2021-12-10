using Microsoft.EntityFrameworkCore.Migrations;

namespace QuizManager.Infrastructure.Migrations
{
    public partial class addedroles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a78a2182-53df-4d23-9734-11805c117e6c", "990c7c6d-3b0f-40e1-9467-d438fddf3344", "Editor", "EDITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6b126938-d174-4c9a-8a0c-6bee468ba20b", "da3039d8-b2bd-4eaf-84ab-50f38f3d183a", "Viewer", "VIEWER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ef3e930b-adad-4fca-857e-d295ad64c42d", "a7d2e976-1bc9-4886-a25e-a5164d60170e", "Restricted", "RESTRICTED" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6b126938-d174-4c9a-8a0c-6bee468ba20b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a78a2182-53df-4d23-9734-11805c117e6c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ef3e930b-adad-4fca-857e-d295ad64c42d");
        }
    }
}
