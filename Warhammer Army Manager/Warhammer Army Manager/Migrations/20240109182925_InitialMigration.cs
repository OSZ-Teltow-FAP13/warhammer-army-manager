using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Warhammer_Army_Manager.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Army",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Points = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Army", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Keywords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
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
                name: "ArmyUnit",
                columns: table => new
                {
                    ArmysId = table.Column<int>(type: "INTEGER", nullable: false),
                    UnitsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArmyUnit", x => new { x.ArmysId, x.UnitsId });
                    table.ForeignKey(
                        name: "FK_ArmyUnit_Army_ArmysId",
                        column: x => x.ArmysId,
                        principalTable: "Army",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArmyUnit_Units_UnitsId",
                        column: x => x.UnitsId,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KeywordUnit",
                columns: table => new
                {
                    KeywordsId = table.Column<int>(type: "INTEGER", nullable: false),
                    UnitsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KeywordUnit", x => new { x.KeywordsId, x.UnitsId });
                    table.ForeignKey(
                        name: "FK_KeywordUnit_Keywords_KeywordsId",
                        column: x => x.KeywordsId,
                        principalTable: "Keywords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KeywordUnit_Units_UnitsId",
                        column: x => x.UnitsId,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UnitWeapon",
                columns: table => new
                {
                    UnitsId = table.Column<int>(type: "INTEGER", nullable: false),
                    WeaponsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitWeapon", x => new { x.UnitsId, x.WeaponsId });
                    table.ForeignKey(
                        name: "FK_UnitWeapon_Units_UnitsId",
                        column: x => x.UnitsId,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UnitWeapon_Weapons_WeaponsId",
                        column: x => x.WeaponsId,
                        principalTable: "Weapons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArmyUnit_UnitsId",
                table: "ArmyUnit",
                column: "UnitsId");

            migrationBuilder.CreateIndex(
                name: "IX_KeywordUnit_UnitsId",
                table: "KeywordUnit",
                column: "UnitsId");

            migrationBuilder.CreateIndex(
                name: "IX_UnitWeapon_WeaponsId",
                table: "UnitWeapon",
                column: "WeaponsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArmyUnit");

            migrationBuilder.DropTable(
                name: "KeywordUnit");

            migrationBuilder.DropTable(
                name: "UnitWeapon");

            migrationBuilder.DropTable(
                name: "Army");

            migrationBuilder.DropTable(
                name: "Keywords");

            migrationBuilder.DropTable(
                name: "Units");

            migrationBuilder.DropTable(
                name: "Weapons");
        }
    }
}
