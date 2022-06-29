using System;
using System.Data.SqlClient;

namespace T02.VillainNames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var connection =
                new SqlConnection(@"Server=DESKTOP-0EAAFNQ\SQLEXPRESS;Integrated Security=true;Database=MinionsDB"))
            {
                connection.Open();

                var query = "SELECT [Name], COUNT(VillainId) " +  
                            "FROM Villains " +
                            "INNER JOIN MinionsVilains " + 
                            "ON Id = VillainId " +
                            "GROUP BY[Name] " + 
                            "HAVING COUNT(VillainId) > 3" + 
                            "ORDER BY 2";

                var command = new SqlCommand(query, connection);

                var dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    Console.WriteLine($"{dataReader[0]} - {dataReader[1]}");
                }
            }
        }
    }
}
