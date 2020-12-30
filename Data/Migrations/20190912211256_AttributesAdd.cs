using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace OracleCOEWorkTracking.Data.Migrations
{
    public partial class AttributesAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "RequestAttributes");

            migrationBuilder.AddColumn<int>(
                name: "AtributeId",
                table: "RequestAttributes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AttributeId",
                table: "RequestAttributes",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Attributes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<string>(maxLength: 50, nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    DeleteMark = table.Column<bool>(nullable: false),
                    ModifiedBy = table.Column<string>(maxLength: 50, nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attributes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RequestAttributes_AttributeId",
                table: "RequestAttributes",
                column: "AttributeId");

            migrationBuilder.AddForeignKey(
                name: "FK_RequestAttributes_Attributes_AttributeId",
                table: "RequestAttributes",
                column: "AttributeId",
                principalTable: "Attributes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequestAttributes_Attributes_AttributeId",
                table: "RequestAttributes");

            migrationBuilder.DropTable(
                name: "Attributes");

            migrationBuilder.DropIndex(
                name: "IX_RequestAttributes_AttributeId",
                table: "RequestAttributes");

            migrationBuilder.DropColumn(
                name: "AtributeId",
                table: "RequestAttributes");

            migrationBuilder.DropColumn(
                name: "AttributeId",
                table: "RequestAttributes");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "RequestAttributes",
                nullable: true);
        }
    }
}
