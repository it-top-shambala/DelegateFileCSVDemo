namespace Lib;

//public delegate void Message(string message);

public class ProductsPrices
{
    private Dictionary<string, List<double>> _dict;

    //public Message Info;
    public Action<string>? Info;

    public ProductsPrices()
    {
        _dict = new Dictionary<string, List<double>>();
    }

    public void Add(string key, List<double> value)
    {
        _dict.Add(key, value);
        /*
        if (Info is not null)
        {
            Info.Invoke("Добавлены данные");
        }
        */
        Info?.Invoke("Добавлены данные");
    }

    public void Del(string key)
    {
        _dict.Remove(key);
        Info?.Invoke("Удалены данные");
    }

    public Dictionary<string, List<double>> Get()
    {
        return _dict;
    }
}
