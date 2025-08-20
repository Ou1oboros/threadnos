using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Threadnos_API.Migrations
{
    /// <inheritdoc />
    public partial class alter_column_name_order_to_sort_order : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "order",
                table: "pages",
                newName: "sort_order");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "sort_order",
                table: "pages",
                newName: "order");
        }
    }
}
