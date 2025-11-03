using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace TodoAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddPriority : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PriorityId",
                table: "TodoItems",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Priorities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Priorities", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_TodoItems_PriorityId",
                table: "TodoItems",
                column: "PriorityId");

            migrationBuilder.AddForeignKey(
                name: "FK_TodoItems_Priorities_PriorityId",
                table: "TodoItems",
                column: "PriorityId",
                principalTable: "Priorities",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TodoItems_Priorities_PriorityId",
                table: "TodoItems");

            migrationBuilder.DropTable(
                name: "Priorities");

            migrationBuilder.DropIndex(
                name: "IX_TodoItems_PriorityId",
                table: "TodoItems");

            migrationBuilder.DropColumn(
                name: "PriorityId",
                table: "TodoItems");
        }
    }
}
