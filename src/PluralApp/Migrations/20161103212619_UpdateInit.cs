using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PluralApp.Migrations
{
    public partial class UpdateInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ItemCounters",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    card = table.Column<int>(nullable: false),
                    cup = table.Column<int>(nullable: false),
                    tshirt = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemCounters", x => x.id);
                });

            migrationBuilder.AddColumn<int>(
                name: "id_in_category",
                table: "ItemModels",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "item_description",
                table: "ItemModels",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "item_price",
                table: "ItemModels",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "id_in_category",
                table: "ItemModels");

            migrationBuilder.DropColumn(
                name: "item_description",
                table: "ItemModels");

            migrationBuilder.DropColumn(
                name: "item_price",
                table: "ItemModels");

            migrationBuilder.DropTable(
                name: "ItemCounters");
        }
    }
}
