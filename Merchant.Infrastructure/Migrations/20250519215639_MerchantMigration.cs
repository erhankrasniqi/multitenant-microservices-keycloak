using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Merchant.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MerchantMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Street = table.Column<string>(type: "text", nullable: false),
                    City = table.Column<string>(type: "text", nullable: false),
                    Region = table.Column<string>(type: "text", nullable: false),
                    Country = table.Column<string>(type: "text", nullable: false),
                    PostalCode = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MerchantStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MerchantStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Merchants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false),
                    TenantId = table.Column<string>(type: "text", nullable: false),
                    AddressId = table.Column<Guid>(type: "uuid", nullable: false),
                    StatusId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    OnboardingCompleted = table.Column<bool>(type: "boolean", nullable: false),
                    MerchantStatusId = table.Column<int>(type: "integer", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Merchants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Merchants_MerchantStatus_MerchantStatusId",
                        column: x => x.MerchantStatusId,
                        principalTable: "MerchantStatus",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MerchantBankAccounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MerchantId = table.Column<int>(type: "integer", nullable: false),
                    IBAN = table.Column<string>(type: "text", nullable: false),
                    BankName = table.Column<string>(type: "text", nullable: false),
                    Verified = table.Column<bool>(type: "boolean", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MerchantBankAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MerchantBankAccounts_Merchants_MerchantId",
                        column: x => x.MerchantId,
                        principalTable: "Merchants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MerchantDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MerchantId = table.Column<int>(type: "integer", nullable: false),
                    BusinessRegistrationNumber = table.Column<string>(type: "text", nullable: false),
                    Website = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MerchantDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MerchantDetails_Merchants_MerchantId",
                        column: x => x.MerchantId,
                        principalTable: "Merchants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MerchantTerminal",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MerchantId = table.Column<int>(type: "integer", nullable: false),
                    TerminalId = table.Column<string>(type: "text", nullable: false),
                    NFCDeviceId = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MerchantTerminal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MerchantTerminal_Merchants_MerchantId",
                        column: x => x.MerchantId,
                        principalTable: "Merchants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_Id",
                table: "Address",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_MerchantBankAccount_Id_MerchantId_BankName",
                table: "MerchantBankAccounts",
                columns: new[] { "Id", "MerchantId", "BankName" });

            migrationBuilder.CreateIndex(
                name: "IX_MerchantBankAccounts_MerchantId",
                table: "MerchantBankAccounts",
                column: "MerchantId");

            migrationBuilder.CreateIndex(
                name: "IX_MerchantDetails_Id_MerchantId",
                table: "MerchantDetails",
                columns: new[] { "Id", "MerchantId" });

            migrationBuilder.CreateIndex(
                name: "IX_MerchantDetails_MerchantId",
                table: "MerchantDetails",
                column: "MerchantId");

            migrationBuilder.CreateIndex(
                name: "IX_Merchant_Id_TenantId",
                table: "Merchants",
                columns: new[] { "Id", "TenantId" });

            migrationBuilder.CreateIndex(
                name: "IX_Merchants_MerchantStatusId",
                table: "Merchants",
                column: "MerchantStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_MerchantStatus_Id",
                table: "MerchantStatus",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_MerchantTerminal_Id_MerchantId",
                table: "MerchantTerminal",
                columns: new[] { "Id", "MerchantId" });

            migrationBuilder.CreateIndex(
                name: "IX_MerchantTerminal_MerchantId",
                table: "MerchantTerminal",
                column: "MerchantId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "MerchantBankAccounts");

            migrationBuilder.DropTable(
                name: "MerchantDetails");

            migrationBuilder.DropTable(
                name: "MerchantTerminal");

            migrationBuilder.DropTable(
                name: "Merchants");

            migrationBuilder.DropTable(
                name: "MerchantStatus");
        }
    }
}
