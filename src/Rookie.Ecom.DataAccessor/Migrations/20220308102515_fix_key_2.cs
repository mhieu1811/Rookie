using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Rookie.Ecom.DataAccessor.Migrations
{
    public partial class fix_key_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItem_Rating_RatingId",
                table: "OrderItem");

            migrationBuilder.DropForeignKey(
                name: "FK_Rating_Order_OrderID",
                table: "Rating");

            migrationBuilder.DropIndex(
                name: "IX_Rating_OrderID",
                table: "Rating");

            migrationBuilder.DropIndex(
                name: "IX_OrderItem_RatingId",
                table: "OrderItem");

            migrationBuilder.DropColumn(
                name: "OrderID",
                table: "Rating");

            migrationBuilder.DropColumn(
                name: "RatingId",
                table: "OrderItem");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "OrderID",
                table: "Rating",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RatingId",
                table: "OrderItem",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rating_OrderID",
                table: "Rating",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_RatingId",
                table: "OrderItem",
                column: "RatingId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItem_Rating_RatingId",
                table: "OrderItem",
                column: "RatingId",
                principalTable: "Rating",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rating_Order_OrderID",
                table: "Rating",
                column: "OrderID",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
