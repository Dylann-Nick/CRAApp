using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Utilisateurs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MotDePasse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilisateurs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompteRendus",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EtudiantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Mission = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EtapesRealisation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TravailEntreprise = table.Column<bool>(type: "bit", nullable: false),
                    Difficultes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompetanceMisesEnOeuvre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RetourTuteur = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreation = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompteRendus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompteRendus_Utilisateurs_EtudiantId",
                        column: x => x.EtudiantId,
                        principalTable: "Utilisateurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FichesEtudiants",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EtudiantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Formation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Promotion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FichesEtudiants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FichesEtudiants_Utilisateurs_EtudiantId",
                        column: x => x.EtudiantId,
                        principalTable: "Utilisateurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EvaluationsTuteurs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompteRenduId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TuteurId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Commentaire = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Note = table.Column<int>(type: "int", nullable: false),
                    DateEvaluation = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvaluationsTuteurs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EvaluationsTuteurs_CompteRendus_CompteRenduId",
                        column: x => x.CompteRenduId,
                        principalTable: "CompteRendus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EvaluationsTuteurs_Utilisateurs_TuteurId",
                        column: x => x.TuteurId,
                        principalTable: "Utilisateurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompteRendus_EtudiantId",
                table: "CompteRendus",
                column: "EtudiantId");

            migrationBuilder.CreateIndex(
                name: "IX_EvaluationsTuteurs_CompteRenduId",
                table: "EvaluationsTuteurs",
                column: "CompteRenduId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EvaluationsTuteurs_TuteurId",
                table: "EvaluationsTuteurs",
                column: "TuteurId");

            migrationBuilder.CreateIndex(
                name: "IX_FichesEtudiants_EtudiantId",
                table: "FichesEtudiants",
                column: "EtudiantId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EvaluationsTuteurs");

            migrationBuilder.DropTable(
                name: "FichesEtudiants");

            migrationBuilder.DropTable(
                name: "CompteRendus");

            migrationBuilder.DropTable(
                name: "Utilisateurs");
        }
    }
}
