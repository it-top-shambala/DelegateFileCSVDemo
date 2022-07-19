using Lib;

namespace DelegateDemo
{
    internal static class Program
    {
        private static void Main()
        {
            var path = @"D:\Programming\Education\ITStep\Shambala\DelegateDemo\products_prices.csv";

            var action = new Action<string>(message =>
            {
                var file = new StreamWriter($"{DateTime.Now.Date:d}_journal.log", true);
                file.WriteLine($"{DateTime.Now:g} [INFO]: {message}");
                file.Close();
            });
            action += message =>
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"{DateTime.Now:g} [INFO]: {message}");
                Console.ResetColor();
            };

            var products = ProductsPricesImport.Import(path, action);

            foreach (var (key, doubles) in products.Get())
            {
                Console.Write($"{key}: ");
                foreach (var d in doubles)
                {
                    Console.Write($"{d} ");
                }
                Console.WriteLine();
            }
        }
    }
}
