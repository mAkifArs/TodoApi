using Microsoft.EntityFrameworkCore.Migrations;

namespace TodoApi.DATA.Migrations
{
    public partial class Usertodolist : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserTodoList",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    TodoId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTodoList", x => new { x.UserId, x.TodoId });
                    table.ForeignKey(
                        name: "FK_UserTodoList_TodoLists_TodoId",
                        column: x => x.TodoId,
                        principalTable: "TodoLists",
                        principalColumn: "TodoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserTodoList_UserInfos_UserId",
                        column: x => x.UserId,
                        principalTable: "UserInfos",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserTodoList_TodoId",
                table: "UserTodoList",
                column: "TodoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserTodoList");
        }
    }
}
