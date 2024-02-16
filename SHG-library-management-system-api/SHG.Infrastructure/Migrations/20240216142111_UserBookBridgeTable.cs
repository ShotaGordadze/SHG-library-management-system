using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SHG.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UserBookBridgeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentBook");

            migrationBuilder.RenameTable(
                name: "Students",
                newName: "students");

            migrationBuilder.AddColumn<string>(
                name: "lastname",
                schema: "identity",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "name",
                schema: "identity",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "lastname",
                table: "students",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "student_id",
                table: "Books",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UserBook",
                columns: table => new
                {
                    books_id = table.Column<int>(type: "integer", nullable: false),
                    users_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user_book", x => new { x.books_id, x.users_id });
                    table.ForeignKey(
                        name: "fk_user_book_books_books_id",
                        column: x => x.books_id,
                        principalTable: "Books",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_user_book_users_users_id",
                        column: x => x.users_id,
                        principalSchema: "identity",
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_books_student_id",
                table: "Books",
                column: "student_id");

            migrationBuilder.CreateIndex(
                name: "ix_user_book_users_id",
                table: "UserBook",
                column: "users_id");

            migrationBuilder.AddForeignKey(
                name: "fk_books_students_student_id",
                table: "Books",
                column: "student_id",
                principalTable: "students",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_books_students_student_id",
                table: "Books");

            migrationBuilder.DropTable(
                name: "UserBook");

            migrationBuilder.DropIndex(
                name: "ix_books_student_id",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "lastname",
                schema: "identity",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "name",
                schema: "identity",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "lastname",
                table: "students");

            migrationBuilder.DropColumn(
                name: "student_id",
                table: "Books");

            migrationBuilder.RenameTable(
                name: "students",
                newName: "Students");

            migrationBuilder.CreateTable(
                name: "StudentBook",
                columns: table => new
                {
                    books_id = table.Column<int>(type: "integer", nullable: false),
                    students_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_student_book", x => new { x.books_id, x.students_id });
                    table.ForeignKey(
                        name: "fk_student_book_books_books_id",
                        column: x => x.books_id,
                        principalTable: "Books",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_student_book_students_students_id",
                        column: x => x.students_id,
                        principalTable: "Students",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_student_book_students_id",
                table: "StudentBook",
                column: "students_id");
        }
    }
}
