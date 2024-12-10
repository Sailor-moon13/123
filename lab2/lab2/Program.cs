using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    public interface IAttacker
    {
        void Attack(Unit unit);
    }

    public interface IMoveable
    {
        void Move(int newX, int newY);
    }

    public abstract class GameObject
    {
        private static int _idCounter = 0;
        private readonly int _id; 
        protected string _name; 
        protected int _x; 
        protected int _y; 

        protected GameObject(string name, int x, int y)
        {
            _id = _idCounter++;
            _name = name;
            _x = x;
            _y = y;
        }

        public int GetId() => _id;

        public string GetName() => _name;

        public int GetX() => _x;

        public int GetY() => _y;
    }

    public class Unit : GameObject
    {
        private float _hp; 
        private bool _isAlive;

        public Unit(string name, int x, int y, float hp) : base(name, x, y)
        {
            _hp = hp;
            _isAlive = true;
        }
        public bool IsAlive() => _isAlive;

        public float GetHp() => _hp;

        public void ReceiveDamage(float damage)
        {
            _hp -= damage; 
            if (_hp <= 0)
            {
                _isAlive = false; 
            }
        }
    }

    public class Archer : Unit, IAttacker, IMoveable
    {
        public Archer(string name, int x, int y, float hp) : base(name, x, y, hp) { }


        public void Attack(Unit unit)
        {
            if (unit.IsAlive() && IsAlive())
            {
                unit.ReceiveDamage(10); 
            }
        }

        public void Move(int newX, int newY)
        {
            _x = newX; 
            _y = newY; 
        }
    }

    public class Building : GameObject
    {
        private bool _isBuilt;

        public Building(string name, int x, int y) : base(name, x, y)
        {
            _isBuilt = false; 
        }

        public bool IsBuilt() => _isBuilt;
        public void Build()
        {
            _isBuilt = true;
        }
    }
    public class Fort : Building, IAttacker
    {
        public Fort(string name, int x, int y) : base(name, x, y) { }

        public void Attack(Unit unit)
        {
            if (unit.IsAlive() && IsBuilt())
            {
                unit.ReceiveDamage(20);
            }
        }
    }
    public class MobileHouse : Building, IMoveable
    {
        public MobileHouse(string name, int x, int y) : base(name, x, y) { }

        public void Move(int newX, int newY)
        {
            _x = newX; 
            _y = newY; 
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
