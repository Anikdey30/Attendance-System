using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace assignment4.Migrations
{
    public partial class drop1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseAttendances");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CourseAttendances",
                columns: table => new
                {
                    CourseID = table.Column<int>(type: "int", nullable: false),
                    AttendanceID = table.Column<int>(type: "int", nullable: false),
                    StudentAttendanceID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseAttendances", x => new { x.CourseID, x.AttendanceID });
                    table.ForeignKey(
                        name: "FK_CourseAttendances_Courses_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Courses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseAttendances_StudentAttendances_StudentAttendanceID",
                        column: x => x.StudentAttendanceID,
                        principalTable: "StudentAttendances",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseAttendances_StudentAttendanceID",
                table: "CourseAttendances",
                column: "StudentAttendanceID");
        }
    }
}
