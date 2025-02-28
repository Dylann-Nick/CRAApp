using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixForeignKeyTuteur : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompteRendus_Utilisateurs_EtudiantId",
                table: "CompteRendus");

            migrationBuilder.DropForeignKey(
                name: "FK_EvaluationsTuteurs_CompteRendus_CompteRenduId",
                table: "EvaluationsTuteurs");

            migrationBuilder.DropForeignKey(
                name: "FK_EvaluationsTuteurs_Utilisateurs_TuteurId",
                table: "EvaluationsTuteurs");

            migrationBuilder.DropForeignKey(
                name: "FK_FichesEtudiants_Utilisateurs_EtudiantId",
                table: "FichesEtudiants");

            migrationBuilder.DropIndex(
                name: "IX_EvaluationsTuteurs_CompteRenduId",
                table: "EvaluationsTuteurs");

            migrationBuilder.AddColumn<Guid>(
                name: "UtilisateurId",
                table: "EvaluationsTuteurs",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EvaluationsTuteurs_CompteRenduId",
                table: "EvaluationsTuteurs",
                column: "CompteRenduId");

            migrationBuilder.CreateIndex(
                name: "IX_EvaluationsTuteurs_UtilisateurId",
                table: "EvaluationsTuteurs",
                column: "UtilisateurId");

            migrationBuilder.AddForeignKey(
                name: "FK_CompteRendus_Utilisateurs_EtudiantId",
                table: "CompteRendus",
                column: "EtudiantId",
                principalTable: "Utilisateurs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EvaluationsTuteurs_CompteRendus_CompteRenduId",
                table: "EvaluationsTuteurs",
                column: "CompteRenduId",
                principalTable: "CompteRendus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EvaluationsTuteurs_Utilisateurs_TuteurId",
                table: "EvaluationsTuteurs",
                column: "TuteurId",
                principalTable: "Utilisateurs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EvaluationsTuteurs_Utilisateurs_UtilisateurId",
                table: "EvaluationsTuteurs",
                column: "UtilisateurId",
                principalTable: "Utilisateurs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FichesEtudiants_Utilisateurs_EtudiantId",
                table: "FichesEtudiants",
                column: "EtudiantId",
                principalTable: "Utilisateurs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompteRendus_Utilisateurs_EtudiantId",
                table: "CompteRendus");

            migrationBuilder.DropForeignKey(
                name: "FK_EvaluationsTuteurs_CompteRendus_CompteRenduId",
                table: "EvaluationsTuteurs");

            migrationBuilder.DropForeignKey(
                name: "FK_EvaluationsTuteurs_Utilisateurs_TuteurId",
                table: "EvaluationsTuteurs");

            migrationBuilder.DropForeignKey(
                name: "FK_EvaluationsTuteurs_Utilisateurs_UtilisateurId",
                table: "EvaluationsTuteurs");

            migrationBuilder.DropForeignKey(
                name: "FK_FichesEtudiants_Utilisateurs_EtudiantId",
                table: "FichesEtudiants");

            migrationBuilder.DropIndex(
                name: "IX_EvaluationsTuteurs_CompteRenduId",
                table: "EvaluationsTuteurs");

            migrationBuilder.DropIndex(
                name: "IX_EvaluationsTuteurs_UtilisateurId",
                table: "EvaluationsTuteurs");

            migrationBuilder.DropColumn(
                name: "UtilisateurId",
                table: "EvaluationsTuteurs");

            migrationBuilder.CreateIndex(
                name: "IX_EvaluationsTuteurs_CompteRenduId",
                table: "EvaluationsTuteurs",
                column: "CompteRenduId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CompteRendus_Utilisateurs_EtudiantId",
                table: "CompteRendus",
                column: "EtudiantId",
                principalTable: "Utilisateurs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EvaluationsTuteurs_CompteRendus_CompteRenduId",
                table: "EvaluationsTuteurs",
                column: "CompteRenduId",
                principalTable: "CompteRendus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EvaluationsTuteurs_Utilisateurs_TuteurId",
                table: "EvaluationsTuteurs",
                column: "TuteurId",
                principalTable: "Utilisateurs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FichesEtudiants_Utilisateurs_EtudiantId",
                table: "FichesEtudiants",
                column: "EtudiantId",
                principalTable: "Utilisateurs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
