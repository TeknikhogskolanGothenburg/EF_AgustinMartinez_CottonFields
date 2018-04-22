using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CottonFields.Data.Migrations
{
    public partial class rename_MatrixNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MatrixNumbers_Releases_ReleaseID",
                table: "MatrixNumbers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MatrixNumbers",
                table: "MatrixNumbers");

            migrationBuilder.RenameTable(
                name: "MatrixNumbers",
                newName: "MatrixNumber");

            migrationBuilder.RenameIndex(
                name: "IX_MatrixNumbers_ReleaseID",
                table: "MatrixNumber",
                newName: "IX_MatrixNumber_ReleaseID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MatrixNumber",
                table: "MatrixNumber",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_MatrixNumber_Releases_ReleaseID",
                table: "MatrixNumber",
                column: "ReleaseID",
                principalTable: "Releases",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MatrixNumber_Releases_ReleaseID",
                table: "MatrixNumber");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MatrixNumber",
                table: "MatrixNumber");

            migrationBuilder.RenameTable(
                name: "MatrixNumber",
                newName: "MatrixNumbers");

            migrationBuilder.RenameIndex(
                name: "IX_MatrixNumber_ReleaseID",
                table: "MatrixNumbers",
                newName: "IX_MatrixNumbers_ReleaseID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MatrixNumbers",
                table: "MatrixNumbers",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_MatrixNumbers_Releases_ReleaseID",
                table: "MatrixNumbers",
                column: "ReleaseID",
                principalTable: "Releases",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
