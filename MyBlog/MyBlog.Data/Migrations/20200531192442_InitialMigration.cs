using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyBlog.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BlogsDB",
                columns: table => new
                {
                    BlogID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ImageURL = table.Column<string>(nullable: false),
                    Section = table.Column<string>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    BlogNote = table.Column<string>(nullable: false),
                    FullDescription = table.Column<string>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: true),
                    Clicked = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogsDB", x => x.BlogID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogsDB");
        }
    }
}
