﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NotebookAppApi.Model;

namespace NotebookAppApi.Interfaces
{
    public interface IReadAssignmentRepository
    {
        Task<IEnumerable<ReadingAssignment>> GetAllReadingAssignments();

        Task<ReadingAssignment> GetReadingAssignment(string id);

        Task AddReadingAssignment(ReadingAssignment readingAssignment);
    }
}
