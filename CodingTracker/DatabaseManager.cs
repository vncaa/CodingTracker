﻿using Microsoft.Data.Sqlite;

namespace CodingTracker
{
    internal class DatabaseManager
    {
        public void CreateTable(string connectionString)
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                using (var tableCmd = connection.CreateCommand())
                {
                    connection.Open();
                    tableCmd.CommandText = @"CREATE TABLE IF NOT EXISTS codingTracker (
                                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                            Date TEXT,
                                            Duration TEXT
                                        )";

                    tableCmd.ExecuteNonQuery();
                }
            }
            Console.WriteLine(".");
        }
        
    }
}
