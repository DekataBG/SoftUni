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

            Console.WriteLine(GetBooksReleasedBefore(db, Console.ReadLine()));
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

            var books = context.Books.ToList()
                .Where(b => b)
                .OrderBy(b => b);

            foreach (var book in books)
            {
                stringBuilder.AppendLine($"{}");
            }

            return stringBuilder.ToString();
        }
    }
}
