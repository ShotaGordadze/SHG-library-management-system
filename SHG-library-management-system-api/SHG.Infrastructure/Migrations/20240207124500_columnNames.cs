using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SHG.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class columnNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookCategory_Books_BooksId",
                table: "BookCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_BookCategory_Categories_CategoriesId",
                table: "BookCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_Authors_AuthorId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentBook_Books_BooksId",
                table: "StudentBook");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentBook_Students_StudentsId",
                table: "StudentBook");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Students",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentBook",
                table: "StudentBook");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Books",
                table: "Books");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookCategory",
                table: "BookCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Authors",
                table: "Authors");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Students",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Students",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Students",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "LastChangeDate",
                table: "Students",
                newName: "last_change_date");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "Students",
                newName: "create_date");

            migrationBuilder.RenameColumn(
                name: "StudentsId",
                table: "StudentBook",
                newName: "students_id");

            migrationBuilder.RenameColumn(
                name: "BooksId",
                table: "StudentBook",
                newName: "books_id");

            migrationBuilder.RenameIndex(
                name: "IX_StudentBook_StudentsId",
                table: "StudentBook",
                newName: "ix_student_book_students_id");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Categories",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Categories",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Categories",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "LastChangeDate",
                table: "Categories",
                newName: "last_change_date");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "Categories",
                newName: "create_date");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Books",
                newName: "title");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Books",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Books",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "LastChangeDate",
                table: "Books",
                newName: "last_change_date");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "Books",
                newName: "create_date");

            migrationBuilder.RenameColumn(
                name: "AuthorId",
                table: "Books",
                newName: "author_id");

            migrationBuilder.RenameIndex(
                name: "IX_Books_AuthorId",
                table: "Books",
                newName: "ix_books_author_id");

            migrationBuilder.RenameColumn(
                name: "CategoriesId",
                table: "BookCategory",
                newName: "categories_id");

            migrationBuilder.RenameColumn(
                name: "BooksId",
                table: "BookCategory",
                newName: "books_id");

            migrationBuilder.RenameIndex(
                name: "IX_BookCategory_CategoriesId",
                table: "BookCategory",
                newName: "ix_book_category_categories_id");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Authors",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Lastname",
                table: "Authors",
                newName: "lastname");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Authors",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "LastChangeDate",
                table: "Authors",
                newName: "last_change_date");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "Authors",
                newName: "create_date");

            migrationBuilder.RenameColumn(
                name: "BirthDate",
                table: "Authors",
                newName: "birth_date");

            migrationBuilder.AddPrimaryKey(
                name: "pk_students",
                table: "Students",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_student_book",
                table: "StudentBook",
                columns: new[] { "books_id", "students_id" });

            migrationBuilder.AddPrimaryKey(
                name: "pk_categories",
                table: "Categories",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_books",
                table: "Books",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_book_category",
                table: "BookCategory",
                columns: new[] { "books_id", "categories_id" });

            migrationBuilder.AddPrimaryKey(
                name: "pk_authors",
                table: "Authors",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_book_category_books_books_id",
                table: "BookCategory",
                column: "books_id",
                principalTable: "Books",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_book_category_categories_categories_id",
                table: "BookCategory",
                column: "categories_id",
                principalTable: "Categories",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_books_authors_author_id",
                table: "Books",
                column: "author_id",
                principalTable: "Authors",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_student_book_books_books_id",
                table: "StudentBook",
                column: "books_id",
                principalTable: "Books",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_student_book_students_students_id",
                table: "StudentBook",
                column: "students_id",
                principalTable: "Students",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_book_category_books_books_id",
                table: "BookCategory");

            migrationBuilder.DropForeignKey(
                name: "fk_book_category_categories_categories_id",
                table: "BookCategory");

            migrationBuilder.DropForeignKey(
                name: "fk_books_authors_author_id",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "fk_student_book_books_books_id",
                table: "StudentBook");

            migrationBuilder.DropForeignKey(
                name: "fk_student_book_students_students_id",
                table: "StudentBook");

            migrationBuilder.DropPrimaryKey(
                name: "pk_students",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "pk_student_book",
                table: "StudentBook");

            migrationBuilder.DropPrimaryKey(
                name: "pk_categories",
                table: "Categories");

            migrationBuilder.DropPrimaryKey(
                name: "pk_books",
                table: "Books");

            migrationBuilder.DropPrimaryKey(
                name: "pk_book_category",
                table: "BookCategory");

            migrationBuilder.DropPrimaryKey(
                name: "pk_authors",
                table: "Authors");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Students",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Students",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Students",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "last_change_date",
                table: "Students",
                newName: "LastChangeDate");

            migrationBuilder.RenameColumn(
                name: "create_date",
                table: "Students",
                newName: "CreateDate");

            migrationBuilder.RenameColumn(
                name: "students_id",
                table: "StudentBook",
                newName: "StudentsId");

            migrationBuilder.RenameColumn(
                name: "books_id",
                table: "StudentBook",
                newName: "BooksId");

            migrationBuilder.RenameIndex(
                name: "ix_student_book_students_id",
                table: "StudentBook",
                newName: "IX_StudentBook_StudentsId");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Categories",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Categories",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Categories",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "last_change_date",
                table: "Categories",
                newName: "LastChangeDate");

            migrationBuilder.RenameColumn(
                name: "create_date",
                table: "Categories",
                newName: "CreateDate");

            migrationBuilder.RenameColumn(
                name: "title",
                table: "Books",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Books",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Books",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "last_change_date",
                table: "Books",
                newName: "LastChangeDate");

            migrationBuilder.RenameColumn(
                name: "create_date",
                table: "Books",
                newName: "CreateDate");

            migrationBuilder.RenameColumn(
                name: "author_id",
                table: "Books",
                newName: "AuthorId");

            migrationBuilder.RenameIndex(
                name: "ix_books_author_id",
                table: "Books",
                newName: "IX_Books_AuthorId");

            migrationBuilder.RenameColumn(
                name: "categories_id",
                table: "BookCategory",
                newName: "CategoriesId");

            migrationBuilder.RenameColumn(
                name: "books_id",
                table: "BookCategory",
                newName: "BooksId");

            migrationBuilder.RenameIndex(
                name: "ix_book_category_categories_id",
                table: "BookCategory",
                newName: "IX_BookCategory_CategoriesId");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Authors",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "lastname",
                table: "Authors",
                newName: "Lastname");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Authors",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "last_change_date",
                table: "Authors",
                newName: "LastChangeDate");

            migrationBuilder.RenameColumn(
                name: "create_date",
                table: "Authors",
                newName: "CreateDate");

            migrationBuilder.RenameColumn(
                name: "birth_date",
                table: "Authors",
                newName: "BirthDate");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Students",
                table: "Students",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentBook",
                table: "StudentBook",
                columns: new[] { "BooksId", "StudentsId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Books",
                table: "Books",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookCategory",
                table: "BookCategory",
                columns: new[] { "BooksId", "CategoriesId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Authors",
                table: "Authors",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BookCategory_Books_BooksId",
                table: "BookCategory",
                column: "BooksId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookCategory_Categories_CategoriesId",
                table: "BookCategory",
                column: "CategoriesId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Authors_AuthorId",
                table: "Books",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentBook_Books_BooksId",
                table: "StudentBook",
                column: "BooksId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentBook_Students_StudentsId",
                table: "StudentBook",
                column: "StudentsId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
