using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CarShowRoom.Migrations
{
    public partial class ChangeOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Employee_EmployeeId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_PayMethod_PayMethodId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_EmployeeId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_PayMethodId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "PayMethodId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Order");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "Order",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PayMethodId",
                table: "Order",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "Order",
                type: "decimal(15,2)",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Order_EmployeeId",
                table: "Order",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_PayMethodId",
                table: "Order",
                column: "PayMethodId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Employee_EmployeeId",
                table: "Order",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_PayMethod_PayMethodId",
                table: "Order",
                column: "PayMethodId",
                principalTable: "PayMethod",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
