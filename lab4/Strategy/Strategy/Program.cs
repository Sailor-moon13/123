using System;
using System.Collections.Generic;

public interface IStrategy
{
    void Execute(List<int> data);
}

public class ConcreteStrategyA : IStrategy
{
    public void Execute(List<int> data)
    {
        data.Sort();
        Console.WriteLine("Sorting data in ascending order: " + string.Join(", ", data));
    }
}

public class ConcreteStrategyB : IStrategy
{
    public void Execute(List<int> data)
    {
        data.Sort((a, b) => b.CompareTo(a));
        Console.WriteLine("Sorting data in descending order: " + string.Join(", ", data));
    }
}

public class Context
{
    private IStrategy _strategy;

    public Context(IStrategy strategy)
    {
        _strategy = strategy;
    }

    public void SetStrategy(IStrategy strategy)
    {
        _strategy = strategy;
    }

    public void DoSomeLogic(List<int> data)
    {
        _strategy.Execute(data);
    }
}

// Пример использования
class Program
{
    static void Main()
    {
        var data = new List<int> { 3, 1, 4, 1, 5, 9 };

        var context = new Context(new ConcreteStrategyA());
        context.DoSomeLogic(data);  // Output: Sorting data in ascending order: 1, 1, 3, 4, 5, 9

        context.SetStrategy(new ConcreteStrategyB());
        context.DoSomeLogic(data);  // Output: Sorting data in descending order: 9, 5, 4, 3, 1, 1
    }
}