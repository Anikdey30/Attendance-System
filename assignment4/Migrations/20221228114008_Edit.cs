using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace assignment4.Migrations
{
    public partial class Edit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ScheduleClassesID",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ScheduleId",
                table: "Courses",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DayAndTime",
                table: "ClassSchedules",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_ScheduleClassesID",
                table: "Courses",
                column: "ScheduleClassesID");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_ClassSchedules_ScheduleClassesID",
                table: "Courses",
                column: "ScheduleClassesID",
                principalTable: "ClassSchedules",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_ClassSchedules_ScheduleClassesID",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_ScheduleClassesID",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "ScheduleClassesID",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "ScheduleId",
                table: "Courses");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DayAndTime",
                table: "ClassSchedules",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
