using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Payout.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class PayoutMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Commission",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PartnerId = table.Column<int>(type: "integer", nullable: false),
                    TenantId = table.Column<string>(type: "text", nullable: false),
                    Percentage = table.Column<decimal>(type: "numeric", nullable: false),
                    FixedAmount = table.Column<decimal>(type: "numeric", nullable: false),
                    EffectiveFrom = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EffectiveTo = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commission", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PayoutAuditLog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Action = table.Column<string>(type: "text", nullable: false),
                    PerformedBy = table.Column<string>(type: "text", nullable: false),
                    PerformedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Details = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayoutAuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PayoutCurrency",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "text", nullable: false),
                    Symbol = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayoutCurrency", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PayoutPaymentMethod",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayoutPaymentMethod", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PayoutRetryLog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AttemptNumber = table.Column<int>(type: "integer", nullable: false),
                    AttemptedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FailureReason = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayoutRetryLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PayoutStatus",
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
                    table.PrimaryKey("PK_PayoutStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentLimit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PayoutPaymentMethodId = table.Column<int>(type: "integer", nullable: false),
                    TenantId = table.Column<string>(type: "text", nullable: false),
                    MaxTransactionAmount = table.Column<decimal>(type: "numeric", nullable: false),
                    DailyLimitAmount = table.Column<decimal>(type: "numeric", nullable: false),
                    MaxTransactionsPerDay = table.Column<int>(type: "integer", nullable: false),
                    EffectiveFrom = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EffectiveTo = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentLimit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaymentLimit_PayoutPaymentMethod_PayoutPaymentMethodId",
                        column: x => x.PayoutPaymentMethodId,
                        principalTable: "PayoutPaymentMethod",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payout",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PartnerId = table.Column<int>(type: "integer", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    TenantId = table.Column<string>(type: "text", nullable: false),
                    CurrencyId = table.Column<int>(type: "integer", nullable: false),
                    RequestedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ProcessedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    StatusId = table.Column<int>(type: "integer", nullable: false),
                    PayoutPaymentMethodId = table.Column<int>(type: "integer", nullable: false),
                    ReferenceNumber = table.Column<string>(type: "text", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payout", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payout_PayoutCurrency_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "PayoutCurrency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Payout_PayoutPaymentMethod_PayoutPaymentMethodId",
                        column: x => x.PayoutPaymentMethodId,
                        principalTable: "PayoutPaymentMethod",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Payout_PayoutStatus_StatusId",
                        column: x => x.StatusId,
                        principalTable: "PayoutStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PayoutHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PayoutId = table.Column<int>(type: "integer", nullable: false),
                    StatusId = table.Column<int>(type: "integer", nullable: false),
                    ChangedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayoutHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PayoutHistory_PayoutStatus_StatusId",
                        column: x => x.StatusId,
                        principalTable: "PayoutStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PayoutHistory_Payout_PayoutId",
                        column: x => x.PayoutId,
                        principalTable: "Payout",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Commission_TenantId_PartnerId",
                table: "Commission",
                columns: new[] { "TenantId", "PartnerId" });

            migrationBuilder.CreateIndex(
                name: "IX_PaymentLimit_PayoutPaymentMethodId",
                table: "PaymentLimit",
                column: "PayoutPaymentMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentLimit_TenantId",
                table: "PaymentLimit",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Payout_CurrencyId",
                table: "Payout",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Payout_PayoutPaymentMethodId",
                table: "Payout",
                column: "PayoutPaymentMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_Payout_StatusId",
                table: "Payout",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Payout_TenantId_PartnerId_StatusId",
                table: "Payout",
                columns: new[] { "TenantId", "PartnerId", "StatusId" });

            migrationBuilder.CreateIndex(
                name: "IX_PayoutAuditLog_Id",
                table: "PayoutAuditLog",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_PayoutCurrency_Id_Code",
                table: "PayoutCurrency",
                columns: new[] { "Id", "Code" });

            migrationBuilder.CreateIndex(
                name: "IX_PayoutHistory_Id",
                table: "PayoutHistory",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_PayoutHistory_PayoutId",
                table: "PayoutHistory",
                column: "PayoutId");

            migrationBuilder.CreateIndex(
                name: "IX_PayoutHistory_StatusId",
                table: "PayoutHistory",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_PayoutPaymentMethod_Id_Name",
                table: "PayoutPaymentMethod",
                columns: new[] { "Id", "Name" });

            migrationBuilder.CreateIndex(
                name: "IX_PayoutRetryLog_Id",
                table: "PayoutRetryLog",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_PayoutStatus_Id_Name",
                table: "PayoutStatus",
                columns: new[] { "Id", "Name" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Commission");

            migrationBuilder.DropTable(
                name: "PaymentLimit");

            migrationBuilder.DropTable(
                name: "PayoutAuditLog");

            migrationBuilder.DropTable(
                name: "PayoutHistory");

            migrationBuilder.DropTable(
                name: "PayoutRetryLog");

            migrationBuilder.DropTable(
                name: "Payout");

            migrationBuilder.DropTable(
                name: "PayoutCurrency");

            migrationBuilder.DropTable(
                name: "PayoutPaymentMethod");

            migrationBuilder.DropTable(
                name: "PayoutStatus");
        }
    }
}
