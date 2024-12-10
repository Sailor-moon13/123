using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    // Проектировщик
    public interface IAbstractProductA
    {
        void Interact();
    }

    public interface IAbstractProductB
    {
        void Collaborate(IAbstractProductA a);
    }

    // Конкретные продукты
    public class ConcreteProductA1 : IAbstractProductA
    {
        public void Interact()
        {
            Console.WriteLine("ConcreteProductA1 interacting");
        }
    }

    public class ConcreteProductA2 : IAbstractProductA
    {
        public void Interact()
        {
            Console.WriteLine("ConcreteProductA2 interacting");
        }
    }

    public class ConcreteProductB1 : IAbstractProductB
    {
        public void Collaborate(IAbstractProductA a)
        {
            Console.WriteLine("ConcreteProductB1 collaborating with");
            a.Interact();
        }
    }

    public class ConcreteProductB2 : IAbstractProductB
    {
        public void Collaborate(IAbstractProductA a)
        {
            Console.WriteLine("ConcreteProductB2 collaborating with");
            a.Interact();
        }
    }

    // Абстрактная фабрика
    public abstract class AbstractFactory
    {
        public abstract IAbstractProductA CreateProductA();
        public abstract IAbstractProductB CreateProductB();
    }

    // Конкретные фабрики
    public class ConcreteFactory1 : AbstractFactory
    {
        public override IAbstractProductA CreateProductA()
        {
            return new ConcreteProductA1();
        }

        public override IAbstractProductB CreateProductB()
        {
            return new ConcreteProductB1();
        }
    }

    public class ConcreteFactory2 : AbstractFactory
    {
        public override IAbstractProductA CreateProductA()
        {
            return new ConcreteProductA2();
        }

        public override IAbstractProductB CreateProductB()
        {
            return new ConcreteProductB2();
        }
    }
}
