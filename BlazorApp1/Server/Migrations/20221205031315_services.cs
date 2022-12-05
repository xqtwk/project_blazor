using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorApp1.Server.Migrations
{
    /// <inheritdoc />
    public partial class services : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ClientSurname",
                table: "clientdetails",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "clientdetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "ParentStudent",
                columns: table => new
                {
                    ChildsClientId = table.Column<int>(type: "int", nullable: false),
                    ParentsClientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParentStudent", x => new { x.ChildsClientId, x.ParentsClientId });
                    table.ForeignKey(
                        name: "FK_ParentStudent_clientdetails_ChildsClientId",
                        column: x => x.ChildsClientId,
                        principalTable: "clientdetails",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ParentStudent_clientdetails_ParentsClientId",
                        column: x => x.ParentsClientId,
                        principalTable: "clientdetails",
                        principalColumn: "ClientId");
                });

            migrationBuilder.CreateTable(
                name: "StudentTeacher",
                columns: table => new
                {
                    StudentsClientId = table.Column<int>(type: "int", nullable: false),
                    TeachersClientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentTeacher", x => new { x.StudentsClientId, x.TeachersClientId });
                    table.ForeignKey(
                        name: "FK_StudentTeacher_clientdetails_StudentsClientId",
                        column: x => x.StudentsClientId,
                        principalTable: "clientdetails",
                        principalColumn: "ClientId");
                    table.ForeignKey(
                        name: "FK_StudentTeacher_clientdetails_TeachersClientId",
                        column: x => x.TeachersClientId,
                        principalTable: "clientdetails",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ParentStudent_ParentsClientId",
                table: "ParentStudent",
                column: "ParentsClientId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentTeacher_TeachersClientId",
                table: "StudentTeacher",
                column: "TeachersClientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ParentStudent");

            migrationBuilder.DropTable(
                name: "StudentTeacher");

            migrationBuilder.DropColumn(
                name: "ClientSurname",
                table: "clientdetails");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "clientdetails");
        }
    }
}
