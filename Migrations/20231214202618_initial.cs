using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CurrencyExchangeCrud.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Master");

            migrationBuilder.CreateTable(
                name: "CurrencyMaster",
                schema: "Master",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrencyMaster", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CountryMaster",
                schema: "Master",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RefCurrencyId = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryMaster", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CountryMaster_CurrencyMaster_RefCurrencyId",
                        column: x => x.RefCurrencyId,
                        principalSchema: "Master",
                        principalTable: "CurrencyMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "CurrencyExchangeRate",
                schema: "Master",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RefSourceCurrencyId = table.Column<int>(type: "int", nullable: false),
                    RefTargetCurrencyId = table.Column<int>(type: "int", nullable: false),
                    ExchangeDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExchangeRate = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrencyExchangeRate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CurrencyExchangeRate_CurrencyMaster_RefSourceCurrencyId",
                        column: x => x.RefSourceCurrencyId,
                        principalSchema: "Master",
                        principalTable: "CurrencyMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CurrencyExchangeRate_CurrencyMaster_RefTargetCurrencyId",
                        column: x => x.RefTargetCurrencyId,
                        principalSchema: "Master",
                        principalTable: "CurrencyMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CountryMaster_Code",
                schema: "Master",
                table: "CountryMaster",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CountryMaster_RefCurrencyId",
                schema: "Master",
                table: "CountryMaster",
                column: "RefCurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_CurrencyExchangeRate_RefSourceCurrencyId",
                schema: "Master",
                table: "CurrencyExchangeRate",
                column: "RefSourceCurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_CurrencyExchangeRate_RefTargetCurrencyId",
                schema: "Master",
                table: "CurrencyExchangeRate",
                column: "RefTargetCurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_CurrencyMaster_Code",
                schema: "Master",
                table: "CurrencyMaster",
                column: "Code",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CountryMaster",
                schema: "Master");

            migrationBuilder.DropTable(
                name: "CurrencyExchangeRate",
                schema: "Master");

            migrationBuilder.DropTable(
                name: "CurrencyMaster",
                schema: "Master");
        }
    }
}
