using Microsoft.Extensions.Options;
using MongoDB.Driver;
using NotebookAppApi.Model;

namespace NotebookAppApi.Data
{
    public class ReadAssignmentContext
    {
        private readonly IMongoDatabase _database = null;

        public ReadAssignmentContext(IOptions<Settings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            if (client != null)
            {
                _database = client.GetDatabase(settings.Value.Database);
            }
        }

        public IMongoCollection<ReadingAssignment> ReadingAssignments
        {
            get
            {
                return _database.GetCollection<ReadingAssignment>("reading");
            }
        }
    }
}
