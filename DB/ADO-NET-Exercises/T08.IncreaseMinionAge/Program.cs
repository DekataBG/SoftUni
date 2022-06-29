using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace T08.IncreaseMinionAge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var ids = Console.ReadLine().Split().Select(int.Parse).ToList();
            var minions = new List<string>();


            using (var connection =
                new SqlConnection(@"Server=DESKTOP-0EAAFNQ\SQLEXPRESS;Integrated Security=true;Database=MinionsDB"))
            {
                connection.Open();

                var querySelect = "SELECT [Name], Age FROM Minions";
                var commandSelect = new SqlCommand(querySelect, connection);

                using (var reader = commandSelect.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        minions.Add(reader[0].ToString());
                    }

                    reader.Close();
                }

                var queryUpdateName = "UPDATE Minions SET [Name] = @name WHERE Id = @id";

                var queryUpdateAge = "UPDATE Minions SET Age = Age + 1 WHERE Id = @id";

                foreach (var id in ids)
                {
                    var commandUpdateName = new SqlCommand(queryUpdateName, connection);
                    commandUpdateName.Parameters.AddWithValue("@name", UpperFirstLetters(minions[id]));
                    commandUpdateName.Parameters.AddWithValue("@id", id);
                    commandUpdateName.ExecuteNonQuery();

                    var commandUpdateAge = new SqlCommand(queryUpdateAge, connection);
                    commandUpdateAge.Parameters.AddWithValue("@id", id);
                    commandUpdateAge.ExecuteNonQuery();
                }

                using (var reader = commandSelect.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader[0]} {reader[1]}");
                    }
                }
            }
        }

        public static string UpperFirstLetters(string name)
        {
            var names = name.Split();

            for (int i = 0; i < names.Length; i++)
            {
                names[i] = names[i][0].ToString().ToUpper() + names[i].Substring(1);
            }

            return String.Join(" ", names);
        }
    }
}
