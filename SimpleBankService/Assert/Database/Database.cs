using MySql.Data.MySqlClient;

namespace ConsoleApplication1.Assert.Database
{
    public class Database
    {
        private readonly MySqlConnection _connection;

        public Database(string server, string database, string username, string password)
        {
            var connectionString = $"Server={server}; database={database}; UID={username}; password={password}";
            _connection = new MySqlConnection(connectionString);
        }

        public void OpenConnection()
        {
            if (_connection.State == System.Data.ConnectionState.Closed)
                _connection.Open();
        }

        public void CloseConnection()
        {
            if (_connection.State == System.Data.ConnectionState.Open)
                _connection.Close();
        }

        public MySqlConnection GetConnection()
        {
            return _connection;
        }
    }
}