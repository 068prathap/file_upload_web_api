using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FileUploadWebApi.Migrations
{
    /// <inheritdoc />
    public partial class changedtablenameandtype : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FileData",
                table: "FileDetails",
                newName: "File");

            migrationBuilder.AlterColumn<string>(
                name: "FileType",
                table: "FileDetails",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "File",
                table: "FileDetails",
                newName: "FileData");

            migrationBuilder.AlterColumn<int>(
                name: "FileType",
                table: "FileDetails",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
