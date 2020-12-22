using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace SchemaChanger.Migrations
{
    public partial class Initial_SchemaChanging_Migration : Migration
    {
        private readonly IDbContextSchema _schema;

        public Initial_SchemaChanging_Migration(IDbContextSchema schema)
        {
            _schema = schema ?? throw new ArgumentNullException(nameof(schema));
        }

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Notes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => x.Id);
                },
                schema: _schema.Schema);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notes",
                schema: _schema.Schema);
        }
    }
}
