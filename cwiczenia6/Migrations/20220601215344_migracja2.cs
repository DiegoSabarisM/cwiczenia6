using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cwiczenia6.Migrations
{
    public partial class migracja2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Medicaments",
                columns: new[] { "IdMedicament", "Description", "Name", "Type" },
                values: new object[] { 220, "placebolasbolas", "Paracetabol", "powerful" });

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "IdPrescription",
                keyValue: 10,
                column: "DueDate",
                value: new DateTime(2022, 6, 1, 23, 53, 43, 359, DateTimeKind.Local).AddTicks(6050));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Medicaments",
                keyColumn: "IdMedicament",
                keyValue: 220);

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "IdPrescription",
                keyValue: 10,
                column: "DueDate",
                value: new DateTime(2022, 6, 1, 1, 50, 19, 952, DateTimeKind.Local).AddTicks(7754));
        }
    }
}
