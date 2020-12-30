using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace OracleCOEWorkTracking.Data.Migrations
{
    public partial class _20200218 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.RenameColumn(
            //    name: "ViewRequestsADGroup",
            //    table: "EnvironmentSettings",
            //    newName: "AddRequestsADGroup");

            migrationBuilder.AddColumn<bool>(
                name: "Application",
                table: "RequestViews",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<int>(
                name: "ApplicationId",
                table: "Requests",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "AppId",
                table: "OwningStreams",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.CreateTable(
                name: "ApplicationModule",
                columns: table => new
                {
                    AppId = table.Column<int>(nullable: false),
                    ModuleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationModule", x => new { x.AppId, x.ModuleId });
                    table.ForeignKey(
                        name: "FK_ApplicationModule_Modules_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "Modules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Applications",
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
                    table.PrimaryKey("PK_Applications", x => x.Id);
                });


            //Add the default application:
            migrationBuilder.InsertData(
                table: "Applications",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "DeleteMark", "ModifiedBy", "ModifiedOn", "Name" },
                values: new object[] { 1, "bonte@ppg.com", DateTime.Now, false, "bonte@ppg.com", DateTime.Now, "NA R12"});
            migrationBuilder.InsertData(
                table: "Applications",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "DeleteMark", "ModifiedBy", "ModifiedOn", "Name" },
                values: new object[] { 2, "bonte@ppg.com", DateTime.Now, false, "bonte@ppg.com", DateTime.Now, "Comex R12" });
            migrationBuilder.InsertData(
                table: "Applications",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "DeleteMark", "ModifiedBy", "ModifiedOn", "Name" },
                values: new object[] { 3, "bonte@ppg.com", DateTime.Now, false, "bonte@ppg.com", DateTime.Now, "Europe R12" });
            
            migrationBuilder.CreateTable(
                name: "ApplicationOwningSite",
                columns: table => new
                {
                    AppId = table.Column<int>(nullable: false),
                    OwningSiteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationOwningSite", x => new { x.AppId, x.OwningSiteId });
                    table.ForeignKey(
                        name: "FK_ApplicationOwningSite_Applications_AppId",
                        column: x => x.AppId,
                        principalTable: "Applications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationOwningSite_OwningSites_OwningSiteId",
                        column: x => x.OwningSiteId,
                        principalTable: "OwningSites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationRegion",
                columns: table => new
                {
                    AppId = table.Column<int>(nullable: false),
                    RegionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationRegion", x => new { x.AppId, x.RegionId });
                    table.ForeignKey(
                        name: "FK_ApplicationRegion_Applications_AppId",
                        column: x => x.AppId,
                        principalTable: "Applications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationRegion_Regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Requests_ApplicationId",
                table: "Requests",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationModule_ModuleId",
                table: "ApplicationModule",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationOwningSite_OwningSiteId",
                table: "ApplicationOwningSite",
                column: "OwningSiteId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationRegion_RegionId",
                table: "ApplicationRegion",
                column: "RegionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Applications_ApplicationId",
                table: "Requests",
                column: "ApplicationId",
                principalTable: "Applications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Applications_ApplicationId",
                table: "Requests");

            migrationBuilder.DropTable(
                name: "ApplicationModule");

            migrationBuilder.DropTable(
                name: "ApplicationOwningSite");

            migrationBuilder.DropTable(
                name: "ApplicationRegion");

            migrationBuilder.DropTable(
                name: "Applications");

            migrationBuilder.DropIndex(
                name: "IX_Requests_ApplicationId",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "Application",
                table: "RequestViews");

            migrationBuilder.DropColumn(
                name: "ApplicationId",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "AppId",
                table: "OwningStreams");

            migrationBuilder.RenameColumn(
                name: "AddRequestsADGroup",
                table: "EnvironmentSettings",
                newName: "ViewRequestsADGroup");
        }
    }
}
