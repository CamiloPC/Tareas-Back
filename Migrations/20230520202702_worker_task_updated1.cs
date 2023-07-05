using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace neo_regen_api.Migrations
{
    /// <inheritdoc />
    public partial class worker_task_updated1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000–0000–0000-0000-000000000001",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "659dcea9-cdb7-4801-a92b-893463d6e905", "ADMINISTRATOR", "AQAAAAIAAYagAAAAEB4qMR8GM4KRy7YGobAmv6PXBLarLPInGcmSXRczUiQwy07Hgwt0FzeyL5Qsdog7ug==", "f046318b-0333-4751-bb96-54508335506f", "Administrator" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000–0000–0000-0000-000000000001",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "c7e8b806-c177-4329-b4a8-68425ff34120", null, "AQAAAAIAAYagAAAAEMK6NIXjlobyz3DYwaJ+bq+YUcM9PW8z9lDjgduYC/Ixh1P+yyJjbDu1yewzGRORIA==", "2fab4439-5836-4d3d-a9cb-441ad42dda25", null });
        }
    }
}
