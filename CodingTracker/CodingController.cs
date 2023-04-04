using Microsoft.Data.Sqlite;
using System.Configuration;

namespace CodingTracker
{
    internal class CodingController
    {
        string connectionString = ConfigurationManager.AppSettings.Get("ConnectionString");

        internal void Post(Coding coding)
        {
            using(var connection = new SqliteConnection(connectionString))
            {
                using(var tableCmd = connection.CreateCommand())
                {
                    connection.Open();
                    tableCmd.CommandText = @$"INSERT INTO codingTracker (date, duration)
                                              VALUES ('{coding.Date}', '{coding.Duration}')";
                    tableCmd.ExecuteNonQuery();
                }
            }
        }
        internal void Get()
        {
            List<Coding> tableData = new List<Coding>();
            using(var connection = new SqliteConnection(connectionString))
            {
                using(var tableCmd = connection.CreateCommand())
                {
                    connection.Open();
                    tableCmd.CommandText = $@"SELECT * FROM codingTracker";

                    using(var reader = tableCmd.ExecuteReader())
                    {
                        if(!reader.HasRows)
                            Console.WriteLine("\nNo data found.\n");
                        else
                        {
                            while (reader.Read())
                            {
                                tableData.Add(
                                new Coding
                                {
                                    Id = reader.GetInt32(0),
                                    Date = reader.GetString(1),
                                    Duration = reader.GetString(2)
                                });
                            }
                        }
                    }
                }
            }
            TableVisualisation.ShowTable(tableData);
        }
        internal Coding GetById(int id)
        {
            using(var connection = new SqliteConnection(connectionString))
            {
                using(var tableCmd = connection.CreateCommand())
                {
                    connection.Open();
                    tableCmd.CommandText = $"SELECT * FROM codingTracker WHERE Id = '{id}'";
                    
                    using (var reader = tableCmd.ExecuteReader())
                    {
                        Coding coding = new();
                        if (!reader.HasRows)
                            Console.WriteLine("\nNo data found.");
                        else
                        {
                            reader.Read();
                            coding.Id = reader.GetInt32(0);
                            coding.Date = reader.GetString(1);
                            coding.Duration = reader.GetString(2);
                        }
                        return coding;
                    }
                }
            }

            
        }
        internal void Delete(int id)
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                using(var tableCmd = connection.CreateCommand())
                {
                    connection.Open();
                    tableCmd.CommandText = $"DELETE FROM codingTracker WHERE Id = '{id}'";
                    tableCmd.ExecuteNonQuery();
                }
            }
            Console.WriteLine("\nRecord was deleted.");
        }
        internal void Update(Coding coding)
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                using (var tableCmd = connection.CreateCommand())
                {
                    connection.Open();
                    tableCmd.CommandText = @$"UPDATE codingTracker SET
                                                Date = '{coding.Date}',
                                                Duration = '{coding.Duration}'
                                              WHERE Id = '{coding.Id}'";
                    tableCmd.ExecuteNonQuery();
                }
            }
            Console.WriteLine("\nRecord was updated.");
        }
    }
}