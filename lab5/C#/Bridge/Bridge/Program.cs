// Абстракция
using System;

public abstract class Abstraction
{
    protected IImplementor _implementor;

    protected Abstraction(IImplementor implementor)
    {
        _implementor = implementor;
    }

    public abstract void Operation();
}

// Реализация интерфейса
public interface IImplementor
{
    void Implementation();
}

// Конкретная реализация 1
public class ConcreteImplementorA : IImplementor
{
    public void Implementation()
    {
        Console.WriteLine("ConcreteImplementorA: Реализация метода.");
    }
}

// Конкретная реализация 2
public class ConcreteImplementorB : IImplementor
{
    public void Implementation()
    {
        Console.WriteLine("ConcreteImplementorB: Реализация метода.");
    }
}

// Конкретная абстракция
public class RefinedAbstraction : Abstraction
{
    public RefinedAbstraction(IImplementor implementor) : base(implementor) { }

    public override void Operation()
    {
        Console.WriteLine("RefinedAbstraction: Вызов реализации.");
        _implementor.Implementation();
    }
}

// Пример использования
class Program
{
    static void Main(string[] args)
    {
        IImplementor implementor = new ConcreteImplementorA();
        Abstraction abstraction = new RefinedAbstraction(implementor);
        abstraction.Operation();

        implementor = new ConcreteImplementorB();
        abstraction = new RefinedAbstraction(implementor);
        abstraction.Operation();
    }
}