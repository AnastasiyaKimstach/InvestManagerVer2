using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InvestManager.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Assets",
                columns: table => new
                {
                    AssetID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AssetName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ticker = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrentPrice = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assets", x => x.AssetID);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "ChangesPrice",
                columns: table => new
                {
                    ChangePriceID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    Month = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChangesPrice", x => x.ChangePriceID);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CountryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryID);
                });

            migrationBuilder.CreateTable(
                name: "EmploymentStatuses",
                columns: table => new
                {
                    SatusID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StatusName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmploymentStatuses", x => x.SatusID);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    ClientID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pathronumic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfRegistration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<bool>(type: "bit", nullable: false),
                    CountryID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StatusID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmploymentStatusSatusID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NumberPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ClientID);
                    table.ForeignKey(
                        name: "FK_Clients_Countries_CountryID",
                        column: x => x.CountryID,
                        principalTable: "Countries",
                        principalColumn: "CountryID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Clients_EmploymentStatuses_EmploymentStatusSatusID",
                        column: x => x.EmploymentStatusSatusID,
                        principalTable: "EmploymentStatuses",
                        principalColumn: "SatusID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InvestPortfolios",
                columns: table => new
                {
                    PortfolioID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClientID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PortfolioName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PortfolioGoal = table.Column<int>(type: "int", nullable: false),
                    InvestmentHorisont = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvestPortfolios", x => x.PortfolioID);
                    table.ForeignKey(
                        name: "FK_InvestPortfolios_Clients_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Clients",
                        principalColumn: "ClientID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AssetsInPortfolio",
                columns: table => new
                {
                    AssetInPortfolioID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AssetID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    CategotyID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PortfolioID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetsInPortfolio", x => x.AssetInPortfolioID);
                    table.ForeignKey(
                        name: "FK_AssetsInPortfolio_Assets_AssetID",
                        column: x => x.AssetID,
                        principalTable: "Assets",
                        principalColumn: "AssetID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssetsInPortfolio_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "CategoryID");
                    table.ForeignKey(
                        name: "FK_AssetsInPortfolio_InvestPortfolios_PortfolioID",
                        column: x => x.PortfolioID,
                        principalTable: "InvestPortfolios",
                        principalColumn: "PortfolioID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Statistices",
                columns: table => new
                {
                    StatisticID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PortfolioID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PortfolioProfitability = table.Column<float>(type: "real", nullable: false),
                    PortfolioCost = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statistices", x => x.StatisticID);
                    table.ForeignKey(
                        name: "FK_Statistices_InvestPortfolios_PortfolioID",
                        column: x => x.PortfolioID,
                        principalTable: "InvestPortfolios",
                        principalColumn: "PortfolioID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    TransactionID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TransactionType = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<float>(type: "real", nullable: false),
                    AssetInPortfolioID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PortfolionID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InvestPortfolioPortfolioID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.TransactionID);
                    table.ForeignKey(
                        name: "FK_Transactions_AssetsInPortfolio_AssetInPortfolioID",
                        column: x => x.AssetInPortfolioID,
                        principalTable: "AssetsInPortfolio",
                        principalColumn: "AssetInPortfolioID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transactions_InvestPortfolios_InvestPortfolioPortfolioID",
                        column: x => x.InvestPortfolioPortfolioID,
                        principalTable: "InvestPortfolios",
                        principalColumn: "PortfolioID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssetsInPortfolio_AssetID",
                table: "AssetsInPortfolio",
                column: "AssetID");

            migrationBuilder.CreateIndex(
                name: "IX_AssetsInPortfolio_CategoryID",
                table: "AssetsInPortfolio",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_AssetsInPortfolio_PortfolioID",
                table: "AssetsInPortfolio",
                column: "PortfolioID");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_CountryID",
                table: "Clients",
                column: "CountryID");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_EmploymentStatusSatusID",
                table: "Clients",
                column: "EmploymentStatusSatusID");

            migrationBuilder.CreateIndex(
                name: "IX_InvestPortfolios_ClientID",
                table: "InvestPortfolios",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_Statistices_PortfolioID",
                table: "Statistices",
                column: "PortfolioID");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_AssetInPortfolioID",
                table: "Transactions",
                column: "AssetInPortfolioID");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_InvestPortfolioPortfolioID",
                table: "Transactions",
                column: "InvestPortfolioPortfolioID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChangesPrice");

            migrationBuilder.DropTable(
                name: "Statistices");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "AssetsInPortfolio");

            migrationBuilder.DropTable(
                name: "Assets");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "InvestPortfolios");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "EmploymentStatuses");
        }
    }
}
