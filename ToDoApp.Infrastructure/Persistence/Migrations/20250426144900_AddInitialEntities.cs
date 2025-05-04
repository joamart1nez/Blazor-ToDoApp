using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoApp.Infrastructure.Migrations;

/// <inheritdoc />
public partial class AddInitialEntities : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Categories",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "The name of the category."),
                Color = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: true, comment: "The color code for the category (e.g., #FF5733)."),
                CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "The UTC timestamp when the entity was created."),
                UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "The UTC timestamp when the entity was last updated.")
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Categories", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "Tasks",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "The title of the task."),
                Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true, comment: "The detailed description of the task."),
                IsCompleted = table.Column<bool>(type: "bit", nullable: false, comment: "Indicates if the task is completed."),
                DueDate = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "The optional due date for the task."),
                Priority = table.Column<int>(type: "int", nullable: false, comment: "The priority level of the task."),
                CategoryId = table.Column<int>(type: "int", nullable: true),
                CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "The UTC timestamp when the entity was created."),
                UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "The UTC timestamp when the entity was last updated.")
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Tasks", x => x.Id);
                table.ForeignKey(
                    name: "FK_Tasks_Categories_CategoryId",
                    column: x => x.CategoryId,
                    principalTable: "Categories",
                    principalColumn: "Id");
            });

        migrationBuilder.CreateIndex(
            name: "IX_Tasks_CategoryId",
            table: "Tasks",
            column: "CategoryId");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Tasks");

        migrationBuilder.DropTable(
            name: "Categories");
    }
}
