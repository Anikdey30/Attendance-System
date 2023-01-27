using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace assignment4.Migrations
{
    public partial class AddASchedulesEdit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_ClassSchedule_ScheduleClassesID",
                table: "Courses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClassSchedule",
                table: "ClassSchedule");

            migrationBuilder.RenameTable(
                name: "ClassSchedule",
                newName: "ClassSchedules");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClassSchedules",
                table: "ClassSchedules",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_ClassSchedules_ScheduleClassesID",
                table: "Courses",
                column: "ScheduleClassesID",
                principalTable: "ClassSchedules",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_ClassSchedules_ScheduleClassesID",
                table: "Courses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClassSchedules",
                table: "ClassSchedules");

            migrationBuilder.RenameTable(
                name: "ClassSchedules",
                newName: "ClassSchedule");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClassSchedule",
                table: "ClassSchedule",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_ClassSchedule_ScheduleClassesID",
                table: "Courses",
                column: "ScheduleClassesID",
                principalTable: "ClassSchedule",
                principalColumn: "ID");
        }
    }
}
