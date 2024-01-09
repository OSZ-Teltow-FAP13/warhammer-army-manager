using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Warhammer_Army_Manager.Migrations
{
    /// <inheritdoc />
    public partial class UnitMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Armys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Points = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Armys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Keywords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Keyword = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Keywords", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Wounds = table.Column<int>(type: "INTEGER", nullable: false),
                    Move = table.Column<int>(type: "INTEGER", nullable: false),
                    Bravery = table.Column<int>(type: "INTEGER", nullable: false),
                    Save = table.Column<string>(type: "TEXT", maxLength: 2, nullable: false),
                    Points = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Weapons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Type = table.Column<string>(type: "TEXT", maxLength: 7, nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Range = table.Column<int>(type: "INTEGER", nullable: false),
                    Attacks = table.Column<string>(type: "TEXT", maxLength: 5, nullable: false),
                    ToHit = table.Column<string>(type: "TEXT", maxLength: 2, nullable: true),
                    ToWound = table.Column<string>(type: "TEXT", maxLength: 2, nullable: true),
                    Rend = table.Column<string>(type: "TEXT", nullable: true),
                    Damage = table.Column<string>(type: "TEXT", maxLength: 5, nullable: true),
                    SpecialEffect = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weapons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ArmysUnit",
                columns: table => new
                {
                    ArmysId = table.Column<int>(type: "INTEGER", nullable: false),
                    UnitsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArmysUnit", x => new { x.ArmysId, x.UnitsId });
                    table.ForeignKey(
                        name: "FK_ArmysUnit_Armys_ArmysId",
                        column: x => x.ArmysId,
                        principalTable: "Armys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArmysUnit_Units_UnitsId",
                        column: x => x.UnitsId,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KeywordsUnit",
                columns: table => new
                {
                    KeywordsId = table.Column<int>(type: "INTEGER", nullable: false),
                    UnitsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KeywordsUnit", x => new { x.KeywordsId, x.UnitsId });
                    table.ForeignKey(
                        name: "FK_KeywordsUnit_Keywords_KeywordsId",
                        column: x => x.KeywordsId,
                        principalTable: "Keywords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KeywordsUnit_Units_UnitsId",
                        column: x => x.UnitsId,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UnitWeapons",
                columns: table => new
                {
                    UnitsId = table.Column<int>(type: "INTEGER", nullable: false),
                    WeaponsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitWeapons", x => new { x.UnitsId, x.WeaponsId });
                    table.ForeignKey(
                        name: "FK_UnitWeapons_Units_UnitsId",
                        column: x => x.UnitsId,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UnitWeapons_Weapons_WeaponsId",
                        column: x => x.WeaponsId,
                        principalTable: "Weapons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArmysUnit_UnitsId",
                table: "ArmysUnit",
                column: "UnitsId");

            migrationBuilder.CreateIndex(
                name: "IX_KeywordsUnit_UnitsId",
                table: "KeywordsUnit",
                column: "UnitsId");

            migrationBuilder.CreateIndex(
                name: "IX_UnitWeapons_WeaponsId",
                table: "UnitWeapons",
                column: "WeaponsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArmysUnit");

            migrationBuilder.DropTable(
                name: "KeywordsUnit");

            migrationBuilder.DropTable(
                name: "UnitWeapons");

            migrationBuilder.DropTable(
                name: "Armys");

            migrationBuilder.DropTable(
                name: "Keywords");

            migrationBuilder.DropTable(
                name: "Units");

            migrationBuilder.DropTable(
                name: "Weapons");
        }
    }
}
