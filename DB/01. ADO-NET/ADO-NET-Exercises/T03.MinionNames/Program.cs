using System;
using System.Data.SqlClient;

namespace T03.MinionNames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var id = int.Parse(Console.ReadLine());
            var ctr = 1;

            using (var connection = 
                new SqlConnection(@"Server=DESKTOP-0EAAFNQ\SQLEXPRESS;Integrated Security=true;Database=MinionsDB"))
            {
                connection.Open();

                var query = "SELECT v.[Name],  m.[Name], m.Age " +
                    "FROM Villains AS v " +
                    "LEFT JOIN MinionsVilains AS mv ON v.Id = mv.VillainId " +
                    "LEFT JOIN Minions AS m ON m.Id = mv.MinionId " +
                    $"WHERE v.Id = @id";

                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);

                var commandReader = command.ExecuteReader();

                if(!commandReader.Read())
                {
                    Console.WriteLine($"No villain with ID {id} exists in the database.");
                }
                else
                {
                    Console.WriteLine($"Villain: {commandReader[0]}");
                    do
                    {
                        if(commandReader[1] as string is null)
                        {
                            Console.WriteLine("(no minions)");
                        }
                        else
                        {
                            Console.WriteLine($"{ctr}. {commandReader[1]} {commandReader[2]}");
                        }

                        ctr++;
                    } while (commandReader.Read());
                }
            }
        }
    }
}
