using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Task_15.Migrations
{
    /// <inheritdoc />
    public partial class second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_News_Authors_authorId",
                table: "News");

            migrationBuilder.DropForeignKey(
                name: "FK_News_Categories_categoryId",
                table: "News");

            migrationBuilder.DropIndex(
                name: "IX_News_authorId",
                table: "News");

            migrationBuilder.DropIndex(
                name: "IX_News_categoryId",
                table: "News");

            migrationBuilder.DropColumn(
                name: "authorId",
                table: "News");

            migrationBuilder.DropColumn(
                name: "categoryId",
                table: "News");

            migrationBuilder.CreateIndex(
                name: "IX_News_Author_id",
                table: "News",
                column: "Author_id");

            migrationBuilder.CreateIndex(
                name: "IX_News_ctg_id",
                table: "News",
                column: "ctg_id");

            migrationBuilder.AddForeignKey(
                name: "FK_News_Authors_Author_id",
                table: "News",
                column: "Author_id",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_News_Categories_ctg_id",
                table: "News",
                column: "ctg_id",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_News_Authors_Author_id",
                table: "News");

            migrationBuilder.DropForeignKey(
                name: "FK_News_Categories_ctg_id",
                table: "News");

            migrationBuilder.DropIndex(
                name: "IX_News_Author_id",
                table: "News");

            migrationBuilder.DropIndex(
                name: "IX_News_ctg_id",
                table: "News");

            migrationBuilder.AddColumn<int>(
                name: "authorId",
                table: "News",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "categoryId",
                table: "News",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_News_authorId",
                table: "News",
                column: "authorId");

            migrationBuilder.CreateIndex(
                name: "IX_News_categoryId",
                table: "News",
                column: "categoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_News_Authors_authorId",
                table: "News",
                column: "authorId",
                principalTable: "Authors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_News_Categories_categoryId",
                table: "News",
                column: "categoryId",
                principalTable: "Categories",
                principalColumn: "Id");
        }
    }
}
