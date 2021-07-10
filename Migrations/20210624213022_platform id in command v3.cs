using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Comandos.Migrations
{
    public partial class platformidincommandv3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "platform",
                columns: table => new
                {
                    PlatformId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Descripcion = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_platform", x => x.PlatformId);
                });

            migrationBuilder.CreateTable(
                name: "command",
                columns: table => new
                {
                    CommandId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    HowTo = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    Line = table.Column<string>(type: "text", nullable: false),
                    PlatformId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_command", x => x.CommandId);
                    table.ForeignKey(
                        name: "FK_command_platform_PlatformId",
                        column: x => x.PlatformId,
                        principalTable: "platform",
                        principalColumn: "PlatformId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_command_PlatformId",
                table: "command",
                column: "PlatformId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "command");

            migrationBuilder.DropTable(
                name: "platform");
        }
    }
}
