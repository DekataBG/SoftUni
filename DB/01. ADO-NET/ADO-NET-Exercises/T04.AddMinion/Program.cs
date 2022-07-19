using System;
using System.Data.SqlClient;

namespace T04.AddMinion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var minionInfo = Console.ReadLine().Split();
            var villainInfo = Console.ReadLine().Split();

            using (var connection =
                new SqlConnection(@"Server=DESKTOP-0EAAFNQ\SQLEXPRESS;Integrated Security=true;MultipleActiveResultSets=true;Database=MinionsDB"))
            {
                connection.Open();

                //checks if there exists a town
                var querySearchTown = "SELECT * FROM Towns WHERE [Name] = @TownName";
                var commandSearchTown = new SqlCommand(querySearchTown, connection);
                commandSearchTown.Parameters.AddWithValue("@TownName", minionInfo[3]);

                //inserts the town
                var queryInsertTown = "INSERT INTO Towns([Name]) VALUES (@TownName)";
                var commandInsertTown = new SqlCommand(queryInsertTown, connection);
                commandInsertTown.Parameters.AddWithValue("@TownName", minionInfo[3]);

                //checks if there exists a villain
                var querySearchVillain = "SELECT * FROM Villains WHERE [Name] = @VillainName";
                var commandSearchVillain = new SqlCommand(querySearchVillain, connection);
                commandSearchVillain.Parameters.AddWithValue("@VillainName", villainInfo[1]);

                //inserts the villain
                var queryInsertVillain = "INSERT INTO Villains([Name], EvilnessFactorId) VALUES (@VillainName, 4)";
                var commandInsertVillain = new SqlCommand(queryInsertVillain, connection);
                commandInsertVillain.Parameters.AddWithValue("@VillainName", villainInfo[1]);

                //searchesTownId
                var querySearchTownId = "SELECT Id FROM Towns WHERE [Name] = @TownName";
                var commandSearchTownId = new SqlCommand(querySearchTownId, connection);
                commandSearchTownId.Parameters.AddWithValue("@TownName", minionInfo[3]);

                //searchesMinionId
                var querySearchMinionId = "SELECT Id FROM Minions WHERE [Name] = @MinionName";
                var commandSearchMinionId = new SqlCommand(querySearchMinionId, connection);
                commandSearchMinionId.Parameters.AddWithValue("@MinionName", minionInfo[1]);

                //searchesVillainId
                var querySearchVillainId = "SELECT Id FROM Villains WHERE [Name] = @VillainName";
                var commandSearchVillainId = new SqlCommand(querySearchVillainId, connection);
                commandSearchVillainId.Parameters.AddWithValue("@VillainName", villainInfo[1]);

                //inserts the minion
                var queryInsertMinion = "INSERT INTO Minions([Name], Age, TownId) VALUES (@MinionName, @MinionAge, @MinionTownId)";
                var commandInsertMinion = new SqlCommand(queryInsertMinion, connection);
                commandInsertMinion.Parameters.AddWithValue("@MinionName", minionInfo[1]);
                commandInsertMinion.Parameters.AddWithValue("@MinionAge", int.Parse(minionInfo[2]));

                //inserts the minion/villain
                var queryInsertMinionVillain = "INSERT INTO MinionsVilains(MinionId, VillainId) VALUES (@MinionId, @VillainId)";
                var commandInsertMinionVillain = new SqlCommand(queryInsertMinionVillain, connection);

                using (var readerTowns = commandSearchTown.ExecuteReader())
                {
                    if (!readerTowns.HasRows)
                    {
                        commandInsertTown.ExecuteNonQuery();
                        Console.WriteLine($"Town {minionInfo[3]} was added to the database.");
                    }
                    commandInsertMinion.Parameters.AddWithValue("@MinionTownId", int.Parse(commandSearchTownId.ExecuteScalar().ToString()));

                    using (var readerVillains = commandSearchVillain.ExecuteReader())
                    {
                        if (!readerVillains.HasRows)
                        {
                            commandInsertVillain.ExecuteNonQuery();
                            Console.WriteLine($"Villain {villainInfo[1]} was added to the database.");
                        }
                        commandInsertMinionVillain.Parameters.AddWithValue("@VillainId", int.Parse(commandSearchVillainId.ExecuteScalar().ToString()));

                        commandInsertMinion.ExecuteNonQuery();
                        commandInsertMinionVillain.Parameters.AddWithValue("@MinionId", int.Parse(commandSearchMinionId.ExecuteScalar().ToString()));

                        commandInsertMinionVillain.ExecuteNonQuery();

                        Console.WriteLine($"Successfully added {minionInfo[1]} to be minion of {villainInfo[1]}.");

                    }

                }
            }
        }
    }
}
