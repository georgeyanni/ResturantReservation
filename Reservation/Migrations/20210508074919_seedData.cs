using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Reservation.Migrations
{
    public partial class seedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "FoodList",
                columns: new[] { "Id", "FoodType" },
                values: new object[,]
                {
                    { 1, "Pizza" },
                    { 2, "Sea Food" },
                    { 3, "Fried Chicken" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Name", "Password", "Username" },
                values: new object[,]
                {
                    { 1, "george yanni", "2CE4B2E3EFCC473A6ED2D70B01C4D7E9", "georgey" },
                    { 2, "helmy adam", "EED23196E62F8B98B6FD2EA881FEC77A", "helmya" }
                });

            migrationBuilder.InsertData(
                table: "ReservationTable",
                columns: new[] { "Id", "FoodTypeId", "Notes", "PepoleNumber", "ReservationDate", "TableNo", "UserId" },
                values: new object[] { 1, null, null, 5, new DateTime(2021, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 12, 1 });

            migrationBuilder.InsertData(
                table: "ReservationTable",
                columns: new[] { "Id", "FoodTypeId", "Notes", "PepoleNumber", "ReservationDate", "TableNo", "UserId" },
                values: new object[] { 2, null, null, 10, new DateTime(2021, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 15, 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FoodList",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "FoodList",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "FoodList",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ReservationTable",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ReservationTable",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
