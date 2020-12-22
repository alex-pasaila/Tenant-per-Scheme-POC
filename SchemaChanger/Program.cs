using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchemaChanger
{
    class Program
    {
        static void Main(string[] args)
        {

            using (var ctx = GetSchemaChangeDbContext("db1"))
            {
                ctx.Database.Migrate();
            }

            using (var ctx = GetSchemaChangeDbContext("db2"))
            {
                ctx.Database.Migrate();
            }
            
            using (var ctx = GetSchemaChangeDbContext("db1"))
            {
                var notes = new NotesQueries(ctx);

                notes.AddNote($"db1 note {DateTime.Now}");
            }

            using (var ctx = GetSchemaChangeDbContext("db2"))
            {
                var notes = new NotesQueries(ctx);

                notes.AddNote($"db2 note {DateTime.Now}");
            }

            using (var ctx = GetSchemaChangeDbContext("db1"))
            {
                var notes = new NotesQueries(ctx);

                notes.FetchNotes();
            }

            using (var ctx = GetSchemaChangeDbContext("db2"))
            {
                var notes = new NotesQueries(ctx);

                notes.FetchNotes();
            }

            Console.WriteLine("Ended");
            Console.Read();
        }

        public static SchemaChangeDbContext GetSchemaChangeDbContext(string? schema = null)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SchemaChangeDbContext>()
                .UseSqlServer("Server=(LocalDb)\\MSSqlLocalDB;Database=SchemaChanger;Trusted_Connection=True;MultipleActiveResultSets=true"
                    , b => b.MigrationsHistoryTable("__EFMigrationsHistory", schema)
                )
                .ReplaceService<IModelCacheKeyFactory, SchemaChangeModelCacheKeyFactory>()
                .ReplaceService<IMigrationsAssembly, SchemaChangeMigrationAssembly>();

            return new SchemaChangeDbContext(optionsBuilder.Options, schema == null ? null : new DbContextSchema(schema));
        }

    }
}
