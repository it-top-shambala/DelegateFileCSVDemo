using Lib;

namespace DelegateDemo
{
    internal static class Program
    {
        private static void Main()
        {
            var path = @"D:\Programming\Education\ITStep\Shambala\DelegateDemo\products_prices.csv";

            var products = ProductsPricesImport.Import(path);

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