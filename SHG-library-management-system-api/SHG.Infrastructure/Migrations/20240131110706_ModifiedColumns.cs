using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SHG.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ModifiedColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "created",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "created_date",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "updated",
                table: "Students",
                newName: "create_date");

            migrationBuilder.RenameColumn(
                name: "updated_date",
                table: "Books",
                newName: "create_date");

            migrationBuilder.RenameColumn(
                name: "last_name",
                table: "authors",
                newName: "lastname");

            migrationBuilder.AddColumn<DateTime>(
                name: "last_change_date",
                table: "Students",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "create_date",
                table: "Categories",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "last_change_date",
                table: "Categories",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "Books",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "last_change_date",
                table: "Books",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "create_date",
                table: "authors",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "last_change_date",
                table: "authors",
                type: "timestamp with time zone",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "last_change_date",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "create_date",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "last_change_date",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "description",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "last_change_date",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "create_date",
                table: "authors");

            migrationBuilder.DropColumn(
                name: "last_change_date",
                table: "authors");

            migrationBuilder.RenameColumn(
                name: "create_date",
                table: "Students",
                newName: "updated");

            migrationBuilder.RenameColumn(
                name: "create_date",
                table: "Books",
                newName: "updated_date");

            migrationBuilder.RenameColumn(
                name: "lastname",
                table: "authors",
                newName: "last_name");

            migrationBuilder.AddColumn<DateTime>(
                name: "created",
                table: "Students",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "created_date",
                table: "Books",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
