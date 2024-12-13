// Целевой интерфейс
using System;

public interface ITarget
{
    void Request();
}

// Адаптируемый класс
public class Adaptee
{
    public void SpecificRequest()
    {
        Console.WriteLine("Специфический запрос.");
    }
}

// Адаптер
public class Adapter : ITarget
{
    private Adaptee _adaptee;

    public Adapter(Adaptee adaptee)
    {
        _adaptee = adaptee;
    }

    public void Request()
    {
        Console.WriteLine("Адаптер: Преобразование запроса.");
        _adaptee.SpecificRequest();
    }
}

// Пример использования
class Program
{
    static void Main(string[] args)
    {
        Adaptee adaptee = new Adaptee();
        ITarget target = new Adapter(adaptee);
        target.Request();
    }
}