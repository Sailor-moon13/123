using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    // Продукты
    public interface IProduct
    {
        void Use();
    }

    public class ConcreteProductA : IProduct
    {
        public void Use()
        {
            Console.WriteLine("Using Product A");
        }
    }

    public class ConcreteProductB : IProduct
    {
        public void Use()
        {
            Console.WriteLine("Using Product B");
        }
    }

    // Создатель
    public abstract class Creator
    {
        public abstract IProduct FactoryMethod();

        public void SomeOperation()
        {
            IProduct product = FactoryMethod();
            product.Use();
        }
    }

    // Конкретные создатели
    public class ConcreteCreatorA : Creator
    {
        public override IProduct FactoryMethod()
        {
            return new ConcreteProductA();
        }
    }

    public class ConcreteCreatorB : Creator
    {
        public override IProduct FactoryMethod()
        {
            return new ConcreteProductB();
        }
    }
}
