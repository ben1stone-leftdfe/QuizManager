using Microsoft.EntityFrameworkCore.Migrations;

namespace QuizManager.Infrastructure.Migrations
{
    public partial class addedqandanumbers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "QuestionNumber",
                table: "Questions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AnswerNumber",
                table: "Answers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a95d6ca4-fd6b-4f7e-8aaf-7c1c425bc1c6", "c0b1738e-8205-47d7-bbc9-477fd3b0c07e", "Editor", "EDITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6d19479e-bae1-4a78-a7e6-f1d1e7b38417", "e7566e51-9b95-4626-9310-87f6c0e269b6", "Viewer", "VIEWER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "76bdcfda-61fe-43e1-bbb1-bb934e3041b6", "ed495156-e3dd-44be-a8ba-4fe1f9d6f014", "Restricted", "RESTRICTED" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6d19479e-bae1-4a78-a7e6-f1d1e7b38417");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "76bdcfda-61fe-43e1-bbb1-bb934e3041b6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a95d6ca4-fd6b-4f7e-8aaf-7c1c425bc1c6");

            migrationBuilder.DropColumn(
                name: "QuestionNumber",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "AnswerNumber",
                table: "Answers");

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
    }
}
