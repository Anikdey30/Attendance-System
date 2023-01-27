using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace assignment4.Migrations
{
    public partial class Edit2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_ClassSchedules_ScheduleClassesID",
                table: "Courses");

            migrationBuilder.DropTable(
                name: "ClassSchedules");

            migrationBuilder.DropIndex(
                name: "IX_Courses_ScheduleClassesID",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "ScheduleClassesID",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "ScheduleId",
                table: "Courses");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "ClassSchedules",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DayAndTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalNumberOfClasses = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassSchedules", x => x.ID);
                });

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
    }
}
