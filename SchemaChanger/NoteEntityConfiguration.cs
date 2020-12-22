using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SchemaChanger
{
    public class NoteEntityConfiguration : IEntityTypeConfiguration<Note>
    {
        private readonly string? _schema;

        public NoteEntityConfiguration(string? schema)
        {
            _schema = schema;
        }

        /// <inheritdoc />
        public void Configure(EntityTypeBuilder<Note> builder)
        {
            if (!String.IsNullOrWhiteSpace(_schema))
                builder.ToTable(nameof(SchemaChangeDbContext.Notes), _schema);

            builder.HasKey(product => product.Id);
        }
    }
}