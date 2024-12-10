using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    // Продукт
    public class Product
    {
        public string PartA { get; set; }
        public string PartB { get; set; }
        public string PartC { get; set; }

        public void Show()
        {
            Console.WriteLine($"Product consists of: {PartA}, {PartB}, {PartC}");
        }
    }

    // Строитель
    public abstract class Builder
    {
        protected Product _product = new Product();

        public abstract void BuildPartA();
        public abstract void BuildPartB();
        public abstract void BuildPartC();

        public Product GetResult()
        {
            return _product;
        }
    }

    // Конкретные строители
    public class ConcreteBuilder : Builder
    {
        public override void BuildPartA()
        {
            _product.PartA = "PartA";
        }

        public override void BuildPartB()
        {
            _product.PartB = "PartB";
        }

        public override void BuildPartC()
        {
            _product.PartC = "PartC";
        }
    }

    // Директор
    public class Director
    {
        private Builder _builder;

        public void SetBuilder(Builder builder)
        {
            _builder = builder;
        }

        public void Construct()
        {
            _builder.BuildPartA();
            _builder.BuildPartB();
            _builder.BuildPartC();
        }
    }
}
