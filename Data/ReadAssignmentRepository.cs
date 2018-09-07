using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

using NotebookAppApi.Interfaces;
using NotebookAppApi.Model;
using MongoDB.Bson;
using MongoDB.Driver.Linq;

namespace NotebookAppApi.Data
{
    public class ReadAssignmentRepository : IReadAssignmentRepository
    {
        private readonly ReadAssignmentContext _context = null;

        public ReadAssignmentRepository(IOptions<Settings> settings)
        {
            _context = new ReadAssignmentContext(settings);
        }

        public async Task<IEnumerable<ReadingAssignment>> GetAllReadingAssignments()
        {
            return await _context.ReadingAssignments.Find(_ => true).ToListAsync();
        }

        public async Task<ReadingAssignment> GetReadingAssignment(string id)
        {
            ObjectId internalId = GetInternalId(id);
            return await _context.ReadingAssignments.Find(r => r.InternalId == internalId).FirstOrDefaultAsync();
        }

        public async Task AddReadingAssignment(ReadingAssignment assignment)
        {
            await _context.ReadingAssignments.InsertOneAsync(assignment);
        }

        private ObjectId GetInternalId(string id)
        {
            if (!ObjectId.TryParse(id, out ObjectId internalId))
                internalId = ObjectId.Empty;

            return internalId;
        }
    }
}
