using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Notification.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class NotificationDbInfrastrucutre : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "Users",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TemplateType",
                table: "NotificationTemplates",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ErrorMessage",
                table: "NotificationHistories",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsSuccessful",
                table: "NotificationHistories",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "TemplateType",
                table: "NotificationTemplates");

            migrationBuilder.DropColumn(
                name: "ErrorMessage",
                table: "NotificationHistories");

            migrationBuilder.DropColumn(
                name: "IsSuccessful",
                table: "NotificationHistories");
        }
    }
}
