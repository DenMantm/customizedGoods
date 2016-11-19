using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CustomizedGoods.Migrations
{
    public partial class changingschema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "card",
                table: "ItemCounters");

            migrationBuilder.AddColumn<int>(
                name: "hat",
                table: "ItemCounters",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "hat",
                table: "ItemCounters");

            migrationBuilder.AddColumn<int>(
                name: "card",
                table: "ItemCounters",
                nullable: false,
                defaultValue: 0);
        }
    }
}
