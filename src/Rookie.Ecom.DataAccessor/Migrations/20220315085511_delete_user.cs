using Microsoft.EntityFrameworkCore.Migrations;

namespace Rookie.Ecom.DataAccessor.Migrations
{
    public partial class delete_user : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserDetail_Role_RoleID",
                table: "UserDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_UserDetail_User_UserID",
                table: "UserDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserDetail",
                table: "UserDetail");

            migrationBuilder.RenameTable(
                name: "UserDetail",
                newName: "UserDetails");

            migrationBuilder.RenameIndex(
                name: "IX_UserDetail_UserID",
                table: "UserDetails",
                newName: "IX_UserDetails_UserID");

            migrationBuilder.RenameIndex(
                name: "IX_UserDetail_RoleID",
                table: "UserDetails",
                newName: "IX_UserDetails_RoleID");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Rating",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Rating",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserDetails",
                table: "UserDetails",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserDetails_Role_RoleID",
                table: "UserDetails",
                column: "RoleID",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserDetails_User_UserID",
                table: "UserDetails",
                column: "UserID",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserDetails_Role_RoleID",
                table: "UserDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_UserDetails_User_UserID",
                table: "UserDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserDetails",
                table: "UserDetails");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Rating");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Rating");

            migrationBuilder.RenameTable(
                name: "UserDetails",
                newName: "UserDetail");

            migrationBuilder.RenameIndex(
                name: "IX_UserDetails_UserID",
                table: "UserDetail",
                newName: "IX_UserDetail_UserID");

            migrationBuilder.RenameIndex(
                name: "IX_UserDetails_RoleID",
                table: "UserDetail",
                newName: "IX_UserDetail_RoleID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserDetail",
                table: "UserDetail",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserDetail_Role_RoleID",
                table: "UserDetail",
                column: "RoleID",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserDetail_User_UserID",
                table: "UserDetail",
                column: "UserID",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
