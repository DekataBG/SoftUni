using ProductShop.Data;
using ProductShop.Dtos.Export;
using ProductShop.Dtos.Import;
using ProductShop.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var context = new ProductShopContext();

            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            //Console.WriteLine(ImportUsers(context, File.ReadAllText("../../../Datasets/users.xml")));
            //Console.WriteLine(ImportProducts(context, File.ReadAllText("../../../Datasets/products.xml")));
            //Console.WriteLine(ImportCategories(context, File.ReadAllText("../../../Datasets/categories.xml")));
            //Console.WriteLine(ImportCategoryProducts(context, File.ReadAllText("../../../Datasets/categories-products.xml")));

            //Console.WriteLine(GetProductsInRange(context));
            //Console.WriteLine(GetSoldProducts(context));
            //Console.WriteLine(GetCategoriesByProductsCount(context));
            Console.WriteLine(GetUsersWithProducts(context));
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
            var stringBuilder = new StringBuilder();

            var serializer = new XmlSerializer(typeof(ProductExportDto[]), new XmlRootAttribute("Products"));

            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(String.Empty, String.Empty);

            using var stringWriter = new StringWriter(stringBuilder);

            var products = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Select(p => new ProductExportDto
                {
                    Name = p.Name,
                    Price = p.Price,
                    BuyerName = p.Buyer.FirstName + " " + p.Buyer.LastName
                })
                .Take(10)
                .ToArray();
           
            serializer.Serialize(stringWriter, products, namespaces);

            return stringBuilder.ToString();
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var stringBuilder = new StringBuilder();

            var xmlSerializer = new XmlSerializer(typeof(UserExportDto[]), new XmlRootAttribute("Users"));

            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(String.Empty, String.Empty);

            using var stringWriter = new StringWriter(stringBuilder);

            var users = context.Users
                .Where(u => u.ProductsSold.Count() > 0)
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Select(u => new UserExportDto
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    SoldProducts = u.ProductsSold
                        .Select(ps => new ProductExportDto
                        {
                                Name = ps.Name,
                                Price = ps.Price
                        })
                        .ToArray()
                })
                .Take(5)
                .ToArray();

            xmlSerializer.Serialize(stringWriter, users, namespaces);

            return stringBuilder.ToString();
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var stringBuilder = new StringBuilder();

            var xmlSerializer = new XmlSerializer(typeof(CategoryExportDto[]), new XmlRootAttribute("Categories"));

            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(String.Empty, String.Empty);

            using var stringWriter = new StringWriter(stringBuilder);

            var categories = context.Categories
                .Select(c => new CategoryExportDto
                {
                    Name = c.Name,
                    Count = c.CategoryProducts.Count(),
                    AveragePrice = c.CategoryProducts.Average(cp => cp.Product.Price),
                    TotalRevenue = c.CategoryProducts.Sum(cp => cp.Product.Price)
                })
                .OrderByDescending(c => c.Count)
                .ThenBy(c => c.TotalRevenue)
                .ToArray();

            xmlSerializer.Serialize(stringWriter, categories, namespaces);

            return stringBuilder.ToString();
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var stringBuilder = new StringBuilder();

            var xmlSerializer = new XmlSerializer(typeof(UsersExportDto), new XmlRootAttribute("Users"));

            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            //namespaces.Add(String.Empty, String.Empty);

            var settings = new XmlWriterSettings
            {
                OmitXmlDeclaration = true,
                Indent = true
            };

            using var stringWriter = new StringWriter(stringBuilder);
            using var xmlWriter = XmlWriter.Create(stringBuilder, settings);

            var users = new UsersExportDto
            {
                Count = context.Users.Count(u => u.ProductsSold.Count > 0),
                Users = context.Users
                    .Where(u => u.ProductsSold.Count > 0)
                    .OrderByDescending(u => u.ProductsSold.Count)
                    .ToArray()
                    .Select(u => new UserExportDto
                    {
                        FirstName = u.FirstName,
                        LastName = u.LastName, 
                        Age = u.Age,
                        SoldProductsWithCount = new ProductsExportDto
                        {
                            Count = u.ProductsSold.Count,
                            Products = u.ProductsSold
                                .Select(ps => new ProductExportDto
                                {
                                    Name = ps.Name,
                                    Price = ps.Price
                                })
                                .OrderByDescending(p => p.Price)
                                .ToArray()
                        }
                    })
                    .Take(10)
                    .ToArray()
            };

            xmlSerializer.Serialize(xmlWriter, users, namespaces);

            return stringBuilder.ToString();
        }
    }
}