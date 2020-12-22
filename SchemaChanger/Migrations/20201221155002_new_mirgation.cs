using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchemaChanger.Migrations
{
    public partial class new_mirgation : Migration
    {
        private readonly IDbContextSchema _schema;

        public new_mirgation(IDbContextSchema schema)
        {
            _schema = schema ?? throw new ArgumentNullException(nameof(schema));
        }
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Text",
                table: "Notes",
                type: "nvarchar(max)",
                nullable: true,
                schema: _schema.Schema);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Text",
                table: "Notes",
                schema: _schema.Schema);
        }
    }
}
