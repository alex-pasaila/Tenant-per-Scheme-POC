using System;

namespace SchemaChanger
{
    public class Note
    {
        public Note(string text)
        {
            Id = Guid.NewGuid();
            Text = text;
            Date = DateTime.Now;

        }
        public Guid Id { get; set; }
        public string Text { get; set; }

        public DateTime Date { get; set; }
    }
}