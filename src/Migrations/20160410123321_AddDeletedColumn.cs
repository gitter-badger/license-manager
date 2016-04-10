using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace src.Migrations
{
    public partial class AddDeletedColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "SystemVersions",
                nullable: false,
                defaultValue: false);
            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Systems",
                nullable: false,
                defaultValue: false);
            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Products",
                nullable: false,
                defaultValue: false);
            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "LicenseTemplateElements",
                nullable: false,
                defaultValue: false);
            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "LicenseTemplates",
                nullable: false,
                defaultValue: false);
            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "LicenseElements",
                nullable: false,
                defaultValue: false);
            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Licenses",
                nullable: false,
                defaultValue: false);
            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Clients",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "Deleted", table: "SystemVersions");
            migrationBuilder.DropColumn(name: "Deleted", table: "Systems");
            migrationBuilder.DropColumn(name: "Deleted", table: "Products");
            migrationBuilder.DropColumn(name: "Deleted", table: "LicenseTemplateElements");
            migrationBuilder.DropColumn(name: "Deleted", table: "LicenseTemplates");
            migrationBuilder.DropColumn(name: "Deleted", table: "LicenseElements");
            migrationBuilder.DropColumn(name: "Deleted", table: "Licenses");
            migrationBuilder.DropColumn(name: "Deleted", table: "Clients");
        }
    }
}
