using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Uper.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "rides",
                columns: table => new
                {
                    RideId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PickupNumber = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    DropOffLocation = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Fare = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RiderId = table.Column<int>(type: "int", nullable: false),
                    DriveId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rides", x => x.RideId);
                    table.ForeignKey(
                        name: "FK_rides_users_DriveId",
                        column: x => x.DriveId,
                        principalTable: "users",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_rides_users_RiderId",
                        column: x => x.RiderId,
                        principalTable: "users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "vehicles",
                columns: table => new
                {
                    VehicleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlateNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DriverId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vehicles", x => x.VehicleId);
                    table.ForeignKey(
                        name: "FK_vehicles_users_DriverId",
                        column: x => x.DriverId,
                        principalTable: "users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "payments",
                columns: table => new
                {
                    PaymentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    PaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RideId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_payments", x => x.PaymentId);
                    table.ForeignKey(
                        name: "FK_payments_rides_RideId",
                        column: x => x.RideId,
                        principalTable: "rides",
                        principalColumn: "RideId");
                });

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    RatingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Score = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    RideId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.RatingId);
                    table.ForeignKey(
                        name: "FK_Ratings_rides_RideId",
                        column: x => x.RideId,
                        principalTable: "rides",
                        principalColumn: "RideId");
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "UserId", "Email", "FullName", "Password", "Phone", "Role" },
                values: new object[,]
                {
                    { 1, "elldeegahmag@gmail.com", "Ahmed abdullah", "123456", "01129566806", "Driver" },
                    { 2, "Ali@gmail.com", "Ali abdullah", "12399956", "01129569806", "Rider" }
                });

            migrationBuilder.InsertData(
                table: "rides",
                columns: new[] { "RideId", "DriveId", "DropOffLocation", "Fare", "PickupNumber", "RiderId", "Status" },
                values: new object[] { 1, 1, "Giza", 100, "Cairo", 2, "Completed" });

            migrationBuilder.InsertData(
                table: "vehicles",
                columns: new[] { "VehicleId", "Color", "DriverId", "PlateNumber" },
                values: new object[] { 1, "Red", 1, "123456" });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "RatingId", "Comment", "RideId", "Score" },
                values: new object[] { 1, "Great ride!", 1, 5 });

            migrationBuilder.InsertData(
                table: "payments",
                columns: new[] { "PaymentId", "Amount", "PaymentDate", "PaymentMethod", "RideId", "Status" },
                values: new object[] { 1, 100, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cash", 1, "Done" });

            migrationBuilder.CreateIndex(
                name: "IX_payments_RideId",
                table: "payments",
                column: "RideId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_RideId",
                table: "Ratings",
                column: "RideId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_rides_DriveId",
                table: "rides",
                column: "DriveId");

            migrationBuilder.CreateIndex(
                name: "IX_rides_RiderId",
                table: "rides",
                column: "RiderId");

            migrationBuilder.CreateIndex(
                name: "IX_vehicles_DriverId",
                table: "vehicles",
                column: "DriverId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "payments");

            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropTable(
                name: "vehicles");

            migrationBuilder.DropTable(
                name: "rides");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
