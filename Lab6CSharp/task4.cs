using System;
using System.Collections;
using System.Collections.Generic;

class Rectangle : IEnumerable<int>
{
    // Захищені поля
    protected int a, b;
    protected int c;

    // Конструктор
    public Rectangle(int a, int b, int color)
    {
        this.a = a;
        this.b = b;
        this.c = color;
    }

    // Властивості
    public int A
    {
        get { return a; }
        set { a = value; }
    }

    public int B
    {
        get { return b; }
        set { b = value; }
    }

    public int Color
    {
        get { return c; }
    }

    // Індексатор
    public object this[int index]
    {
        get
        {
            switch (index)
            {
                case 0: return a;
                case 1: return b;
                case 2: return c;
                default: return "Помилка: неправильний iндекс";
            }
        }
        set
        {
            switch (index)
            {
                case 0:
                    a = Convert.ToInt32(value);
                    break;
                case 1:
                    b = Convert.ToInt32(value);
                    break;
                case 2:
                    c = Convert.ToInt32(value);
                    break;
                default:
                    Console.WriteLine("Помилка: неправильний iндекс");
                    break;
            }
        }
    }

    // Перевантаження оператора ++
    public static Rectangle operator ++(Rectangle r)
    {
        r.a++;
        r.b++;
        return r;
    }

    // Перевантаження оператора --
    public static Rectangle operator --(Rectangle r)
    {
        r.a--;
        r.b--;
        return r;
    }

    // Перевантаження true
    public static bool operator true(Rectangle r)
    {
        return r.a == r.b;
    }

    // Перевантаження false
    public static bool operator false(Rectangle r)
    {
        return r.a != r.b;
    }

    // Перевантаження оператора *
    public static Rectangle operator *(Rectangle r, int scalar)
    {
        return new Rectangle(r.a * scalar, r.b * scalar, r.c);
    }

    // Явне перетворення Rectangle в string
    public static explicit operator string(Rectangle r)
    {
        return $"a={r.a},b={r.b},колiр={r.c}";
    }

    // Явне перетворення string в Rectangle
    public static explicit operator Rectangle(string str)
    {
        if (string.IsNullOrEmpty(str))
            throw new ArgumentException("Input string cannot be null or empty");

        string[] parts = str.Split(',');
        if (parts.Length != 3)
            throw new ArgumentException("Input string must have exactly 3 parts separated by commas");

        string[] aParts = parts[0].Split('=');
        if (aParts.Length != 2 || !int.TryParse(aParts[1], out int a))
            throw new ArgumentException("Invalid format for 'a' value");

        string[] bParts = parts[1].Split('=');
        if (bParts.Length != 2 || !int.TryParse(bParts[1], out int b))
            throw new ArgumentException("Invalid format for 'b' value");

        string[] colorParts = parts[2].Split('=');
        if (colorParts.Length != 2 || !int.TryParse(colorParts[1], out int color))
            throw new ArgumentException("Invalid format for 'color' value");

        return new Rectangle(a, b, color);
    }

    // Методи з лабораторної роботи №3
    public void PrintInfo()
    {
        Console.WriteLine($"Прямокутник: a = {a}, b = {b}, колiр = {c}");
    }

    public int GetPerimeter()
    {
        return 2 * (a + b);
    }

    public int GetArea()
    {
        return a * b;
    }

    public bool IsSquare()
    {
        return a == b;
    }

    // Реалізація IEnumerable<int> для підтримки foreach
    public IEnumerator<int> GetEnumerator()
    {
        yield return a;
        yield return b;
        yield return c;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

class Program
{
    static void Main()
    {
        try
        {
            Rectangle rect = new Rectangle(5, 5, 1);

            Console.WriteLine("Тестування iндексатора:");
            Console.WriteLine($"a: {rect[0]}");
            Console.WriteLine($"b: {rect[1]}");
            Console.WriteLine($"колір: {rect[2]}");
            Console.WriteLine($"Неправильний iндекс: {rect[3]}");

            Console.WriteLine("\nТестування оператора ++:");
            rect++;
            Console.WriteLine($"a пiсля ++: {rect[0]}");
            Console.WriteLine($"b пiсля ++: {rect[1]}");

            Console.WriteLine("\nТестування операторiв true/false:");
            if (rect)
                Console.WriteLine("Це квадрат");
            else
                Console.WriteLine("Це не квадрат");

            Console.WriteLine("\nТестування оператора *:");
            rect = rect * 2;
            Console.WriteLine($"a пiсля множення на 2: {rect[0]}");
            Console.WriteLine($"b пiсля множення на 2: {rect[1]}");

            Console.WriteLine("\nТестування перетворення в string:");
            string rectStr = (string)rect;
            Console.WriteLine(rectStr);

            Console.WriteLine("\nТестування перетворення зi string:");
            Rectangle rect2 = (Rectangle)"a=3,b=4,колiр=2";
            Console.WriteLine($"a: {rect2[0]}");
            Console.WriteLine($"b: {rect2[1]}");
            Console.WriteLine($"колiр: {rect2[2]}");

            Console.WriteLine("\nТестування методiв з лабораторної роботи №3:");
            rect2.PrintInfo();
            Console.WriteLine($"Периметр: {rect2.GetPerimeter()}");
            Console.WriteLine($"Площа: {rect2.GetArea()}");
            Console.WriteLine($"Це квадрат? {rect2.IsSquare()}");

            Console.WriteLine("\nПеребiр через foreach:");
            foreach (int value in rect)
            {
                Console.WriteLine(value);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка: {ex.Message}");
        }
    }
}
