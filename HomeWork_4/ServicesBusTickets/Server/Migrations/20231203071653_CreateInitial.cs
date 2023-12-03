using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ServicesBusTickets.Server.Migrations
{
    /// <inheritdoc />
    public partial class CreateInitial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FromStation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ToStation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DatePurchase = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "Id", "DatePurchase", "FromStation", "Price", "ToStation" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 12, 3, 18, 30, 10, 0, DateTimeKind.Unspecified), "Нижний-Новгород", 1200.40m, "Москва" },
                    { 2, new DateTime(2023, 12, 2, 23, 30, 20, 0, DateTimeKind.Unspecified), "Москва", 1100.30m, "Нижний-Новгород" },
                    { 3, new DateTime(2023, 12, 1, 13, 35, 30, 0, DateTimeKind.Unspecified), "Москва", 1690.10m, "Санкт-Петербург" },
                    { 4, new DateTime(2023, 12, 4, 15, 45, 22, 0, DateTimeKind.Unspecified), "Санкт-Петербург", 1830.80m, "Москва" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tickets");
        }
    }
}
