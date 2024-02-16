using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SHG.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ForgotWhatIChanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_books_students_student_id",
                table: "Books");

            migrationBuilder.DropTable(
                name: "students");

            migrationBuilder.DropIndex(
                name: "ix_books_student_id",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "student_id",
                table: "Books");

            migrationBuilder.AddColumn<DateTime>(
                name: "create_date",
                schema: "identity",
                table: "Users",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "last_change_date",
                schema: "identity",
                table: "Users",
                type: "timestamp with time zone",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "create_date",
                schema: "identity",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "last_change_date",
                schema: "identity",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "student_id",
                table: "Books",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "students",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    create_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    last_change_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    lastname = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_students", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "ix_books_student_id",
                table: "Books",
                column: "student_id");

            migrationBuilder.AddForeignKey(
                name: "fk_books_students_student_id",
                table: "Books",
                column: "student_id",
                principalTable: "students",
                principalColumn: "id");
        }
    }
}
