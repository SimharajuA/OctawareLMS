using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OctawareLMS.Migrations
{
    public partial class updatedLeaveRequestTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_leaveRequests_EmployeeId",
                table: "leaveRequests",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_leaveRequests_employees_EmployeeId",
                table: "leaveRequests",
                column: "EmployeeId",
                principalTable: "employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_leaveRequests_employees_EmployeeId",
                table: "leaveRequests");

            migrationBuilder.DropIndex(
                name: "IX_leaveRequests_EmployeeId",
                table: "leaveRequests");
        }
    }
}
