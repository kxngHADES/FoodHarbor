using System;
using System.Data.OleDb;

namespace FoodHarbor
{
    public class Logs
    {
        private readonly string _connectionString;

        public Logs(string connectionString)
        {
            _connectionString = connectionString; // Assign the parameter to the class-level variable
        }

        public void LogEvent(string eventType, string eventDescription)
        {
            using (OleDbConnection connection = new OleDbConnection(_connectionString))
            {
                string query = "INSERT INTO Logs (Timestamp, EventType, EventDescription) VALUES (@Timestamp, @EventType, @EventDescription)";

                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Timestamp", DateTime.Now);
                    command.Parameters.AddWithValue("@EventType", eventType);
                    command.Parameters.AddWithValue("@EventDescription", eventDescription);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
