using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NotesProject.Migrations
{
    /// <inheritdoc />
    public partial class mg3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Notes_ParentId",
                schema: "Note",
                table: "Notes");

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Notes_ParentId",
                schema: "Note",
                table: "Notes",
                column: "ParentId",
                principalSchema: "Note",
                principalTable: "Notes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Notes_ParentId",
                schema: "Note",
                table: "Notes");

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Notes_ParentId",
                schema: "Note",
                table: "Notes",
                column: "ParentId",
                principalSchema: "Note",
                principalTable: "Notes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
