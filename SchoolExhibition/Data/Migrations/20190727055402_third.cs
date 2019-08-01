using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SchoolExhibition.Data.Migrations
{
    public partial class third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExhibitionResultMasters",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClassMasterID = table.Column<int>(nullable: false),
                    ProjectName = table.Column<string>(nullable: true),
                    Result = table.Column<string>(nullable: true),
                    StudentMasterID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExhibitionResultMasters", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ExhibitionResultMasters_ClassMasters_ClassMasterID",
                        column: x => x.ClassMasterID,
                        principalTable: "ClassMasters",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExhibitionResultMasters_StudentMasters_StudentMasterID",
                        column: x => x.StudentMasterID,
                        principalTable: "StudentMasters",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExhibitionResultMasters_ClassMasterID",
                table: "ExhibitionResultMasters",
                column: "ClassMasterID");

            migrationBuilder.CreateIndex(
                name: "IX_ExhibitionResultMasters_StudentMasterID",
                table: "ExhibitionResultMasters",
                column: "StudentMasterID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExhibitionResultMasters");
        }
    }
}
