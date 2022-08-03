using System;
using System.Collections.Generic;
using System.Text;

namespace ProductsShop.Data
{
    public static class Config
    {
        private const string ConnectionString =
            @"Server=DESKTOP-0EAAFNQ\SQLEXPRESS;Database=ProductsShop;Integrated Security=true";

        public static string GetConnectionString() => ConnectionString;
    }
}
