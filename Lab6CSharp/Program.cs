using System;
using System.Collections.Generic;

// Інтерфейси
interface IEntity
{
    string Name { get; }
    string Capital { get; }
    void Show();
}

interface IGovernable
{
    string Leader { get; }
}

// Базовий абстрактний клас
abstract class State : IEntity, IComparable<State>
{
    public string Name { get; set; }
    public string Capital { get; set; }

    public State(string name, string capital)
    {
        Name = name;
        Capital = capital;
        Console.WriteLine($"Конструктор State: {Name}");
    }

    public abstract void Show();

    public int CompareTo(State? other)
    {
        if (other == null) return 1;
        return Name.CompareTo(other.Name);
    }

    ~State()
    {
        Console.WriteLine($"Деструктор State: {Name}");
    }
}

// Республіка
class Republic : State, IGovernable
{
    public string President { get; set; }

    public Republic(string name, string capital, string president)
        : base(name, capital)
    {
        President = president;
        Console.WriteLine($"Конструктор Republic: {Name}");
    }

    public string Leader => President;

    public override void Show()
    {
        Console.WriteLine($"Республiка: {Name}, Столиця: {Capital}, Президент: {President}");
    }

    ~Republic()
    {
        Console.WriteLine($"Деструктор Republic: {Name}");
    }
}

// Монархія
class Monarchy : State, IGovernable
{
    public string Monarch { get; set; }

    public Monarchy(string name, string capital, string monarch)
        : base(name, capital)
    {
        Monarch = monarch;
        Console.WriteLine($"Конструктор Monarchy: {Name}");
    }

    public string Leader => Monarch;

    public override void Show()
    {
        Console.WriteLine($"Монархiя: {Name}, Столиця: {Capital}, Монарх: {Monarch}");
    }

    ~Monarchy()
    {
        Console.WriteLine($"Деструктор Monarchy: {Name}");
    }
}

// Королівство
class Kingdom : State, IGovernable
{
    public string King { get; set; }

    public Kingdom(string name, string capital, string king)
        : base(name, capital)
    {
        King = king;
        Console.WriteLine($"Конструктор Kingdom: {Name}");
    }

    public string Leader => King;

    public override void Show()
    {
        Console.WriteLine($"Королiвство: {Name}, Столиця: {Capital}, Король: {King}");
    }

    ~Kingdom()
    {
        Console.WriteLine($"Деструктор Kingdom: {Name}");
    }
}

// Основна програма
class Program1
{
    static void Main1()
    {
        Console.Write("Введiть номер завдання (1 або 2): ");
        string? input = Console.ReadLine();

        switch (input)
        {
            case "1":
                RunTask1();
                break;
            case "2":
                RunTask2();
                break;
            default:
                Console.WriteLine("Неправильний вибiр. Введiть 1 або 2.");
                break;
        }

        GC.Collect();
        GC.WaitForPendingFinalizers();
    }

    static void RunTask1()
    {
        Console.WriteLine("\nЗавдання 1: ");

        Republic republic = new Republic("Україна", "Київ", "Зеленський");
        Monarchy monarchy = new Monarchy("Велика Британiя", "Лондон", "Чарльз III");
        Kingdom kingdom = new Kingdom("Iспанiя", "Мадрид", "Фелiпе VI");

        republic.Show();
        monarchy.Show();
        kingdom.Show();
    }

    static void RunTask2()
    {
        Console.WriteLine("\nЗавдання 2: ");

        List<State> states = new List<State>
        {
            new Republic("Україна", "Київ", "Зеленський"),
            new Kingdom("Iспанiя", "Мадрид", "Фелiпе VI"),
            new Monarchy("Велика Британiя", "Лондон", "Чарльз III"),
        };

        Console.WriteLine("\nДо сортування:");
        foreach (var state in states)
            state.Show();

        states.Sort();

        Console.WriteLine("\nПiсля сортування за назвою:");
        foreach (var state in states)
            state.Show();
    }
}
