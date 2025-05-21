using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Target.Migrations
{
    /// <inheritdoc />
    public partial class AddDiaValorTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DiaValores",
                table: "DiaValores");

            migrationBuilder.RenameTable(
                name: "DiaValores",
                newName: "DiaValor");

            migrationBuilder.AlterColumn<decimal>(
                name: "Valor",
                table: "DiaValor",
                type: "decimal(10,4)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DiaValor",
                table: "DiaValor",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DiaValor",
                table: "DiaValor");

            migrationBuilder.RenameTable(
                name: "DiaValor",
                newName: "DiaValores");

            migrationBuilder.AlterColumn<double>(
                name: "Valor",
                table: "DiaValores",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,4)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DiaValores",
                table: "DiaValores",
                column: "Id");
        }
    }
}
