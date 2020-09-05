using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Goleador.Infrastructure.Migrations
{
    public partial class PomodoroAsValueObject2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pomodoro_Books_BookId1",
                table: "Pomodoro");

            migrationBuilder.DropIndex(
                name: "IX_Pomodoro_BookId1",
                table: "Pomodoro");

            migrationBuilder.DropColumn(
                name: "BookId1",
                table: "Pomodoro");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "BookId1",
                table: "Pomodoro",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pomodoro_BookId1",
                table: "Pomodoro",
                column: "BookId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Pomodoro_Books_BookId1",
                table: "Pomodoro",
                column: "BookId1",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
