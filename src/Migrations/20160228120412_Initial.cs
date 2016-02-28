using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace src.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    LastModificationDate = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.Id);
                });
            migrationBuilder.CreateTable(
                name: "Systems",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    LastModificationDate = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_System", x => x.Id);
                });
            migrationBuilder.CreateTable(
                name: "SystemVersions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    LastModificationDate = table.Column<DateTime>(nullable: true),
                    Major = table.Column<int>(nullable: false),
                    Minor = table.Column<int>(nullable: false),
                    SystemId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemVersion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SystemVersion_System_SystemId",
                        column: x => x.SystemId,
                        principalTable: "Systems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });
            migrationBuilder.CreateTable(
                name: "LicenseTemplates",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    LastModificationDate = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    SystemVersionId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LicenseTemplate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LicenseTemplate_SystemVersion_SystemVersionId",
                        column: x => x.SystemVersionId,
                        principalTable: "SystemVersions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ClientId = table.Column<Guid>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    LastModificationDate = table.Column<DateTime>(nullable: true),
                    SystemVersionId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Product_SystemVersion_SystemVersionId",
                        column: x => x.SystemVersionId,
                        principalTable: "SystemVersions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });
            migrationBuilder.CreateTable(
                name: "LicenseTemplateElements",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    LastModificationDate = table.Column<DateTime>(nullable: true),
                    Level = table.Column<int>(nullable: false),
                    LicenseTemplateId = table.Column<Guid>(nullable: false),
                    Mnemonic = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    ParentId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LicenseTemplateElement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LicenseTemplateElement_LicenseTemplate_LicenseTemplateId",
                        column: x => x.LicenseTemplateId,
                        principalTable: "LicenseTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LicenseTemplateElement_LicenseTemplateElement_ParentId",
                        column: x => x.ParentId,
                        principalTable: "LicenseTemplateElements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });
            migrationBuilder.CreateTable(
                name: "Licenses",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    LastModificationDate = table.Column<DateTime>(nullable: true),
                    LicenseTemplateId = table.Column<Guid>(nullable: false),
                    Number = table.Column<int>(nullable: false),
                    ProductId = table.Column<Guid>(nullable: false),
                    ValidFrom = table.Column<DateTime>(nullable: false),
                    ValidTo = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_License", x => x.Id);
                    table.ForeignKey(
                        name: "FK_License_LicenseTemplate_LicenseTemplateId",
                        column: x => x.LicenseTemplateId,
                        principalTable: "LicenseTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_License_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });
            migrationBuilder.CreateTable(
                name: "LicenseElements",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    LastModificationDate = table.Column<DateTime>(nullable: true),
                    LicenseId = table.Column<Guid>(nullable: true),
                    LicenseTemplateElementId = table.Column<Guid>(nullable: false),
                    ParentId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LicenseElement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LicenseElement_License_LicenseId",
                        column: x => x.LicenseId,
                        principalTable: "Licenses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LicenseElement_LicenseTemplateElement_LicenseTemplateElementId",
                        column: x => x.LicenseTemplateElementId,
                        principalTable: "LicenseTemplateElements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LicenseElement_LicenseElement_ParentId",
                        column: x => x.ParentId,
                        principalTable: "LicenseElements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("LicenseElements");
            migrationBuilder.DropTable("Licenses");
            migrationBuilder.DropTable("LicenseTemplateElements");
            migrationBuilder.DropTable("Products");
            migrationBuilder.DropTable("LicenseTemplates");
            migrationBuilder.DropTable("Clients");
            migrationBuilder.DropTable("SystemVersions");
            migrationBuilder.DropTable("Systems");
        }
    }
}
