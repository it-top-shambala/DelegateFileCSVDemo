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
            string key = string.Empty;
            List<double> values = new List<double>();

            Dictionary<string, Action> menuActions = new Dictionary<string, Action>
            {
                {"1", () => products.Add(key, values)},
                {"2", () => products.Del(key)},
                {"3", () => Show(products)}
            };

            menuActions["3"].Invoke();
        }

        private static void Show(ProductsPrices products)
        {
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
