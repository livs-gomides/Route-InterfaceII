using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RouteAPI_SQL_Connect.Migrations
{
    /// <inheritdoc />
    public partial class InitialMySQLCloud : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Locals",
                columns: table => new
                {
                    LocalID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locals", x => x.LocalID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    PersonID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PasswordHash = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Role = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.PersonID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SubLocals",
                columns: table => new
                {
                    SubLocalID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    LocalID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FloorLevel = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubLocals", x => x.SubLocalID);
                    table.ForeignKey(
                        name: "FK_SubLocals_Locals_LocalID",
                        column: x => x.LocalID,
                        principalTable: "Locals",
                        principalColumn: "LocalID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Devices",
                columns: table => new
                {
                    DeviceID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    PersonID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    DeviceName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OperatingSystem = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devices", x => x.DeviceID);
                    table.ForeignKey(
                        name: "FK_Devices_Persons_PersonID",
                        column: x => x.PersonID,
                        principalTable: "Persons",
                        principalColumn: "PersonID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Beacons",
                columns: table => new
                {
                    BeaconID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    SubLocalID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    MacAddress = table.Column<string>(type: "varchar(17)", maxLength: 17, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UuidString = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CoordinateX = table.Column<decimal>(type: "decimal(10,4)", nullable: false),
                    CoordinateY = table.Column<decimal>(type: "decimal(10,4)", nullable: false),
                    BatteryLevel = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beacons", x => x.BeaconID);
                    table.ForeignKey(
                        name: "FK_Beacons_SubLocals_SubLocalID",
                        column: x => x.SubLocalID,
                        principalTable: "SubLocals",
                        principalColumn: "SubLocalID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PointsOfInterest",
                columns: table => new
                {
                    PoiID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    SubLocalID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CoordinateX = table.Column<decimal>(type: "decimal(10,4)", nullable: false),
                    CoordinateY = table.Column<decimal>(type: "decimal(10,4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PointsOfInterest", x => x.PoiID);
                    table.ForeignKey(
                        name: "FK_PointsOfInterest_SubLocals_SubLocalID",
                        column: x => x.SubLocalID,
                        principalTable: "SubLocals",
                        principalColumn: "SubLocalID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PositioningLogs",
                columns: table => new
                {
                    LogID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    PersonID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    BeaconID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CalculatedX = table.Column<decimal>(type: "decimal(10,4)", nullable: true),
                    CalculatedY = table.Column<decimal>(type: "decimal(10,4)", nullable: true),
                    CapturedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PositioningLogs", x => x.LogID);
                    table.ForeignKey(
                        name: "FK_PositioningLogs_Beacons_BeaconID",
                        column: x => x.BeaconID,
                        principalTable: "Beacons",
                        principalColumn: "BeaconID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PositioningLogs_Persons_PersonID",
                        column: x => x.PersonID,
                        principalTable: "Persons",
                        principalColumn: "PersonID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Beacons_SubLocalID",
                table: "Beacons",
                column: "SubLocalID");

            migrationBuilder.CreateIndex(
                name: "IX_Devices_PersonID",
                table: "Devices",
                column: "PersonID");

            migrationBuilder.CreateIndex(
                name: "IX_PointsOfInterest_SubLocalID",
                table: "PointsOfInterest",
                column: "SubLocalID");

            migrationBuilder.CreateIndex(
                name: "IX_PositioningLogs_BeaconID",
                table: "PositioningLogs",
                column: "BeaconID");

            migrationBuilder.CreateIndex(
                name: "IX_PositioningLogs_PersonID",
                table: "PositioningLogs",
                column: "PersonID");

            migrationBuilder.CreateIndex(
                name: "IX_SubLocals_LocalID",
                table: "SubLocals",
                column: "LocalID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Devices");

            migrationBuilder.DropTable(
                name: "PointsOfInterest");

            migrationBuilder.DropTable(
                name: "PositioningLogs");

            migrationBuilder.DropTable(
                name: "Beacons");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "SubLocals");

            migrationBuilder.DropTable(
                name: "Locals");
        }
    }
}
