using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Goleador.Infrastructure.Migrations
{
    public partial class PomodoroAsValueObjects : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pomodoros_Books_BookId",
                table: "Pomodoros");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pomodoros",
                table: "Pomodoros");

            migrationBuilder.RenameTable(
                name: "Pomodoros",
                newName: "Pomodoro");

            migrationBuilder.RenameIndex(
                name: "IX_Pomodoros_BookId",
                table: "Pomodoro",
                newName: "IX_Pomodoro_BookId");

            migrationBuilder.AlterColumn<Guid>(
                name: "BookId",
                table: "Pomodoro",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "BookId1",
                table: "Pomodoro",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pomodoro",
                table: "Pomodoro",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Pomodoro_BookId1",
                table: "Pomodoro",
                column: "BookId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Pomodoro_Books_BookId",
                table: "Pomodoro",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pomodoro_Books_BookId1",
                table: "Pomodoro",
                column: "BookId1",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pomodoro_Books_BookId",
                table: "Pomodoro");

            migrationBuilder.DropForeignKey(
                name: "FK_Pomodoro_Books_BookId1",
                table: "Pomodoro");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pomodoro",
                table: "Pomodoro");

            migrationBuilder.DropIndex(
                name: "IX_Pomodoro_BookId1",
                table: "Pomodoro");

            migrationBuilder.DropColumn(
                name: "BookId1",
                table: "Pomodoro");

            migrationBuilder.RenameTable(
                name: "Pomodoro",
                newName: "Pomodoros");

            migrationBuilder.RenameIndex(
                name: "IX_Pomodoro_BookId",
                table: "Pomodoros",
                newName: "IX_Pomodoros_BookId");

            migrationBuilder.AlterColumn<Guid>(
                name: "BookId",
                table: "Pomodoros",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pomodoros",
                table: "Pomodoros",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pomodoros_Books_BookId",
                table: "Pomodoros",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
