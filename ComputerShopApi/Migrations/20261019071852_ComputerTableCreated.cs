using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ComputerShopApi.Migrations
{
    /// <inheritdoc />
    public partial class ComputerTableCreated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "varchar(37)",
                table: "Computers",
                newName: "Brand");

            migrationBuilder.RenameColumn(
                name: "double",
                table: "Computers",
                newName: "Display");

            migrationBuilder.RenameColumn(
                name: "30",
                table: "Computers",
                newName: "Type");

            migrationBuilder.AlterColumn<string>(
                name: "Brand",
                table: "Computers",
                type: " varchar(37)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<double>(
                name: "Display",
                table: "Computers",
                type: "double",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "float");

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "Computers",
                type: "varchar(30)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Computers",
                newName: "30");

            migrationBuilder.RenameColumn(
                name: "Display",
                table: "Computers",
                newName: "double");

            migrationBuilder.RenameColumn(
                name: "Brand",
                table: "Computers",
                newName: "varchar(37)");

            migrationBuilder.AlterColumn<string>(
                name: "30",
                table: "Computers",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(30)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<float>(
                name: "double",
                table: "Computers",
                type: "float",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double");

            migrationBuilder.AlterColumn<string>(
                name: "varchar(37)",
                table: "Computers",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: " varchar(37)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
