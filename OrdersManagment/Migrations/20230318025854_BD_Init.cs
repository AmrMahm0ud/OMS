using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrdersManagment.Migrations
{
    /// <inheritdoc />
    public partial class BD_Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    userPassword = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    orderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    orderAmount = table.Column<double>(type: "float", nullable: false),
                    COD = table.Column<double>(type: "float", nullable: false),
                    orderStatus = table.Column<int>(type: "int", nullable: true),
                    assinedTo = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.orderId);
                    table.ForeignKey(
                        name: "FK_Tasks_Status_orderStatus",
                        column: x => x.orderStatus,
                        principalTable: "Status",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Tasks_Users_assinedTo",
                        column: x => x.assinedTo,
                        principalTable: "Users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_assinedTo",
                table: "Tasks",
                column: "assinedTo");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_orderStatus",
                table: "Tasks",
                column: "orderStatus");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
