using ProductShop.Data;
using ProductShop.Dtos.Import;
using ProductShop.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var context = new ProductShopContext();

            //Console.WriteLine(ImportUsers(context, File.ReadAllText("../../../Datasets/users.xml")));
            //Console.WriteLine(ImportProducts(context, File.ReadAllText("../../../Datasets/products.xml")));
            //Console.WriteLine(ImportCategories(context, File.ReadAllText("../../../Datasets/categories.xml")));
            //Console.WriteLine(ImportCategoryProducts(context, File.ReadAllText("../../../Datasets/categories-products.xml")));
        }

        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(UserImportDto[]), new XmlRootAttribute("Users"));

            var usersDto = xmlSerializer.Deserialize(new StringReader(inputXml)) as UserImportDto[];

            var users = new List<User>();

            foreach (var userDto in usersDto)
            {
                var user = new User
                {
                    FirstName = userDto.FirstName,
                    LastName = userDto.LastName,
                    Age = userDto.Age
                };

                users.Add(user);
            }

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count()}";
        }

        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(ProductImportDto[]), new XmlRootAttribute("Products"));

            var productsDto = xmlSerializer.Deserialize(new StringReader(inputXml)) as ProductImportDto[];

            var products = new List<Product>();

            foreach (var productDto in productsDto)
            {
                var product = new Product
                {
                    Name = productDto.Name,
                    Price = productDto.Price,
                    SellerId = productDto.SellerId,
                    BuyerId = productDto.BuyerId
                };

                products.Add(product);

            }

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count}";
        }

        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(CategoryImportDto[]), new XmlRootAttribute("Categories"));

            var categoriesDto = xmlSerializer.Deserialize(new StringReader(inputXml)) as CategoryImportDto[];

            var categories = new List<Category>();

            foreach (var categoryDto in categoriesDto)
            {
                if (categoryDto.Name != null)
                {
                    var category = new Category
                    {
                        Name = categoryDto.Name
                    };

                    categories.Add(category);
                }
            }

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(CategoryProductImportDto[]), new XmlRootAttribute("CategoryProducts"));

            var categoryProductsDto = xmlSerializer.Deserialize(new StringReader(inputXml)) as CategoryProductImportDto[];

            var categoryProducts = new List<CategoryProduct>();

            foreach (var categoryProductDto in categoryProductsDto)
            {
                if (context.Categories.Any(c => c.Id == categoryProductDto.CategoryId))
                {
                    if (context.Products.Any(p => p.Id == categoryProductDto.ProductId))
                    {
                        var categoryProduct = new CategoryProduct
                        {
                            CategoryId = categoryProductDto.CategoryId,
                            ProductId = categoryProductDto.ProductId
                        };

                        categoryProducts.Add(categoryProduct);
                    }
                }
            }

            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Count}";
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