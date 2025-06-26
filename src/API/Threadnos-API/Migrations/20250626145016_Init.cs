using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Threadnos_API.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    create_at = table.Column<DateTime>(type: "timestamp", nullable: false),
                    update_at = table.Column<DateTime>(type: "timestamp", nullable: false),
                    last_login = table.Column<DateTime>(type: "timestamp", nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    is_verified = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "threadline",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    create_at = table.Column<DateTime>(type: "timestamp", nullable: false),
                    update_at = table.Column<DateTime>(type: "timestamp", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_threadline", x => x.id);
                    table.ForeignKey(
                        name: "fk_threadline_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "labels",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    create_at = table.Column<DateTime>(type: "timestamp", nullable: false),
                    update_at = table.Column<DateTime>(type: "timestamp", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    threadline_id = table.Column<Guid>(type: "uuid", nullable: true),
                    user_id = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_labels", x => x.id);
                    table.ForeignKey(
                        name: "fk_labels_threadline_threadline_id",
                        column: x => x.threadline_id,
                        principalTable: "threadline",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_labels_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "pages",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    title = table.Column<string>(type: "text", nullable: true),
                    create_at = table.Column<DateTime>(type: "timestamp", nullable: false),
                    update_at = table.Column<DateTime>(type: "timestamp", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    content_id = table.Column<Guid>(type: "uuid", nullable: false),
                    content = table.Column<string>(type: "text", nullable: true),
                    order = table.Column<int>(type: "integer", nullable: false),
                    threadline_id = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_pages", x => x.id);
                    table.ForeignKey(
                        name: "fk_pages_threadline_threadline_id",
                        column: x => x.threadline_id,
                        principalTable: "threadline",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "ix_labels_threadline_id",
                table: "labels",
                column: "threadline_id");

            migrationBuilder.CreateIndex(
                name: "ix_labels_user_id",
                table: "labels",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_pages_threadline_id",
                table: "pages",
                column: "threadline_id");

            migrationBuilder.CreateIndex(
                name: "ix_threadline_user_id",
                table: "threadline",
                column: "user_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "labels");

            migrationBuilder.DropTable(
                name: "pages");

            migrationBuilder.DropTable(
                name: "threadline");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
