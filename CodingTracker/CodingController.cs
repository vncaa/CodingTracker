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
    }
}