// Интерфейс субъекта
using System;

public interface ISubject
{
    void Request();
}

// Реальный субъект
public class RealSubject : ISubject
{
    public void Request()
    {
        Console.WriteLine("Выполняется запрос реального субъекта.");
    }
}

// Прокси
public class Proxy : ISubject
{
    private RealSubject _realSubject;

    public void Request()
    {
        if (_realSubject == null)
        {
            _realSubject = new RealSubject();
        }
        Console.WriteLine("Прокси: Обработка перед вызовом реального субъекта.");
        _realSubject.Request();
        Console.WriteLine("Прокси: Обработка после вызова реального субъекта.");
    }
}

// Пример использования
class Program
{
    static void Main(string[] args)
    {
        ISubject subject = new Proxy();
        subject.Request();
    }
}