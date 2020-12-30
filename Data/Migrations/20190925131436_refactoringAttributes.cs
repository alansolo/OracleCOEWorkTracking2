using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace OracleCOEWorkTracking.Data.Migrations
{
    public partial class refactoringAttributes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RequestAttributes");

            migrationBuilder.DropTable(
                name: "Attributes");

            migrationBuilder.RenameColumn(
                name: "RequestAttributes",
                table: "RequestViews",
                newName: "Attribute9");

            migrationBuilder.AddColumn<bool>(
                name: "Attribute1",
                table: "RequestViews",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Attribute10",
                table: "RequestViews",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Attribute2",
                table: "RequestViews",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Attribute3",
                table: "RequestViews",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Attribute4",
                table: "RequestViews",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Attribute5",
                table: "RequestViews",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Attribute6",
                table: "RequestViews",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Attribute7",
                table: "RequestViews",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Attribute8",
                table: "RequestViews",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Attribute1",
                table: "Requests",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Attribute10",
                table: "Requests",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Attribute2",
                table: "Requests",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Attribute3",
                table: "Requests",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Attribute4",
                table: "Requests",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Attribute5",
                table: "Requests",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Attribute6",
                table: "Requests",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Attribute7",
                table: "Requests",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Attribute8",
                table: "Requests",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Attribute9",
                table: "Requests",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Attribute1",
                table: "RequestViews");

            migrationBuilder.DropColumn(
                name: "Attribute10",
                table: "RequestViews");

            migrationBuilder.DropColumn(
                name: "Attribute2",
                table: "RequestViews");

            migrationBuilder.DropColumn(
                name: "Attribute3",
                table: "RequestViews");

            migrationBuilder.DropColumn(
                name: "Attribute4",
                table: "RequestViews");

            migrationBuilder.DropColumn(
                name: "Attribute5",
                table: "RequestViews");

            migrationBuilder.DropColumn(
                name: "Attribute6",
                table: "RequestViews");

            migrationBuilder.DropColumn(
                name: "Attribute7",
                table: "RequestViews");

            migrationBuilder.DropColumn(
                name: "Attribute8",
                table: "RequestViews");

            migrationBuilder.DropColumn(
                name: "Attribute1",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "Attribute10",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "Attribute2",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "Attribute3",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "Attribute4",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "Attribute5",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "Attribute6",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "Attribute7",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "Attribute8",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "Attribute9",
                table: "Requests");

            migrationBuilder.RenameColumn(
                name: "Attribute9",
                table: "RequestViews",
                newName: "RequestAttributes");

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

            migrationBuilder.CreateTable(
                name: "RequestAttributes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AttributeId = table.Column<int>(nullable: false),
                    RequestId = table.Column<int>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestAttributes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequestAttributes_Attributes_AttributeId",
                        column: x => x.AttributeId,
                        principalTable: "Attributes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RequestAttributes_Requests_RequestId",
                        column: x => x.RequestId,
                        principalTable: "Requests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RequestAttributes_AttributeId",
                table: "RequestAttributes",
                column: "AttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestAttributes_RequestId",
                table: "RequestAttributes",
                column: "RequestId");
        }
    }
}
