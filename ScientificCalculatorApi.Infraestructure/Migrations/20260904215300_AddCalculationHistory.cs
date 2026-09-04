using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScientificCalculatorApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddCalculationHistory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_CalculationHistory_UserId",
                table: "CalculationHistory",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CalculationHistory_Users_UserId",
                table: "CalculationHistory",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CalculationHistory_Users_UserId",
                table: "CalculationHistory");

            migrationBuilder.DropIndex(
                name: "IX_CalculationHistory_UserId",
                table: "CalculationHistory");
        }
    }
}
