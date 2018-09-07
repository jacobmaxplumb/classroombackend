using Microsoft.Extensions.Options;
using MongoDB.Driver;
using NotebookAppApi.Model;

namespace NotebookAppApi.Data
{
    public class ClassContext
    {
        private readonly IMongoDatabase _database = null;

        public ClassContext(IOptions<Settings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            if (client != null) {
                _database = client.GetDatabase(settings.Value.Database);
            }
        }

        public IMongoCollection<Class> Classes
        {
            get
            {
                return _database.GetCollection<Class>("class");
            }
        }
    }
}
