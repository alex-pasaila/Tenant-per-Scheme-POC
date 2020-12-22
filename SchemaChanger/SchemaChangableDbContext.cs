using Microsoft.EntityFrameworkCore;

namespace SchemaChanger

{
    public class SchemaChangeDbContext : DbContext, IDbContextSchema
    {
        public string? Schema { get; }

        public DbSet<Note> Notes { get; set; }

        public SchemaChangeDbContext() : base(new DbContextOptionsBuilder()
                .UseSqlServer("Server=(LocalDb)\\MSSqlLocalDB;Database=SchemaChanger;Trusted_Connection=True;MultipleActiveResultSets=true")
                .Options)
        {
        }

        public SchemaChangeDbContext(
            DbContextOptions<SchemaChangeDbContext> options,
            IDbContextSchema? schema = null)
            : base(options)
        {
            Schema = schema?.Schema;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new NoteEntityConfiguration(Schema));
        }
    }
}
