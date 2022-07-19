namespace Lib;

public static class ProductsPricesImport
{
    public static ProductsPrices Import(string path, Action<string>? info = null)
    {
        var products = new ProductsPrices();
        products.Info = info;
        
        var file = new StreamReader(path);
        var str = file.ReadToEnd();
        file.Close();

        var temp = str.Split("\r\n");
        foreach (var s in temp)
        {
            var r = GetItem(s);
            products.Add(r.key, r.values);
        }

        return products;
    }

    private static (string key, List<double> values) GetItem(string str)
    {
        var items = str.Split(';');
            
        var key = items[0];
            
        var values = new List<double>();
        for (int i = 1; i < items.Length; i++)
        {
            values.Add(Convert.ToDouble(items[i]));
        }

        return (key, values);
    }
}
