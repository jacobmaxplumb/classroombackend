using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace NotebookAppApi.Model
{
    public class Class
    {
        [BsonId]
        public ObjectId InternalId { get; set; }

        public string ClassName { get; set; }

        [BsonDateTimeOptions]
        public DateTime UpdatedOn { get; set; } = DateTime.Now;

        public NoteImage HeaderImage { get; set; }

        public int UserId { get; set; } = 0;
    }
}
