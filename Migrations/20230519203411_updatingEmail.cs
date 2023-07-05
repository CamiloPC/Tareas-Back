using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace neo_regen_api.Migrations
{
    /// <inheritdoc />
    public partial class updatingEmail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000–0000–0000-0000-000000000001",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "PasswordHash", "SecurityStamp" },
                values: new object[] { "aee06e95-f108-4a8c-8c87-aa640a949eaa", "ADMIN@LOCALHOST.COM", "AQAAAAIAAYagAAAAEKf6KY0v7IYSphz/jF/rxNrQcFW/1TDo78bLgDnP5onFWksqtjEHc14R1vaqHHrYzw==", "5bd4ef8a-172e-43f1-ae3c-4bb67e2d9293" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000–0000–0000-0000-000000000001",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c5cdcadf-eefb-42b6-ab4b-b43b32c3fea3", null, "AQAAAAIAAYagAAAAEKaj0JNGdp9YTe+VglgNhUnZf1vUOrApBoNohRZX8Cvk8o4bcWM+vDltCz20an1hbw==", "6609fc8e-958a-4802-9d2c-f6de6ec3994c" });
        }
    }
}
