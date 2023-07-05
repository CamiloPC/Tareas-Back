using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace neo_regen_api.Migrations
{
    /// <inheritdoc />
    public partial class worker_task_updated4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isComplete",
                table: "WorkerTasks",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000–0000–0000-0000-000000000001",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEHKktPnYX7PWpSAkLeJGjUBvaQQqS4HUFdIsYXOimRNATGRqifg1AyRiBZlR3PzQsQ==");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isComplete",
                table: "WorkerTasks");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000–0000–0000-0000-000000000001",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAELc9rnocxZNKr6gsGEc8AjE4vWuDrkLMqFiGU23AxTW8Bzadtx50ci9wAWHOH3oqqw==");
        }
    }
}
