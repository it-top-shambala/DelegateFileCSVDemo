namespace Lib;

public class ProductsPrices
{
    private Dictionary<string, List<double>> _dict;

    public ProductsPrices()
    {
        _dict = new Dictionary<string, List<double>>();
    }

    public void Add(string key, List<double> value)
    {
        _dict.Add(key, value);
    }

    public void Del(string key)
    {
        _dict.Remove(key);
    }

    public Dictionary<string, List<double>> Get()
    {
        return _dict;
    }
}