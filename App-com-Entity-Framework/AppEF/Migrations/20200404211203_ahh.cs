using Microsoft.EntityFrameworkCore.Migrations;

namespace AppEF.Migrations
{
    public partial class ahh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Courses_CourseId",
                table: "Students");

            migrationBuilder.AlterColumn<int>(
                name: "CourseId",
                table: "Students",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Courses_CourseId",
                table: "Students",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Courses_CourseId",
                table: "Students");

            migrationBuilder.AlterColumn<int>(
                name: "CourseId",
                table: "Students",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Courses_CourseId",
                table: "Students",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
