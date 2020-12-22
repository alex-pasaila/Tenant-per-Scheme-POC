using System;
using System.Linq;

namespace SchemaChanger
{
    public class NotesQueries
    {
        private readonly SchemaChangeDbContext _ctx;

        public NotesQueries(SchemaChangeDbContext ctx)
        {
            _ctx = ctx ?? throw new ArgumentNullException(nameof(ctx));
        }

        public void AddNote(string note)
        {
            _ctx.Notes.Add(new Note(note));
            _ctx.SaveChanges();
        }

        public void FetchNotes()
        {
            _ctx.Notes.ToList().ForEach(note => Console.WriteLine($"NoteId: {note.Id}, Note Text: {note.Text}, Note Date: {note.Date};"));
        }
    }
}