using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SHG.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedIssueStartEndDateToBook : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "issue_end_date",
                table: "Books",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "issue_start_date",
                table: "Books",
                type: "timestamp with time zone",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "issue_end_date",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "issue_start_date",
                table: "Books");
        }
    }
}
