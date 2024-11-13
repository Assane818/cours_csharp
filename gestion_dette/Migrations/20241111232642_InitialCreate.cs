using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace gestion_dette.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "articles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Libelle = table.Column<string>(type: "text", nullable: false),
                    Prix = table.Column<double>(type: "double precision", nullable: false),
                    Quantite = table.Column<double>(type: "double precision", nullable: false),
                    create_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    update_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_articles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nom = table.Column<string>(type: "text", nullable: false),
                    Prenom = table.Column<string>(type: "text", nullable: false),
                    Login = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    Etat = table.Column<bool>(type: "boolean", nullable: false),
                    Role = table.Column<int>(type: "integer", nullable: false),
                    create_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    update_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Surname = table.Column<string>(type: "text", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: true),
                    create_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    update_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_clients_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "dettes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Montant = table.Column<double>(type: "double precision", nullable: false),
                    MontantVerser = table.Column<double>(type: "double precision", nullable: false),
                    ClientId = table.Column<int>(type: "integer", nullable: false),
                    Etat = table.Column<int>(type: "integer", nullable: false),
                    create_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    update_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dettes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dettes_clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "details",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Quantite = table.Column<double>(type: "double precision", nullable: false),
                    ArticleId = table.Column<int>(type: "integer", nullable: false),
                    DetteId = table.Column<int>(type: "integer", nullable: false),
                    create_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    update_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_details", x => x.Id);
                    table.ForeignKey(
                        name: "FK_details_articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_details_dettes_DetteId",
                        column: x => x.DetteId,
                        principalTable: "dettes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "paiements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    MontantPayer = table.Column<double>(type: "double precision", nullable: false),
                    DetteId = table.Column<int>(type: "integer", nullable: false),
                    create_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    update_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_paiements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_paiements_dettes_DetteId",
                        column: x => x.DetteId,
                        principalTable: "dettes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_clients_UserId",
                table: "clients",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_details_ArticleId",
                table: "details",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_details_DetteId",
                table: "details",
                column: "DetteId");

            migrationBuilder.CreateIndex(
                name: "IX_dettes_ClientId",
                table: "dettes",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_paiements_DetteId",
                table: "paiements",
                column: "DetteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "details");

            migrationBuilder.DropTable(
                name: "paiements");

            migrationBuilder.DropTable(
                name: "articles");

            migrationBuilder.DropTable(
                name: "dettes");

            migrationBuilder.DropTable(
                name: "clients");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
