using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dopamineVisualizationOfProgress.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Days",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    HardWork = table.Column<float>(type: "real", nullable: false),
                    UncontroledWork = table.Column<float>(type: "real", nullable: false),
                    StrengthTraining = table.Column<float>(type: "real", nullable: false),
                    CardioTraining = table.Column<float>(type: "real", nullable: false),
                    DopamineProcrastination = table.Column<float>(type: "real", nullable: false),
                    DietInfo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Days", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Days");
        }
    }
}
