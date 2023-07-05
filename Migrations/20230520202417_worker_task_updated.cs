using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace neo_regen_api.Migrations
{
    /// <inheritdoc />
    public partial class worker_task_updated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkerTasks_AspNetUsers_UserId",
                table: "WorkerTasks");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "WorkerTasks",
                newName: "WorkerId");

            migrationBuilder.RenameIndex(
                name: "IX_WorkerTasks_UserId",
                table: "WorkerTasks",
                newName: "IX_WorkerTasks_WorkerId");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000–0000–0000-0000-000000000001",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c7e8b806-c177-4329-b4a8-68425ff34120", "AQAAAAIAAYagAAAAEMK6NIXjlobyz3DYwaJ+bq+YUcM9PW8z9lDjgduYC/Ixh1P+yyJjbDu1yewzGRORIA==", "2fab4439-5836-4d3d-a9cb-441ad42dda25" });

            migrationBuilder.AddForeignKey(
                name: "FK_WorkerTasks_AspNetUsers_WorkerId",
                table: "WorkerTasks",
                column: "WorkerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkerTasks_AspNetUsers_WorkerId",
                table: "WorkerTasks");

            migrationBuilder.RenameColumn(
                name: "WorkerId",
                table: "WorkerTasks",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_WorkerTasks_WorkerId",
                table: "WorkerTasks",
                newName: "IX_WorkerTasks_UserId");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000–0000–0000-0000-000000000001",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "aee06e95-f108-4a8c-8c87-aa640a949eaa", "AQAAAAIAAYagAAAAEKf6KY0v7IYSphz/jF/rxNrQcFW/1TDo78bLgDnP5onFWksqtjEHc14R1vaqHHrYzw==", "5bd4ef8a-172e-43f1-ae3c-4bb67e2d9293" });

            migrationBuilder.AddForeignKey(
                name: "FK_WorkerTasks_AspNetUsers_UserId",
                table: "WorkerTasks",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
