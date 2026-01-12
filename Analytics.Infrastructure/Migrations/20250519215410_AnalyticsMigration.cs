using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Analytics.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AnalyticsMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alerts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AlertType = table.Column<string>(type: "text", nullable: false),
                    TenantId = table.Column<string>(type: "text", nullable: false),
                    Message = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsResolved = table.Column<bool>(type: "boolean", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alerts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EventTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KPIs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Value = table.Column<decimal>(type: "numeric", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KPIs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentAnalytics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TenantId = table.Column<string>(type: "text", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TotalPaymentsCount = table.Column<int>(type: "integer", nullable: false),
                    TotalPaymentsAmount = table.Column<decimal>(type: "numeric", nullable: false),
                    SuccessfulPaymentsCount = table.Column<int>(type: "integer", nullable: false),
                    FailedPaymentsCount = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentAnalytics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PayoutAnalytics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TenantId = table.Column<string>(type: "text", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TotalPayoutsCount = table.Column<int>(type: "integer", nullable: false),
                    TotalPayoutsAmount = table.Column<decimal>(type: "numeric", nullable: false),
                    SuccessfulPayoutsCount = table.Column<int>(type: "integer", nullable: false),
                    FailedPayoutsCount = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayoutAnalytics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserActivityAnalytics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TenantId = table.Column<string>(type: "text", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    NewUsersCount = table.Column<int>(type: "integer", nullable: false),
                    ActiveUsersCount = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserActivityAnalytics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AnalyticsEventRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TenantId = table.Column<string>(type: "text", nullable: false),
                    EventTypeId = table.Column<int>(type: "integer", nullable: false),
                    EventDataJson = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnalyticsEventRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnalyticsEventRecords_EventTypes_EventTypeId",
                        column: x => x.EventTypeId,
                        principalTable: "EventTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PaymentMethodAnalytics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TenantId = table.Column<string>(type: "text", nullable: false),
                    PaymentAnalyticsId = table.Column<int>(type: "integer", nullable: false),
                    PaymentMethodId = table.Column<int>(type: "integer", nullable: false),
                    PaymentMethodName = table.Column<string>(type: "text", nullable: false),
                    Count = table.Column<int>(type: "integer", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethodAnalytics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaymentMethodAnalytics_PaymentAnalytics_PaymentAnalyticsId",
                        column: x => x.PaymentAnalyticsId,
                        principalTable: "PaymentAnalytics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alert_Id_TenantId",
                table: "Alerts",
                columns: new[] { "Id", "TenantId" });

            migrationBuilder.CreateIndex(
                name: "IX_AnalyticsEventRecord_Id_TenantId",
                table: "AnalyticsEventRecords",
                columns: new[] { "Id", "TenantId" });

            migrationBuilder.CreateIndex(
                name: "IX_AnalyticsEventRecords_EventTypeId",
                table: "AnalyticsEventRecords",
                column: "EventTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EventType_Id_Name",
                table: "EventTypes",
                columns: new[] { "Id", "Name" });

            migrationBuilder.CreateIndex(
                name: "IX_KPI_Id_Name",
                table: "KPIs",
                columns: new[] { "Id", "Name" });

            migrationBuilder.CreateIndex(
                name: "IX_PaymentAnalytics_Id_Name_TenantId",
                table: "PaymentAnalytics",
                columns: new[] { "Id", "TenantId" });

            migrationBuilder.CreateIndex(
                name: "IX_PaymentMethodAnalytics_Id_Name_TenantId",
                table: "PaymentMethodAnalytics",
                columns: new[] { "Id", "TenantId" });

            migrationBuilder.CreateIndex(
                name: "IX_PaymentMethodAnalytics_PaymentAnalyticsId",
                table: "PaymentMethodAnalytics",
                column: "PaymentAnalyticsId");

            migrationBuilder.CreateIndex(
                name: "IX_PayoutAnalytics_Id_Name_TenantId",
                table: "PayoutAnalytics",
                columns: new[] { "Id", "TenantId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alerts");

            migrationBuilder.DropTable(
                name: "AnalyticsEventRecords");

            migrationBuilder.DropTable(
                name: "KPIs");

            migrationBuilder.DropTable(
                name: "PaymentMethodAnalytics");

            migrationBuilder.DropTable(
                name: "PayoutAnalytics");

            migrationBuilder.DropTable(
                name: "UserActivityAnalytics");

            migrationBuilder.DropTable(
                name: "EventTypes");

            migrationBuilder.DropTable(
                name: "PaymentAnalytics");
        }
    }
}
