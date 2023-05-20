using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestTestServer.Migrations
{
    /// <inheritdoc />
    public partial class DeliveryMan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DeliveryMan",
                columns: table => new
                {
                    ManID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ManName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ManPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ManAccount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ManPassword = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryMan", x => x.ManID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeliveryMan");
        }
    }
}
