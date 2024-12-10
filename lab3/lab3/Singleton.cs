using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    public class Singleton
    {
        private static Singleton _instance;

        // Запретить создание экземпляра класса извне
        private Singleton() { }

        public static Singleton Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Singleton();
                }
                return _instance;
            }
        }

        public void DoSomething()
        {
            Console.WriteLine("Doing something...");
        }
    }
}
