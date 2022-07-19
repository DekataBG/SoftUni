using System;
using System.Data.SqlClient;

namespace T01.InitialSetup
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var connection =
                new SqlConnection(@"Server=DESKTOP-0EAAFNQ\SQLEXPRESS;Integrated Security=true;Database=MinionsDB"))
            {
                connection.Open();

                var query = System.IO.File.ReadAllText(
                 @"C:\Users\bgsga\OneDrive\Работен плот\Dekata\Programming\SoftUni\DB\ADO-NET-Exercises\01. Initial Setup\query.txt");


                var command = new SqlCommand(query, connection);

                var dataReader = command.ExecuteNonQuery();
            }

        }
    }
}
