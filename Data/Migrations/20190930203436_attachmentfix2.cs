using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace OracleCOEWorkTracking.Data.Migrations
{
    public partial class attachmentfix2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequestAttachment_Requests_RequestId",
                table: "RequestAttachment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RequestAttachment",
                table: "RequestAttachment");

            migrationBuilder.RenameTable(
                name: "RequestAttachment",
                newName: "RequestAttachments");

            migrationBuilder.RenameIndex(
                name: "IX_RequestAttachment_RequestId",
                table: "RequestAttachments",
                newName: "IX_RequestAttachments_RequestId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RequestAttachments",
                table: "RequestAttachments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RequestAttachments_Requests_RequestId",
                table: "RequestAttachments",
                column: "RequestId",
                principalTable: "Requests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequestAttachments_Requests_RequestId",
                table: "RequestAttachments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RequestAttachments",
                table: "RequestAttachments");

            migrationBuilder.RenameTable(
                name: "RequestAttachments",
                newName: "RequestAttachment");

            migrationBuilder.RenameIndex(
                name: "IX_RequestAttachments_RequestId",
                table: "RequestAttachment",
                newName: "IX_RequestAttachment_RequestId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RequestAttachment",
                table: "RequestAttachment",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RequestAttachment_Requests_RequestId",
                table: "RequestAttachment",
                column: "RequestId",
                principalTable: "Requests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
