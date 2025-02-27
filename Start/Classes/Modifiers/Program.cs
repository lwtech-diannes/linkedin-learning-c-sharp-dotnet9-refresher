using System;

namespace Modifiers
{
    class Program
    {
        static void Main(string[] args)
        {
            // create a new Book instance
            Book b1 = new Book("War and Peace", "Leo Tolstoy", 825);

            // In previous example, this would fail, but will now
            // work since the field name is declared as public
            b1._name = "Aldous Huxley";
            Console.WriteLine(b1.GetDescription());

            // TODO: set data using functions instead of accessing fields directly

        }
    }
}
