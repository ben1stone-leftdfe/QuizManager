using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QuizManager.Infrastructure.Migrations
{
    public partial class quizaddauthortId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quizzes_Organisations_OrganisationId",
                table: "Quizzes");

            migrationBuilder.AlterColumn<Guid>(
                name: "OrganisationId",
                table: "Quizzes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "AuthorId",
                table: "Quizzes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddForeignKey(
                name: "FK_Quizzes_Organisations_OrganisationId",
                table: "Quizzes",
                column: "OrganisationId",
                principalTable: "Organisations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quizzes_Organisations_OrganisationId",
                table: "Quizzes");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "Quizzes");

            migrationBuilder.AlterColumn<Guid>(
                name: "OrganisationId",
                table: "Quizzes",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Quizzes_Organisations_OrganisationId",
                table: "Quizzes",
                column: "OrganisationId",
                principalTable: "Organisations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
