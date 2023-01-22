using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryAPI.Migrations
{
    public partial class Init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SecurityAudit_Users_UserId",
                table: "SecurityAudit");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "UsersCredentials",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 24, 10, 9, 38, 556, DateTimeKind.Utc).AddTicks(1878),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2022, 10, 24, 10, 5, 12, 757, DateTimeKind.Utc).AddTicks(8907));

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "UsersBooksRented",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 24, 10, 9, 38, 556, DateTimeKind.Utc).AddTicks(747),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2022, 10, 24, 10, 5, 12, 757, DateTimeKind.Utc).AddTicks(7847));

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "SecurityAudit",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LogTime",
                table: "SecurityAudit",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 24, 10, 9, 38, 555, DateTimeKind.Utc).AddTicks(8899),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2022, 10, 24, 10, 5, 12, 757, DateTimeKind.Utc).AddTicks(6120));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Time",
                table: "Audits",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 24, 10, 9, 38, 555, DateTimeKind.Utc).AddTicks(7265),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2022, 10, 24, 10, 5, 12, 757, DateTimeKind.Utc).AddTicks(4677));

            migrationBuilder.AddForeignKey(
                name: "FK_SecurityAudit_Users_UserId",
                table: "SecurityAudit",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SecurityAudit_Users_UserId",
                table: "SecurityAudit");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "UsersCredentials",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 24, 10, 5, 12, 757, DateTimeKind.Utc).AddTicks(8907),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2022, 10, 24, 10, 9, 38, 556, DateTimeKind.Utc).AddTicks(1878));

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "UsersBooksRented",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 24, 10, 5, 12, 757, DateTimeKind.Utc).AddTicks(7847),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2022, 10, 24, 10, 9, 38, 556, DateTimeKind.Utc).AddTicks(747));

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "SecurityAudit",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LogTime",
                table: "SecurityAudit",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 24, 10, 5, 12, 757, DateTimeKind.Utc).AddTicks(6120),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2022, 10, 24, 10, 9, 38, 555, DateTimeKind.Utc).AddTicks(8899));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Time",
                table: "Audits",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 24, 10, 5, 12, 757, DateTimeKind.Utc).AddTicks(4677),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2022, 10, 24, 10, 9, 38, 555, DateTimeKind.Utc).AddTicks(7265));

            migrationBuilder.AddForeignKey(
                name: "FK_SecurityAudit_Users_UserId",
                table: "SecurityAudit",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
