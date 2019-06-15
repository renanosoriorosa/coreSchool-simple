using Microsoft.EntityFrameworkCore.Migrations;

namespace coreSchoolSimple.Migrations
{
    public partial class AjusteNaEntidadeProfessor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProfessorId",
                table: "Aluno",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Aluno_ProfessorId",
                table: "Aluno",
                column: "ProfessorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Aluno_Professor_ProfessorId",
                table: "Aluno",
                column: "ProfessorId",
                principalTable: "Professor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aluno_Professor_ProfessorId",
                table: "Aluno");

            migrationBuilder.DropIndex(
                name: "IX_Aluno_ProfessorId",
                table: "Aluno");

            migrationBuilder.DropColumn(
                name: "ProfessorId",
                table: "Aluno");
        }
    }
}
