using System;
using System.Collections.Generic;

namespace useOfInterface
{
    interface ICanMove
    {
        void Run();
        void Back();
        double Velocity(double d, int t);
    }
    interface ICanEat
    {
        void Eat();
    }
    interface ICanDrink
    {
        void Drink();
    }

     abstract class Animal: ICanMove

    {
        public virtual void Run()
        {
            Console.WriteLine("Animal is running");
        }
        public abstract void Back();
        public abstract double Velocity(double a, int t);

    }
    class Cat : Animal, ICanEat, ICanDrink
    {
        private string name { get; set; }
        //constructor
        public Cat(string name)
        {
            this.name = name;
        }
        public override void Back()
        {
            Console.WriteLine($"{name} hurriedly runs back");
        }
        public override double Velocity(double d, int t)
        {
            double v = d / t;
            return v;
        }
        public override void Run()
        {
            Console.WriteLine($"{name} is running");
        }
        void ICanEat.Eat()
        {
            Console.WriteLine($"{name} is eating fish");
        }
        void ICanDrink.Drink()
        {
            Console.WriteLine($"{name} is drinking");
        }
    }
    class Mouse : Animal, ICanEat, ICanDrink
    {
        private string name { get; set; }
        //constructor
        public Mouse(string name)
        {
            this.name = name;
        }
        //methid override
        public override void Back()
        {
            Console.WriteLine($"{name} scurries quickly");
        }
        public override double Velocity(double d, int t)
        {
            double v = d / t;
            return v;
        }
        public override void Run()
        {
            Console.WriteLine($"{name} is running");
        }
        
        void ICanDrink.Drink()
        {
            Console.WriteLine($"{name} is drinking from the cat's water");
        }
        void ICanEat.Eat()
        {
            Console.WriteLine($"{name} eats the food from cat's leftovers");
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            string cname, mname;
            Console.Write("Enter the name of the cat: ");
            cname = Console.ReadLine();
            Console.Write("Enter the name of the mouse: ");
            mname = Console.ReadLine();

            Animal cat = new Cat(cname);
            Animal mouse = new Mouse(mname);

            //cat and mouse eating and drinking
            Console.WriteLine("\n");
            ((ICanEat)cat).Eat();
            ((ICanDrink)cat).Drink();
            ((ICanEat)mouse).Eat();
            ((ICanDrink)mouse).Drink();



            //the chase
            Console.WriteLine("\n");    
            cat.Run();
            Console.Write("Enter distance of cat to mouse: ");
            double cd = Convert.ToDouble(Console.ReadLine());
            mouse.Run();
            Console.Write("Enter time taken by the cat to reach the mouse: ");
            int ct = Convert.ToInt32(Console.ReadLine());

            
            Console.Write("Enter time taken by the mouse to escape: ");
            int mt = Convert.ToInt32(Console.ReadLine());
            
            Console.WriteLine("\n");
            Console.WriteLine($"{cname} is {cat.Velocity(cd,ct)} kph while trying to catch {mname}");
            Console.WriteLine($"{mname} was running away in {mouse.Velocity(cd,mt)} kph from {cname}");
            Console.WriteLine($"The owner called back {cname}");
            cat.Back();
            mouse.Back();
            Console.WriteLine($"{mname} escaped safely");

        }
    }
}