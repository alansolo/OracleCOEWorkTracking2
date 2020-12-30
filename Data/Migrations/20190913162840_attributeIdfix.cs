using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace OracleCOEWorkTracking.Data.Migrations
{
    public partial class attributeIdfix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequestAttributes_Attributes_AttributeId",
                table: "RequestAttributes");

            migrationBuilder.DropColumn(
                name: "AtributeId",
                table: "RequestAttributes");

            migrationBuilder.AlterColumn<int>(
                name: "AttributeId",
                table: "RequestAttributes",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestAttributes_Attributes_AttributeId",
                table: "RequestAttributes",
                column: "AttributeId",
                principalTable: "Attributes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequestAttributes_Attributes_AttributeId",
                table: "RequestAttributes");

            migrationBuilder.AlterColumn<int>(
                name: "AttributeId",
                table: "RequestAttributes",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "AtributeId",
                table: "RequestAttributes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestAttributes_Attributes_AttributeId",
                table: "RequestAttributes",
                column: "AttributeId",
                principalTable: "Attributes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
