using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CursoIdiomasApi.Migrations
{
    /// <inheritdoc />
    public partial class ConfigCpf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {          

            migrationBuilder.AlterColumn<string>(
                name: "Cpf",
                table: "Alunos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int"); 
            

        }   

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {          

            migrationBuilder.AlterColumn<int>(
                name: "Cpf",
                table: "Alunos",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
            
        }
    }
}
