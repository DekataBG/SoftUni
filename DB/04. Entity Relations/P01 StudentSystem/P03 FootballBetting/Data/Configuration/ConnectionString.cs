using System;
using System.Collections.Generic;
using System.Text;

namespace P01_StudentSystem.Data.Configuration
{
    public static class ConnectionString
    {
        private const string DefaultConnectionString = 
            @"Server=DESKTOP-0EAAFNQ\SQLEXPRESS;Database=StudentSystem;Integrated Security=true;";
        public static string GetConnectionString() => DefaultConnectionString;
    }
}
