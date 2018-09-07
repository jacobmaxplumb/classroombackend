using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NotebookAppApi.Interfaces;
using NotebookAppApi.Model;
using NotebookAppApi.Infrastructure;
using System;
using System.Collections.Generic;

namespace NotebookAppApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ReadingAssignmentsController
    {
        private readonly IReadAssignmentRepository _readingAssingmentRepository;
        public ReadingAssignmentsController(IReadAssignmentRepository readingAssignmentRepository)
        {
            _readingAssingmentRepository = readingAssignmentRepository;
        }

        [NoCache]
        [HttpGet]
        public Task<IEnumerable<ReadingAssignment>> Get()
        {
            return _readingAssingmentRepository.GetAllReadingAssignments();
        }

        [HttpPost]
        public void Post([FromBody] ReadingAssignmentParams newAssignment)
        {
            _readingAssingmentRepository.AddReadingAssignment(new ReadingAssignment
            {
                ClassId = newAssignment.ClassId,
                StartDate = newAssignment.StartDate,
                DueDate = newAssignment.DueDate,
                Description = newAssignment.Description,
                Title = newAssignment.Title,
                Pages = newAssignment.Pages
            });
        }

    }
}
