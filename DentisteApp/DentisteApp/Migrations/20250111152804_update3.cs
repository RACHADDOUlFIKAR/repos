using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DentisteApp.Migrations
{
    /// <inheritdoc />
    public partial class update3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Paiements_Patients_PatientID",
                table: "Paiements");

            migrationBuilder.DropIndex(
                name: "IX_Paiements_PatientID",
                table: "Paiements");

            migrationBuilder.DropColumn(
                name: "PatientID",
                table: "Paiements");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PatientID",
                table: "Paiements",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Paiements_PatientID",
                table: "Paiements",
                column: "PatientID");

            migrationBuilder.AddForeignKey(
                name: "FK_Paiements_Patients_PatientID",
                table: "Paiements",
                column: "PatientID",
                principalTable: "Patients",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
