using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Domain.Migrations
{
    public partial class InitFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ServiceProvider",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Star = table.Column<float>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(maxLength: 200, nullable: true),
                    Image = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceProvider", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SysUser",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Account = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysUser", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "EvaluationOrder",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Star = table.Column<float>(nullable: false),
                    Content = table.Column<string>(maxLength: 200, nullable: true),
                    EvaluationStart = table.Column<DateTime>(nullable: false),
                    CreatorID = table.Column<int>(nullable: false),
                    ServiceProviderID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvaluationOrder", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EvaluationOrder_SysUser_CreatorID",
                        column: x => x.CreatorID,
                        principalTable: "SysUser",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EvaluationOrder_ServiceProvider_ServiceProviderID",
                        column: x => x.ServiceProviderID,
                        principalTable: "ServiceProvider",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reply",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ReplyStart = table.Column<DateTime>(nullable: true),
                    Writer = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    ReplierID = table.Column<int>(nullable: false),
                    ParentReplyID = table.Column<int>(nullable: false),
                    EvaluationOrderID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reply", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Reply_EvaluationOrder_EvaluationOrderID",
                        column: x => x.EvaluationOrderID,
                        principalTable: "EvaluationOrder",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reply_SysUser_ReplierID",
                        column: x => x.ReplierID,
                        principalTable: "SysUser",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EvaluationOrder_CreatorID",
                table: "EvaluationOrder",
                column: "CreatorID");

            migrationBuilder.CreateIndex(
                name: "IX_EvaluationOrder_ServiceProviderID",
                table: "EvaluationOrder",
                column: "ServiceProviderID");

            migrationBuilder.CreateIndex(
                name: "IX_Reply_EvaluationOrderID",
                table: "Reply",
                column: "EvaluationOrderID");

            migrationBuilder.CreateIndex(
                name: "IX_Reply_ReplierID",
                table: "Reply",
                column: "ReplierID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reply");

            migrationBuilder.DropTable(
                name: "EvaluationOrder");

            migrationBuilder.DropTable(
                name: "SysUser");

            migrationBuilder.DropTable(
                name: "ServiceProvider");
        }
    }
}
