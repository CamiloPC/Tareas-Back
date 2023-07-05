using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace neo_regen_api.Migrations
{
    /// <inheritdoc />
    public partial class worker_task_updated2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000–0000–0000-0000-000000000001",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "00000000–0000–0000-0000-000000000001", "AQAAAAIAAYagAAAAELc9rnocxZNKr6gsGEc8AjE4vWuDrkLMqFiGU23AxTW8Bzadtx50ci9wAWHOH3oqqw==", "00000000–0000–0000-0000-000000000001" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000–0000–0000-0000-000000000001",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "659dcea9-cdb7-4801-a92b-893463d6e905", "AQAAAAIAAYagAAAAEB4qMR8GM4KRy7YGobAmv6PXBLarLPInGcmSXRczUiQwy07Hgwt0FzeyL5Qsdog7ug==", "f046318b-0333-4751-bb96-54508335506f" });
        }
    }
}
