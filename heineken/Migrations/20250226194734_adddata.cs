using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace heineken.Migrations
{
    public partial class adddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Campaigns",
                columns: table => new
                {
                    CampaignID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campaigns", x => x.CampaignID);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    LocationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalPoints = table.Column<int>(type: "int", nullable: false),
                    Area = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RobotCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.LocationID);
                });

            migrationBuilder.CreateTable(
                name: "RewardRules",
                columns: table => new
                {
                    RuleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PointsRequired = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RewardRules", x => x.RuleID);
                });

            migrationBuilder.CreateTable(
                name: "Robots",
                columns: table => new
                {
                    RobotID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RobotName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RobotStatus = table.Column<int>(type: "int", nullable: false),
                    ActivityLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastConnectionTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BatteryLevel = table.Column<int>(type: "int", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Robots", x => x.RobotID);
                });

            migrationBuilder.CreateTable(
                name: "RecyclingMachines",
                columns: table => new
                {
                    MachineID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MachineName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MachineStatus = table.Column<int>(type: "int", nullable: false),
                    ActivityLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AccessCount = table.Column<int>(type: "int", nullable: false),
                    BinStatus = table.Column<int>(type: "int", nullable: false),
                    LastConnectionTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CampaignID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecyclingMachines", x => x.MachineID);
                    table.ForeignKey(
                        name: "FK_RecyclingMachines_Campaigns_CampaignID",
                        column: x => x.CampaignID,
                        principalTable: "Campaigns",
                        principalColumn: "CampaignID");
                });

            migrationBuilder.CreateTable(
                name: "Gifts",
                columns: table => new
                {
                    GiftID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalCount = table.Column<int>(type: "int", nullable: false),
                    RemainingCount = table.Column<int>(type: "int", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RewardRuleRuleID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gifts", x => x.GiftID);
                    table.ForeignKey(
                        name: "FK_Gifts_RewardRules_RewardRuleRuleID",
                        column: x => x.RewardRuleRuleID,
                        principalTable: "RewardRules",
                        principalColumn: "RuleID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Gifts_RewardRuleRuleID",
                table: "Gifts",
                column: "RewardRuleRuleID");

            migrationBuilder.CreateIndex(
                name: "IX_RecyclingMachines_CampaignID",
                table: "RecyclingMachines",
                column: "CampaignID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Gifts");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "RecyclingMachines");

            migrationBuilder.DropTable(
                name: "Robots");

            migrationBuilder.DropTable(
                name: "RewardRules");

            migrationBuilder.DropTable(
                name: "Campaigns");
        }
    }
}
