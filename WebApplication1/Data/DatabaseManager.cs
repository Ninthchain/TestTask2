using MongoDB.Bson;
using MongoDB.Driver;

namespace WebApplication1.Data;

public class DatabaseManager
{
    private MongoClient client;

    public DatabaseManager()
    {
        client = new MongoClient("mongodb://localhost:27017");
    }
}