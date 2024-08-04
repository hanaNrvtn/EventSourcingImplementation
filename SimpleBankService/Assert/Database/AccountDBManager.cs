using System;
using ConsoleApplication1.Exception;
using ConsoleApplication1.Model.Account;
using MySql.Data.MySqlClient;

namespace EventSourcingImplementation.Assert.Database
{
    public class AccountDbManager
    {
        
        private readonly ConsoleApplication1.Assert.Database.Database _database;

        public AccountDbManager()
        {
            _database = new ConsoleApplication1.Assert.Database.Database("localhost", "testdb", "root", "");
        }

        public void Add(string id, int initBalance, DateTime createAt, DateTime updateAt)
        {
            _database.OpenConnection();
            var query = "INSERT INTO accounts (id, balance, createAt, updateAt) VALUES (@id, @balance, @createAt, @updateAt);";
            var cmd = new MySqlCommand(query, _database.GetConnection());
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@balance", initBalance);
            cmd.Parameters.AddWithValue("@createAt", createAt);
            cmd.Parameters.AddWithValue("@updateAt", updateAt);
            var result = cmd.ExecuteNonQuery();
            
            _database.CloseConnection();
            
            if (result <= 0)
                throw new AddAccountFailedException();
        }

        public Account Get(string id)
        {
            _database.OpenConnection();
            
            var query = "SELECT * FROM accounts WHERE id = @id;";
            var cmd = new MySqlCommand(query, _database.GetConnection());
            cmd.Parameters.AddWithValue("@id", id);;
            var reader = cmd.ExecuteReader();
            Account account = null;
            while (reader.Read())
                account = new Account((string)reader["id"], (double)reader["balance"], (DateTime)reader["createAt"], (DateTime)reader["updateAt"]);

            _database.CloseConnection();
            
            if (account is null)
                throw new AccountNotFoundException();
            return account;
        }

        public void Update(string id, double newBalance)
        {
            _database.OpenConnection();
            
            var query = "UPDATE accounts SET balance = @balance WHERE id = @id;";
            var cmd = new MySqlCommand(query, _database.GetConnection());
            cmd.Parameters.AddWithValue("@balance", newBalance);
            cmd.Parameters.AddWithValue("@id", id);
            
            var result = cmd.ExecuteNonQuery();
            
            _database.CloseConnection();
            
            if (result <= 0) 
                throw new UpdateAccountFailedException();
        }
    }
}