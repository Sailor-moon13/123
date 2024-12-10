using System;

public abstract class Handler
{
    protected Handler _nextHandler;

    public Handler SetNext(Handler handler)
    {
        _nextHandler = handler;
        return handler;
    }

    public virtual bool Handle(string request)
    {
        if (_nextHandler != null)
        {
            return _nextHandler.Handle(request);
        }
        return false;
    }
}

public class ConcreteHandlerA : Handler
{
    public override bool Handle(string request)
    {
        if (request == "A")
        {
            Console.WriteLine("Handler A handled request A");
            return true;
        }
        else
        {
            return base.Handle(request);
        }
    }
}

public class ConcreteHandlerB : Handler
{
    public override bool Handle(string request)
    {
        if (request == "B")
        {
            Console.WriteLine("Handler B handled request B");
            return true;
        }
        else
        {
            return base.Handle(request);
        }
    }
}

// Пример использования
class Program
{
    static void Main()
    {
        var handlerA = new ConcreteHandlerA();
        var handlerB = new ConcreteHandlerB();
        handlerA.SetNext(handlerB);

        handlerA.Handle("A");  // Output: Handler A handled request A
        handlerA.Handle("B");  // Output: Handler B handled request B
        handlerA.Handle("C");  // Output: (no output because no handler for C)
    }
}