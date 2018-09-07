using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace NotebookAppApi.Model
{
    public class ReadingAssignment
    {
        [BsonId]
        public ObjectId InternalId { get; set; }

        public string ClassId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime DueDate { get; set; }
        public IEnumerable<Page> Pages { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
    }
}
