using System;
using System.Data.SqlClient;

namespace T06.RemoveVillain
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var id = int.Parse(Console.ReadLine());

            using (var connection =
                new SqlConnection(@"Server=DESKTOP-0EAAFNQ\SQLEXPRESS;Integrated Security=true;Database=MinionsDB"))
            {
                connection.Open();

                var queryFindVillainsCount = "SELECT COUNT(*) " +
                    "FROM Villains as v " +
                    "LEFT JOIN MinionsVilains AS mv ON v.Id = mv.VillainId " +
                    "WHERE v.Id = @id " +
                    "GROUP BY v.Id " +
                    "ORDER BY v.Id";
                var commandFindVillainsCount = new SqlCommand(queryFindVillainsCount, connection);
                commandFindVillainsCount.Parameters.AddWithValue("@id", id);

                var queryDeleteMinionsVilains = "DELETE FROM MinionsVilains WHERE VillainId = @id";
                var commandDeleteMinionsVilains = new SqlCommand(queryDeleteMinionsVilains, connection);
                commandDeleteMinionsVilains.Parameters.AddWithValue("@id", id);

                var queryDeleteVillain = "DELETE FROM Villains WHERE Id = @id";
                var commandDeleteVillain = new SqlCommand(queryDeleteVillain, connection);
                commandDeleteVillain.Parameters.AddWithValue("@id", id);

                var queryFindVilain = "SELECT [Name] FROM Villains WHERE Id = @id";
                var commandFindVilain = new SqlCommand(queryFindVilain, connection);
                commandFindVilain.Parameters.AddWithValue("@id", id);

                if (commandFindVillainsCount.ExecuteScalar() is null)
                {
                    Console.WriteLine("No such villain was found.");
                }
                else
                {
                    var deletedMinions = commandDeleteMinionsVilains.ExecuteNonQuery();
                    Console.WriteLine($"{commandFindVilain.ExecuteScalar().ToString()} was deleted.");

                    commandDeleteVillain.ExecuteNonQuery();
                    Console.WriteLine($"{deletedMinions} minions were released.");
                }
            }
        }
    }
}
