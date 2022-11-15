using Microsoft.EntityFrameworkCore.Migrations;

namespace HR.LeaveManagement.Identity.Migrations
{
    public partial class AddUserTable2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                columns: new[] { "ConcurrencyStamp", "NormalizedName" },
                values: new object[] { "90f1c14d-c0fd-4d9f-9b99-4057747e0d95", "EMPLOYEE" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cbc43a8e-f7bb-4445-baaf-1add431ffbbf",
                columns: new[] { "ConcurrencyStamp", "NormalizedName" },
                values: new object[] { "942634b7-a762-4d94-92e1-b631c7431e97", "ADMİNİSTRATOR" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "33a31d61-dcb4-4017-bf67-3e4bdbf1c5f9", "AQAAAAEAACcQAAAAEHf+phklwBeSYEoRz/NjEE5CdkA7Kjffk0kAJYg7VlLcHWFhiO9RfHvIkFFA2lpB+w==", "3d1d1a66-3d43-44fe-96d8-8d3bbec68581" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-8574d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ad2ed8f3-b8e2-452e-a8f6-8582491644ec", "AQAAAAEAACcQAAAAEL1YqelVK+QGasMkoOf2f+G/zbyG4inZM4JlS6JbF/VEeHjWv4ytZWd8r36J/5kIUw==", "457815f2-e37c-44c4-81df-a521ee7aeb64" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                columns: new[] { "ConcurrencyStamp", "NormalizedName" },
                values: new object[] { "d732d1e4-761f-4afc-9a2f-44e923e84a19", null });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cbc43a8e-f7bb-4445-baaf-1add431ffbbf",
                columns: new[] { "ConcurrencyStamp", "NormalizedName" },
                values: new object[] { "abed813e-055b-45f3-a000-c1c51df85e6b", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c99b2f6b-23f9-44b3-945a-b195563fdeb4", "AQAAAAEAACcQAAAAELfoUYHJndLFu5xUt8V6rqCnTVjV1s6pmsB+qCw4UznTJQX3aT9Xou3Sm1VKFkcQ+w==", "cd32f1c8-6240-4eb7-b077-ba4d29752169" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-8574d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4aebfbc6-667f-4afb-88bb-23090a6da79b", "AQAAAAEAACcQAAAAEGtWiTayTIobzHgHpUYWum/DGtHeC9OcJAwYcUG0471k2ho1m3AY+pyqTq+BwugdiQ==", "d1f018a2-c55d-401d-9177-ddfc745f8c7f" });
        }
    }
}
