using NotebookAppApi.Model;
using System.Collections.Generic;
using System;
                    
namespace NotebookAppApi.Model
{
    public class ReadingAssignmentParams
    {
        public string ClassId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime DueDate { get; set; }
        public IEnumerable<Page> Pages { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
    }
}
