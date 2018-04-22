using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CottonFields.Data.Migrations
{
    public partial class release_correction2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Artist",
                table: "Releases");

            migrationBuilder.DropColumn(
                name: "Label",
                table: "Releases");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Artist",
                table: "Releases",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Label",
                table: "Releases",
                nullable: true);
        }
    }
}
