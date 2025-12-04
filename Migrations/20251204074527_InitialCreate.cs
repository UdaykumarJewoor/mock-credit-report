using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MockCreditReport.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PaymentHistorySummaries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OnTimePayments = table.Column<int>(type: "int", nullable: false),
                    LatePayments = table.Column<int>(type: "int", nullable: false),
                    LastLatePaymentDate = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentHistorySummaries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Zip = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreditReportId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Insureds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SsnLast4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Insureds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Insureds_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CreditReports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrimaryInsuredId = table.Column<int>(type: "int", nullable: true),
                    SecondaryInsuredId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditReports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CreditReports_Insureds_PrimaryInsuredId",
                        column: x => x.PrimaryInsuredId,
                        principalTable: "Insureds",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CreditReports_Insureds_SecondaryInsuredId",
                        column: x => x.SecondaryInsuredId,
                        principalTable: "Insureds",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Collections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Agency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OpenedDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClosedDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreditReportId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Collections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Collections_CreditReports_CreditReportId",
                        column: x => x.CreditReportId,
                        principalTable: "CreditReports",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Inquiries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Inquirer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreditReportId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inquiries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inquiries_CreditReports_CreditReportId",
                        column: x => x.CreditReportId,
                        principalTable: "CreditReports",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PublicRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Court = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreditReportId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublicRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PublicRecords_CreditReports_CreditReportId",
                        column: x => x.CreditReportId,
                        principalTable: "CreditReports",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Trades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TradeId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreditorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OpenedDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClosedDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Balance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreditLimit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OriginalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Terms = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentHistorySummaryId = table.Column<int>(type: "int", nullable: true),
                    CreditReportId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trades_CreditReports_CreditReportId",
                        column: x => x.CreditReportId,
                        principalTable: "CreditReports",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Trades_PaymentHistorySummaries_PaymentHistorySummaryId",
                        column: x => x.PaymentHistorySummaryId,
                        principalTable: "PaymentHistorySummaries",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CreditReportId",
                table: "Addresses",
                column: "CreditReportId");

            migrationBuilder.CreateIndex(
                name: "IX_Collections_CreditReportId",
                table: "Collections",
                column: "CreditReportId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditReports_PrimaryInsuredId",
                table: "CreditReports",
                column: "PrimaryInsuredId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditReports_SecondaryInsuredId",
                table: "CreditReports",
                column: "SecondaryInsuredId");

            migrationBuilder.CreateIndex(
                name: "IX_Inquiries_CreditReportId",
                table: "Inquiries",
                column: "CreditReportId");

            migrationBuilder.CreateIndex(
                name: "IX_Insureds_AddressId",
                table: "Insureds",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_PublicRecords_CreditReportId",
                table: "PublicRecords",
                column: "CreditReportId");

            migrationBuilder.CreateIndex(
                name: "IX_Trades_CreditReportId",
                table: "Trades",
                column: "CreditReportId");

            migrationBuilder.CreateIndex(
                name: "IX_Trades_PaymentHistorySummaryId",
                table: "Trades",
                column: "PaymentHistorySummaryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_CreditReports_CreditReportId",
                table: "Addresses",
                column: "CreditReportId",
                principalTable: "CreditReports",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_CreditReports_CreditReportId",
                table: "Addresses");

            migrationBuilder.DropTable(
                name: "Collections");

            migrationBuilder.DropTable(
                name: "Inquiries");

            migrationBuilder.DropTable(
                name: "PublicRecords");

            migrationBuilder.DropTable(
                name: "Trades");

            migrationBuilder.DropTable(
                name: "PaymentHistorySummaries");

            migrationBuilder.DropTable(
                name: "CreditReports");

            migrationBuilder.DropTable(
                name: "Insureds");

            migrationBuilder.DropTable(
                name: "Addresses");
        }
    }
}
