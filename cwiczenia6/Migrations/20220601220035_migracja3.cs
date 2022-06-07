using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cwiczenia6.Migrations
{
    public partial class migracja3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "PrescriptionMedicaments",
                columns: new[] { "IdMedicament", "IdPrescription", "Details", "Dose" },
                values: new object[] { 220, 10, "Apply every day", 5 });

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "IdPrescription",
                keyValue: 10,
                column: "DueDate",
                value: new DateTime(2022, 6, 2, 0, 0, 34, 503, DateTimeKind.Local).AddTicks(6904));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PrescriptionMedicaments",
                keyColumns: new[] { "IdMedicament", "IdPrescription" },
                keyValues: new object[] { 220, 10 });

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "IdPrescription",
                keyValue: 10,
                column: "DueDate",
                value: new DateTime(2022, 6, 1, 23, 53, 43, 359, DateTimeKind.Local).AddTicks(6050));
        }
    }
}
