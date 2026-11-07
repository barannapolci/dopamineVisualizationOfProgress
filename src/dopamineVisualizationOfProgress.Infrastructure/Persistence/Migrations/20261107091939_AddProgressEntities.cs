using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dopamineVisualizationOfProgress.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddProgressEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UncontroledWork",
                table: "Days",
                newName: "UncontrolledWork");

            migrationBuilder.AddColumn<DateOnly>(
                name: "Date",
                table: "Days",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Days");

            migrationBuilder.RenameColumn(
                name: "UncontrolledWork",
                table: "Days",
                newName: "UncontroledWork");
        }
    }
}
