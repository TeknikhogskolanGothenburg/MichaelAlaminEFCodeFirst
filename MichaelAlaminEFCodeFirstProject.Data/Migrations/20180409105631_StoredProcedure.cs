using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MichaelAlaminEFCodeFirstProject.Data.Migrations
{
    public partial class StoredProcedure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
               @"CREATE PROCEDURE FilterBooksByName
                @namepart varchar(50)
                AS
                SELECT * FROM Books WHERE Name LIKE '%'+@namepart+'%'");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE FilterBooksByNamePart");
        }
    }
}
