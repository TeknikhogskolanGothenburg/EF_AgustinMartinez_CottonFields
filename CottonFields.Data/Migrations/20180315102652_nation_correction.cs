using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CottonFields.Data.Migrations
{
    public partial class nation_correction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nationality",
                table: "Users",
                newName: "Country");

            migrationBuilder.RenameColumn(
                name: "Nationality",
                table: "Artists",
                newName: "Country");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Country",
                table: "Users",
                newName: "Nationality");

            migrationBuilder.RenameColumn(
                name: "Country",
                table: "Artists",
                newName: "Nationality");
        }
    }
}
