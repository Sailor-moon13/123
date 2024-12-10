using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Использование Singleton
            Singleton singleton = Singleton.Instance;
            singleton.DoSomething();

            // Использование Factory Method
            Creator creatorA = new ConcreteCreatorA();
            creatorA.SomeOperation();

            Creator creatorB = new ConcreteCreatorB();
            creatorB.SomeOperation();

            // Использование Abstract Factory
            AbstractFactory factory1 = new ConcreteFactory1();
            IAbstractProductA productA1 = factory1.CreateProductA();
            IAbstractProductB productB1 = factory1.CreateProductB();
            productB1.Collaborate(productA1);

            AbstractFactory factory2 = new ConcreteFactory2();
            IAbstractProductA productA2 = factory2.CreateProductA();
            IAbstractProductB productB2 = factory2.CreateProductB();
            productB2.Collaborate(productA2);

            // Использование Builder
            Director director = new Director();
            ConcreteBuilder builder = new ConcreteBuilder();
            director.SetBuilder(builder);
            director.Construct();

            Product product = builder.GetResult();
            product.Show();
        }
    }
}
