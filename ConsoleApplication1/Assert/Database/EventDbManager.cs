using ConsoleApplication1.Exception;
using MySql.Data.MySqlClient;

namespace ConsoleApplication1.Assert.Database
{
    public class EventDbManager
    {
        private readonly Database _database;

        public EventDbManager()
        {
            _database = new Database("localhost", "testdb", "root", "");
            _database.OpenConnection();
        }

        public void AddEvent(string id, string accountId, string type, string properties)
        {
            var query = "INSERT INTO events (Id, AccountId, EventType, EventProperties) VALUES (@Id, @AccountId, @EventType, @EventProperties);";
            var cmd = new MySqlCommand(query, _database.GetConnection());
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.Parameters.AddWithValue("@AccountId", accountId);
            cmd.Parameters.AddWithValue("@Balance", accountId);
            cmd.Parameters.AddWithValue("@EventType", type);
            cmd.Parameters.AddWithValue("@EventProperties", properties);
            var result = cmd.ExecuteNonQuery();
            if (result <= 0)
                throw new AddEventFailedException();
        }
    }
}