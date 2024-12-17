﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Main.Server.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class version1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "TaskUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "TaskUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "TaskUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "TaskUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "UpdatedBy",
                table: "TaskUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "TaskUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "TaskUsers");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "TaskUsers");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "TaskUsers");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "TaskUsers");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "TaskUsers");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "TaskUsers");
        }
    }
}
