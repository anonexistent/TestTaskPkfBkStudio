using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestTaskPkfBkStudio.Migrations
{
    /// <inheritdoc />
    public partial class editDbScheama : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_taskList_taskId",
                table: "taskList");

            migrationBuilder.DropIndex(
                name: "IX_taskList_userId",
                table: "taskList");

            migrationBuilder.CreateIndex(
                name: "IX_taskList_taskId",
                table: "taskList",
                column: "taskId");

            migrationBuilder.CreateIndex(
                name: "IX_taskList_userId",
                table: "taskList",
                column: "userId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_taskList_taskId",
                table: "taskList");

            migrationBuilder.DropIndex(
                name: "IX_taskList_userId",
                table: "taskList");

            migrationBuilder.CreateIndex(
                name: "IX_taskList_taskId",
                table: "taskList",
                column: "taskId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_taskList_userId",
                table: "taskList",
                column: "userId",
                unique: true);
        }
    }
}
