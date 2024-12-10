using System;
using System.Collections;
using System.Collections.Generic;

public interface IIterator
{
    bool HasNext();
    object Next();
}

public interface ICollection
{
    IIterator CreateIterator();
}

public class ConcreteCollection : ICollection
{
    private List<string> _items = new List<string>();

    public void Add(string item)
    {
        _items.Add(item);
    }

    public IIterator CreateIterator()
    {
        return new ConcreteIterator(this);
    }

    public int Count => _items.Count;

    public string this[int index]
    {
        get { return _items[index]; }
    }
}

public class ConcreteIterator : IIterator
{
    private ConcreteCollection _collection;
    private int _currentIndex = 0;

    public ConcreteIterator(ConcreteCollection collection)
    {
        _collection = collection;
    }

    public bool HasNext()
    {
        return _currentIndex < _collection.Count;
    }

    public object Next()
    {
        return _collection[_currentIndex++];
    }
}

// Пример использования
class Program
{
    static void Main()
    {
        var collection = new ConcreteCollection();
        collection.Add("Item 1");
        collection.Add("Item 2");
        collection.Add("Item 3");

        var iterator = collection.CreateIterator();
        while (iterator.HasNext())
        {
            Console.WriteLine(iterator.Next());
        }
    }
}