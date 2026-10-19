using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaApp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class FixAdminPasswordHash : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000001",
                columns: ["PasswordHash", "SecurityStamp", "ConcurrencyStamp"],
                values: [
                    "AQAAAAIAAYagAAAAEORMNJTSPwqrmb2GKtm5oxli8mkCddIShGuomTmTzpYUfNBuyB9YyZyhymbYQOXTMA==",
                    "ea93155b-08c2-4539-a6d5-e922d27173e3",
                    "d476b4e7-13dc-42c4-a6a2-0c1c5e8897be"
                ]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000001",
                columns: ["PasswordHash", "SecurityStamp", "ConcurrencyStamp"],
                values: ["AQAAAAEAACcQAAAAEJ0Z1k5F6", "guid generated", "guid generated"]);
        }
    }
}
