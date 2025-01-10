using Microsoft.Data.Sqlite;
using UserDataManagement.Database;
using UserDataManagement.Models;

namespace UserDataManagement.Services
{
    public class UserService
    {
        public void AddUser(User user)
        {
            using var connection = DatabaseHelper.GetConnection();
            connection.Open();

            string query = "INSERT INTO Users (Name, Email) VALUES (@Name, @Email)";
            using var command = new SqliteCommand(query, connection);
            command.Parameters.AddWithValue("@Name", user.Name);
            command.Parameters.AddWithValue("@Email", user.Email);
            command.ExecuteNonQuery();
        }

        public void DeleteUser(int userId)
        {
            using var connection = DatabaseHelper.GetConnection();
            connection.Open();

            string query = "DELETE FROM Users WHERE Id = @Id";
            using var command = new SqliteCommand(query, connection);
            command.Parameters.AddWithValue("@Id", userId);
            command.ExecuteNonQuery();
        }
        public List<User> GetAllUsers()
        {
            var users = new List<User>();
            using var connection = DatabaseHelper.GetConnection();
            connection.Open();

            string query = "SELECT * FROM Users";
            using var command = new SqliteCommand(query, connection);
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                users.Add(new User
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Email = reader.GetString(2)
                });
            }

            return users;
        }

    }
}
