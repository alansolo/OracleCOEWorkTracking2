using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace OracleCOEWorkTracking.Data.Migrations
{
    public partial class ViewQueryRefactor3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RequestViewProperties");

            migrationBuilder.DropColumn(
                name: "Query",
                table: "RequestViews");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Query",
                table: "RequestViews",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "RequestViewProperties",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ControlListQuery = table.Column<string>(nullable: true),
                    ControlType = table.Column<string>(nullable: true),
                    ControlValueQuery = table.Column<string>(nullable: true),
                    QueryColumnName = table.Column<string>(nullable: true),
                    UIDisplayName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestViewProperties", x => x.Id);
                });
        }
    }
}
