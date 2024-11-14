using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pipeline
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var connectionString = "Server=DESKTOP-SV3KE10;Database=PipelineTest;User Id=DESKTOP-SV3KE10\\User;";

            using (var connection = new SqlConnection(connectionString))
            {
                try
                {
                    await connection.OpenAsync();
                    Console.WriteLine("Connection successful!");

                    string query = "SELECT TOP 1 * FROM YOUR_TABLE";
                    using (var command = new SqlCommand(query, connection))
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            Console.WriteLine(reader[0]); // Display the first column of the result
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
                Console.ReadLine();
            }
        }
    }
}
