using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace T07.PrintAllMinionNames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var minions = new List<string>();
            var ctr = 1;

            using (var connection = 
                new SqlConnection(@"Server=DESKTOP-0EAAFNQ\SQLEXPRESS;Integrated Security=true;Database=MinionsDB"))
            {
                connection.Open();

                var query = "SELECT [Name] FROM Minions";
                
                var command = new SqlCommand(query, connection);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        minions.Add(reader[0].ToString());
                    }
                }

                while (minions.Count > 0)
                {
                    if (ctr % 2 == 1)
                    {
                        Console.WriteLine(minions[0]);
                        minions.RemoveAt(0);
                    }
                    else
                    {
                        Console.WriteLine(minions[minions.Count - 1]);
                        minions.RemoveAt(minions.Count - 1);
                    }
                    ctr++;
                }
            }
        }
    }
}
