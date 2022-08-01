namespace BookShop
{
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System;
    using BookShop.Models;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            DbInitializer.ResetDatabase(db);

            Console.WriteLine(RemoveBooks(db));
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            var stringBuilder = new StringBuilder();

            var books = context.Books.ToList()
                .Where(b => b.AgeRestriction.ToString().ToLower() == command.ToLower())
                .OrderBy(b => b.Title);

            foreach (var book in books)
            {
                stringBuilder.AppendLine(book.Title);
            }

            return stringBuilder.ToString();
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            var stringBuilder = new StringBuilder();

            var books = context.Books.ToList()
                .Where(b => b.EditionType.ToString() == "Gold" && b.Copies < 5_000)
                .OrderBy(b => b.BookId);

            foreach (var book in books)
            {
                stringBuilder.AppendLine(book.Title);
            }

            return stringBuilder.ToString();
        }

        public static string GetBooksByPrice(BookShopContext context)
        {
            var stringBuilder = new StringBuilder();

            var books = context.Books.ToList()
                .Where(b => b.Price > 40)
                .OrderByDescending(b => b.Price);

            foreach (var book in books)
            {
                stringBuilder.AppendLine($"{book.Title} - ${book.Price:F2}");
            }

            return stringBuilder.ToString();
        }

        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var stringBuilder = new StringBuilder();

            var books = context.Books.ToList()
                .Where(b => b.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId);

            foreach (var book in books)
            {
                stringBuilder.AppendLine($"{book.Title}");
            }

            return stringBuilder.ToString();
        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            var stringBuilder = new StringBuilder();

            var categories = input.Split().Select(i => i.ToLower());

            var books = new List<Book>();

            foreach (var category in categories)
            {
                books.AddRange(
                    context.Books
                    .Where(b => b.BookCategories.
                        Select(bk => bk.Category.Name.ToLower()).Contains(category)));
            }

            foreach (var book in books.OrderBy(b => b.Title))
            {
                stringBuilder.AppendLine($"{book.Title}");
            }

            return stringBuilder.ToString().Trim();
        }

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            var stringBuilder = new StringBuilder();

            var books = context.Books
                .Where(b => b.ReleaseDate.Value < DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture))
                .Select(b => new
                {
                    b.Title,
                    b.EditionType,
                    b.Price,
                    b.ReleaseDate.Value
                })
                .OrderByDescending(b => b.Value)
                .ToList();

            foreach (var book in books)
            {
                stringBuilder.AppendLine($"{book.Title} - {book.EditionType.ToString()} - ${book.Price:f2}");
            }

            return stringBuilder.ToString();
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var stringBuilder = new StringBuilder();

            var authors = context.Authors.ToList()
                .Where(a => a.FirstName.EndsWith(input))
                .OrderBy(a => a.FirstName)
                .ThenBy(a => a.LastName);

            foreach (var author in authors)
            {
                stringBuilder.AppendLine($"{author.FirstName} {author.LastName}");
            }

            return stringBuilder.ToString();
        }

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var stringBuilder = new StringBuilder();

            var books = context.Books.ToList()
                .Where(b => b.Title.ToLower().Contains(input.ToLower()))
                .OrderBy(b => b.Title);
            
            foreach (var book in books)
            {
                stringBuilder.AppendLine($"{book.Title}");
            }

            return stringBuilder.ToString();
        }

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var stringBuilder = new StringBuilder();

            var books = context.Books
                .Where(b => b.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .Select(b => new { b.Title, b.Author.FirstName, b.Author.LastName, b.BookId })
                .OrderBy(b => b.BookId);

            foreach (var book in books)
            {
                stringBuilder.AppendLine($"{book.Title} ({book.FirstName} {book.LastName})");
            }

            return stringBuilder.ToString();
        }

        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            var books = context.Books
                .Where(b => b.Title.Length > lengthCheck);

            return books.Count();
        }

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var stringBuilder = new StringBuilder();

            var authors = context.Authors
                .Select(a => new
                {
                    a.FirstName, 
                    a.LastName, 
                    Copies = a.Books.Sum(b => b.Copies)
                })
                .OrderByDescending(a => a.Copies);

            foreach (var author in authors)
            {
                stringBuilder.AppendLine($"{author.FirstName} {author.LastName} - {author.Copies}");
            }

            return stringBuilder.ToString();
        }

        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var stringBuilder = new StringBuilder();

            var categories = context.Categories
                .Select(c => new
                {
                    c.Name,
                    Profit = c.CategoryBooks.Select(cb => cb.Book).Sum(b => b.Price * b.Copies)

                })
                .OrderByDescending(c => c.Profit);
                

            foreach (var category in categories)
            {
                stringBuilder.AppendLine($"{category.Name} ${category.Profit:f2}");
            }

            return stringBuilder.ToString();
        }

        public static string GetMostRecentBooks(BookShopContext context)
        {
            var stringBuilder = new StringBuilder();

            var categories = context.Categories
                .Select(c => new
                {
                    c.Name,
                    Books = c.CategoryBooks.Select(cb => cb.Book).OrderByDescending(b => b.ReleaseDate).Take(3).ToList()

                })
                .OrderBy(c => c.Name)
                .ToList();


            foreach (var category in categories)
            {
                stringBuilder.AppendLine($"--{category.Name}");

                foreach (var book in category.Books)
                {
                    stringBuilder.AppendLine($"{book.Title} ({book.ReleaseDate.Value.Year})");
                }
            }

            return stringBuilder.ToString();
        }

        public static void IncreasePrices(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.ReleaseDate.Value.Year < 2010);

            foreach (var book in books)
            {
                book.Price += 5;
                context.Books.Update(book);
            }

            context.SaveChanges();
        }

        public static int RemoveBooks(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.Copies < 4200);

            var booksCount = books.Count();

            context.Books.RemoveRange(books);
            context.SaveChanges();

            return booksCount;
        }
    }
}
