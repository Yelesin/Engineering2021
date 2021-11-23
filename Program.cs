using System;

namespace Factory_method
{
    abstract class Car
    {
        string Color { get; set; }
        int HP { get; set; }
        int Weight { get; set; }
        public Car(string color, int hp, int weight)
        {
            Color = color;
            HP = hp;
            Weight = weight;
        }
        public void showParam()
        {
            Console.WriteLine("Этот автомобиль имеет вес {1}, {2} лошадиных сил. Цвет: {0} ", Color, Weight, HP);
        }
    }

    abstract class Developer 
    {
        public string Name { get; set; }
        public Developer(string name)
        {
            Name = name;
        }
        public abstract Car buildCar();
    }

    class SportCar: Car
    {
        public SportCar(string color, int hp, int weight): base(color, hp, weight)
        {
            Console.WriteLine("Построили спорткар");
        }
    }

    class Familycar: Car
    {
        public Familycar(string color, int hp, int weight) : base(color, hp, weight)
        {
            Console.WriteLine("построили семейный автомобиль");
        }
    }
    
    class SportcarDeveloper: Developer
    {
        public SportcarDeveloper(string name): base(name){}
        public override Car buildCar()
        {
            Random rnd = new Random();
            int hp = rnd.Next(300, 700);
            int weight = rnd.Next(700, 1500);
            string[] colors = new string[] { "Красный", "Жёлтый", "Синий", "Чёрный"};
            string color = colors[rnd.Next(0, 4)];

            return new SportCar(color, hp, weight);
        }
    }

    class FamilycarDeveloper: Developer
    {
        public FamilycarDeveloper(string name) : base(name) { }
        public override Car buildCar()
        {
            Random rnd = new Random();
            int hp = rnd.Next(80, 200);
            int weight = rnd.Next(900, 2500);
            string[] colors = new string[] { "Белый", "Серый", "Чёрный" };
            string color = colors[rnd.Next(0, 3)];
            return new Familycar(color, hp, weight);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Developer sport = new SportcarDeveloper("Ferrari");
            Developer family = new FamilycarDeveloper("Nissan");
            Car tida = family.buildCar();
            tida.showParam();
            Car enzo = sport.buildCar();
            enzo.showParam();
        }
    }
}
