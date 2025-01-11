using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DentisteApp.Migrations
{
    /// <inheritdoc />
    public partial class update1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Acte_Patients_PatientID",
                table: "Acte");

            migrationBuilder.DropForeignKey(
                name: "FK_Paiements_Acte_ActeID",
                table: "Paiements");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Acte",
                table: "Acte");

            migrationBuilder.RenameTable(
                name: "Acte",
                newName: "Actes");

            migrationBuilder.RenameIndex(
                name: "IX_Acte_PatientID",
                table: "Actes",
                newName: "IX_Actes_PatientID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Actes",
                table: "Actes",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Actes_Patients_PatientID",
                table: "Actes",
                column: "PatientID",
                principalTable: "Patients",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Paiements_Actes_ActeID",
                table: "Paiements",
                column: "ActeID",
                principalTable: "Actes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Actes_Patients_PatientID",
                table: "Actes");

            migrationBuilder.DropForeignKey(
                name: "FK_Paiements_Actes_ActeID",
                table: "Paiements");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Actes",
                table: "Actes");

            migrationBuilder.RenameTable(
                name: "Actes",
                newName: "Acte");

            migrationBuilder.RenameIndex(
                name: "IX_Actes_PatientID",
                table: "Acte",
                newName: "IX_Acte_PatientID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Acte",
                table: "Acte",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Acte_Patients_PatientID",
                table: "Acte",
                column: "PatientID",
                principalTable: "Patients",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Paiements_Acte_ActeID",
                table: "Paiements",
                column: "ActeID",
                principalTable: "Acte",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
