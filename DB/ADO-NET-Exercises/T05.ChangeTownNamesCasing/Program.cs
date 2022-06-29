using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace T05.ChangeTownNamesCasing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var country = Console.ReadLine();

            using (var connection = 
                new SqlConnection(@"Server=DESKTOP-0EAAFNQ\SQLEXPRESS;Integrated Security=true;Database=MinionsDB"))
            {
                connection.Open();

                var queryUpdate = "UPDATE Towns " +
                    "SET [Name] = UPPER([Name]) " +
                    "WHERE CountryCode IN( " +
                    "SELECT Id FROM Countries WHERE [Name] = @CountryName)";

                var commandUpdate = new SqlCommand(queryUpdate, connection);
                commandUpdate.Parameters.AddWithValue("CountryName", country);

                var querySelect = "SELECT [Name] " +
                    "FROM Towns " +
                    "WHERE CountryCode IN( " +
                    "SELECT Id FROM Countries WHERE [Name] = @CountryName)";

                var commandSelect = new SqlCommand(querySelect, connection);
                commandSelect.Parameters.AddWithValue("CountryName", country);

                var affected = commandUpdate.ExecuteNonQuery();

                if (affected == 0)
                {
                    Console.WriteLine("No town names were affected.");
                }
                else
                {
                    Console.WriteLine($"{affected} town names were affected.");

                    var towns = new List<string>();

                    using (var reader = commandSelect.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            towns.Add(reader[0].ToString());
                        }
                    }

                    Console.WriteLine($"[{String.Join(", ", towns)}]");
                }
            }
        }
    }
}
