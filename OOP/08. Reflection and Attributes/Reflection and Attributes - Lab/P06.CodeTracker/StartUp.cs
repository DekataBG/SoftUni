using System;
using System.Runtime.InteropServices;

namespace AuthorProblem
{
    [Author("Dekata")]
    public class StartUp
    {

        [Author("Bill")]
        static void Main(string[] args)
        {
            var tracker = new Tracker();

            tracker.PrintMethodsByAuthor();
        }
    }
}
