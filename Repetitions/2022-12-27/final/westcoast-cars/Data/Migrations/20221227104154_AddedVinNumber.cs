using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace westcoastcars.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedVinNumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "VinNumber",
                table: "Vehicles",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VinNumber",
                table: "Vehicles");
        }
    }
}
