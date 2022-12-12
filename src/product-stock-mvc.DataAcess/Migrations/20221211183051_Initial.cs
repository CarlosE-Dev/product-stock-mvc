using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace product_stock_mvc.DataAcess.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PS_PROVIDERS",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(225)", maxLength: 225, nullable: false),
                    Document = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    ProviderType = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PS_PROVIDERS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PS_PRODUCTS",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProviderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(225)", maxLength: 225, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Image = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    QuantityInStock = table.Column<long>(type: "bigint", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PS_PRODUCTS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PS_PRODUCTS_PS_PROVIDERS_ProviderId",
                        column: x => x.ProviderId,
                        principalTable: "PS_PROVIDERS",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PS_PRODUCTS_ProviderId",
                table: "PS_PRODUCTS",
                column: "ProviderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PS_PRODUCTS");

            migrationBuilder.DropTable(
                name: "PS_PROVIDERS");
        }
    }
}
