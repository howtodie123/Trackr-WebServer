using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestTestServer.Migrations
{
    /// <inheritdoc />
    public partial class Parcel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Parcel",
                columns: table => new
                {
                    ParID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParDeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ParLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Realtime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: false),
                    CusID = table.Column<int>(type: "int", nullable: false),
                    ManID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parcel", x => x.ParID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Parcel");
        }
    }
}
