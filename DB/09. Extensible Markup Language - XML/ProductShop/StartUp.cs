using ProductShop.Data;
using System;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var context = new ProductShopContext();

            Console.WriteLine(GetProductsInRange(context));
        }

        public static string GetProductsInRange(ProductShopContext context)
        {


            return "Successfully imported {Users.Count}";
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            throw new NotImplementedException();
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            throw new NotImplementedException();
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            throw new NotImplementedException();
        }


    }
}