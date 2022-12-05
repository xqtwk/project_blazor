using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorApp1.Server.Migrations
{
    /// <inheritdoc />
    public partial class first : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "clientdetails",
                columns: table => new
                {
                    ClientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    ClientSurname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false),
                    CellNumber = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    EmailId = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StoredFileName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clientdetails", x => x.ClientId);
                });

            migrationBuilder.CreateTable(
                name: "parentdetails",
                columns: table => new
                {
                    ClientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_parentdetails", x => x.ClientId);
                    table.ForeignKey(
                        name: "FK_parentdetails_clientdetails_ClientId",
                        column: x => x.ClientId,
                        principalTable: "clientdetails",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "studentdetails",
                columns: table => new
                {
                    ClientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_studentdetails", x => x.ClientId);
                    table.ForeignKey(
                        name: "FK_studentdetails_clientdetails_ClientId",
                        column: x => x.ClientId,
                        principalTable: "clientdetails",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "teacherdetails",
                columns: table => new
                {
                    ClientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_teacherdetails", x => x.ClientId);
                    table.ForeignKey(
                        name: "FK_teacherdetails_clientdetails_ClientId",
                        column: x => x.ClientId,
                        principalTable: "clientdetails",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ParentStudent",
                columns: table => new
                {
                    Parents = table.Column<int>(type: "int", nullable: false),
                    ParentsClientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParentStudent", x => new { x.Parents, x.ParentsClientId });
                    table.ForeignKey(
                        name: "FK_ParentStudent_parentdetails_ParentsClientId",
                        column: x => x.ParentsClientId,
                        principalTable: "parentdetails",
                        principalColumn: "ClientId");
                    table.ForeignKey(
                        name: "FK_ParentStudent_studentdetails_Parents",
                        column: x => x.Parents,
                        principalTable: "studentdetails",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentTeacher",
                columns: table => new
                {
                    Teachers = table.Column<int>(type: "int", nullable: false),
                    TeachersClientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentTeacher", x => new { x.Teachers, x.TeachersClientId });
                    table.ForeignKey(
                        name: "FK_StudentTeacher_studentdetails_Teachers",
                        column: x => x.Teachers,
                        principalTable: "studentdetails",
                        principalColumn: "ClientId");
                    table.ForeignKey(
                        name: "FK_StudentTeacher_teacherdetails_TeachersClientId",
                        column: x => x.TeachersClientId,
                        principalTable: "teacherdetails",
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

            migrationBuilder.DropTable(
                name: "parentdetails");

            migrationBuilder.DropTable(
                name: "studentdetails");

            migrationBuilder.DropTable(
                name: "teacherdetails");

            migrationBuilder.DropTable(
                name: "clientdetails");
        }
    }
}
