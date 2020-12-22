using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchemaChanger.Migrations
{
    public partial class added_date : Migration
    {
        private readonly IDbContextSchema _schema;

        public added_date(IDbContextSchema schema)
        {
            _schema = schema ?? throw new ArgumentNullException(nameof(schema));
        }

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Notes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                schema: _schema.Schema);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Notes",
                schema:_schema.Schema);
        }
    }
}
