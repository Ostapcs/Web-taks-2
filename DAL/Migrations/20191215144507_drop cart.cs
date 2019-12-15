using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class dropcart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartProducts_Carts_CartId",
                table: "CartProducts");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CartProducts",
                table: "CartProducts");

            migrationBuilder.DropColumn(
                name: "CartId",
                table: "CartProducts");

            migrationBuilder.AlterColumn<int>(
                name: "Amount",
                table: "CartProducts",
                nullable: false,
                defaultValue: 1,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "CartProducts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CartProducts",
                table: "CartProducts",
                columns: new[] { "UserId", "ProductId" });

            migrationBuilder.AddForeignKey(
                name: "FK_CartProducts_Users_UserId",
                table: "CartProducts",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartProducts_Users_UserId",
                table: "CartProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CartProducts",
                table: "CartProducts");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "CartProducts");

            migrationBuilder.AlterColumn<int>(
                name: "Amount",
                table: "CartProducts",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldDefaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "CartId",
                table: "CartProducts",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CartProducts",
                table: "CartProducts",
                columns: new[] { "CartId", "ProductId" });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Carts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_CartProducts_Carts_CartId",
                table: "CartProducts",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "UserId");
        }
    }
}
