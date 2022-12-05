using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorApp1.Server.Migrations
{
    /// <inheritdoc />
    public partial class test1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParentStudent_clientdetails_ChildsClientId",
                table: "ParentStudent");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentTeacher_clientdetails_StudentsClientId",
                table: "StudentTeacher");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ParentStudent",
                table: "ParentStudent");

            migrationBuilder.DropIndex(
                name: "IX_ParentStudent_ParentsClientId",
                table: "ParentStudent");

            migrationBuilder.RenameColumn(
                name: "StudentsClientId",
                table: "StudentTeacher",
                newName: "Teachers");

            migrationBuilder.RenameColumn(
                name: "ChildsClientId",
                table: "ParentStudent",
                newName: "Teachers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ParentStudent",
                table: "ParentStudent",
                columns: new[] { "ParentsClientId", "Teachers" });

            migrationBuilder.CreateIndex(
                name: "IX_ParentStudent_Teachers",
                table: "ParentStudent",
                column: "Teachers");

            migrationBuilder.AddForeignKey(
                name: "FK_ParentStudent_clientdetails_Teachers",
                table: "ParentStudent",
                column: "Teachers",
                principalTable: "clientdetails",
                principalColumn: "ClientId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentTeacher_clientdetails_Teachers",
                table: "StudentTeacher",
                column: "Teachers",
                principalTable: "clientdetails",
                principalColumn: "ClientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParentStudent_clientdetails_Teachers",
                table: "ParentStudent");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentTeacher_clientdetails_Teachers",
                table: "StudentTeacher");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ParentStudent",
                table: "ParentStudent");

            migrationBuilder.DropIndex(
                name: "IX_ParentStudent_Teachers",
                table: "ParentStudent");

            migrationBuilder.RenameColumn(
                name: "Teachers",
                table: "StudentTeacher",
                newName: "StudentsClientId");

            migrationBuilder.RenameColumn(
                name: "Teachers",
                table: "ParentStudent",
                newName: "ChildsClientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ParentStudent",
                table: "ParentStudent",
                columns: new[] { "ChildsClientId", "ParentsClientId" });

            migrationBuilder.CreateIndex(
                name: "IX_ParentStudent_ParentsClientId",
                table: "ParentStudent",
                column: "ParentsClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_ParentStudent_clientdetails_ChildsClientId",
                table: "ParentStudent",
                column: "ChildsClientId",
                principalTable: "clientdetails",
                principalColumn: "ClientId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentTeacher_clientdetails_StudentsClientId",
                table: "StudentTeacher",
                column: "StudentsClientId",
                principalTable: "clientdetails",
                principalColumn: "ClientId");
        }
    }
}
