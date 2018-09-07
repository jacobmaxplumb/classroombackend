using System;
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
    public class ClassRepository : IClassRepository
    {
        private readonly ClassContext _context = null;

        public ClassRepository(IOptions<Settings> settings)
        {
            _context = new ClassContext(settings);
        }

      
        public async Task<IEnumerable<Class>> GetAllClasses()
        {
            return await _context.Classes.Find(_ => true).ToListAsync();
        }

        public async Task<Class> GetClass(string id)
        {
            ObjectId internalId = GetInternalId(id);
            return await _context.Classes.Find(c => c.InternalId == internalId).FirstOrDefaultAsync();
        }

        public async Task AddClass(Class item)
        {
            await _context.Classes.InsertOneAsync(item);
        }

        private ObjectId GetInternalId(string id)
        {
            if (!ObjectId.TryParse(id, out ObjectId internalId))
                internalId = ObjectId.Empty;

            return internalId;
        }

    }
}
