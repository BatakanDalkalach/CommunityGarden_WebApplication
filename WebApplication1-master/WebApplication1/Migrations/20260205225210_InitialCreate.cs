using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GardenMembers",
                columns: table => new
                {
                    MemberId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FullLegalName = table.Column<string>(type: "TEXT", maxLength: 80, nullable: false),
                    EmailContact = table.Column<string>(type: "TEXT", maxLength: 120, nullable: false),
                    MembershipTier = table.Column<string>(type: "TEXT", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    YearsOfExperience = table.Column<int>(type: "INTEGER", nullable: false),
                    PreferOrganicOnly = table.Column<bool>(type: "INTEGER", nullable: false),
                    GardeningInterests = table.Column<string>(type: "TEXT", maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GardenMembers", x => x.MemberId);
                });

            migrationBuilder.CreateTable(
                name: "GardenPlots",
                columns: table => new
                {
                    PlotIdentifier = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PlotDesignation = table.Column<string>(type: "TEXT", maxLength: 10, nullable: false),
                    SquareMeters = table.Column<double>(type: "REAL", nullable: false),
                    SoilType = table.Column<string>(type: "TEXT", nullable: false),
                    WaterAccessAvailable = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsOccupied = table.Column<bool>(type: "INTEGER", nullable: false),
                    YearlyRentalFee = table.Column<decimal>(type: "TEXT", nullable: false),
                    LastMaintenanceDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    AssignedGardenerId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GardenPlots", x => x.PlotIdentifier);
                    table.ForeignKey(
                        name: "FK_GardenPlots_GardenMembers_AssignedGardenerId",
                        column: x => x.AssignedGardenerId,
                        principalTable: "GardenMembers",
                        principalColumn: "MemberId",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "HarvestRecords",
                columns: table => new
                {
                    RecordId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PlotIdentifier = table.Column<int>(type: "INTEGER", nullable: false),
                    MemberId = table.Column<int>(type: "INTEGER", nullable: false),
                    CropName = table.Column<string>(type: "TEXT", maxLength: 60, nullable: false),
                    QuantityKilograms = table.Column<double>(type: "REAL", nullable: false),
                    CollectionDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    QualityScore = table.Column<int>(type: "INTEGER", nullable: false),
                    HarvestNotes = table.Column<string>(type: "TEXT", maxLength: 400, nullable: true),
                    IsOrganicCertified = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HarvestRecords", x => x.RecordId);
                    table.ForeignKey(
                        name: "FK_HarvestRecords_GardenMembers_MemberId",
                        column: x => x.MemberId,
                        principalTable: "GardenMembers",
                        principalColumn: "MemberId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HarvestRecords_GardenPlots_PlotIdentifier",
                        column: x => x.PlotIdentifier,
                        principalTable: "GardenPlots",
                        principalColumn: "PlotIdentifier",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "GardenMembers",
                columns: new[] { "MemberId", "EmailContact", "FullLegalName", "GardeningInterests", "MembershipTier", "PreferOrganicOnly", "RegistrationDate", "YearsOfExperience" },
                values: new object[,]
                {
                    { 1, "sarah.j@email.com", "Sarah Johnson", "Tomatoes, Herbs, Peppers", "Premium", true, new DateTime(2022, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 8 },
                    { 2, "m.chen@email.com", "Michael Chen", "Root vegetables, Squash", "Basic", false, new DateTime(2023, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 }
                });

            migrationBuilder.InsertData(
                table: "GardenPlots",
                columns: new[] { "PlotIdentifier", "AssignedGardenerId", "IsOccupied", "LastMaintenanceDate", "PlotDesignation", "SoilType", "SquareMeters", "WaterAccessAvailable", "YearlyRentalFee" },
                values: new object[,]
                {
                    { 2, null, false, new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "A002", "Sandy-Loam", 30.0, true, 175m },
                    { 1, 1, true, new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A001", "Clay-Loam", 25.5, true, 150m },
                    { 3, 2, true, new DateTime(2024, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "B001", "Loamy", 20.0, true, 125m }
                });

            migrationBuilder.InsertData(
                table: "HarvestRecords",
                columns: new[] { "RecordId", "CollectionDate", "CropName", "HarvestNotes", "IsOrganicCertified", "MemberId", "PlotIdentifier", "QualityScore", "QuantityKilograms" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cherry Tomatoes", "Excellent yield, very sweet", true, 1, 1, 5, 12.5 },
                    { 2, new DateTime(2024, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Carrots", "Good size, some slight pest damage", false, 2, 3, 4, 8.3000000000000007 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_GardenMembers_EmailContact",
                table: "GardenMembers",
                column: "EmailContact",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GardenPlots_AssignedGardenerId",
                table: "GardenPlots",
                column: "AssignedGardenerId");

            migrationBuilder.CreateIndex(
                name: "IX_GardenPlots_PlotDesignation",
                table: "GardenPlots",
                column: "PlotDesignation",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HarvestRecords_MemberId",
                table: "HarvestRecords",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_HarvestRecords_PlotIdentifier",
                table: "HarvestRecords",
                column: "PlotIdentifier");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HarvestRecords");

            migrationBuilder.DropTable(
                name: "GardenPlots");

            migrationBuilder.DropTable(
                name: "GardenMembers");
        }
    }
}
