using System;

interface IVidannya
{
    void Show();
    bool IsAuthor(string author);
}

class Book : IVidannya
{
    public string Title { get; set; }
    public string AuthorSurname { get; set; }
    public int Year { get; set; }
    public string Publisher { get; set; }

    public Book(string title, string authorSurname, int year, string publisher)
    {
        Title = title;
        AuthorSurname = authorSurname;
        Year = year;
        Publisher = publisher;
    }

    public void Show()
    {
        Console.WriteLine($"Книга: {Title}, Автор: {AuthorSurname}, Рiк: {Year}, Видавництво: {Publisher}");
    }

    public bool IsAuthor(string author)
    {
        return AuthorSurname.Equals(author, StringComparison.OrdinalIgnoreCase);
    }
}

class Article : IVidannya
{
    public string Title { get; set; }
    public string AuthorSurname { get; set; }
    public string Journal { get; set; }
    public int Number { get; set; }
    public int Year { get; set; }

    public Article(string title, string authorSurname, string journal, int number, int year)
    {
        Title = title;
        AuthorSurname = authorSurname;
        Journal = journal;
        Number = number;
        Year = year;
    }

    public void Show()
    {
        Console.WriteLine($"Стаття: {Title}, Автор: {AuthorSurname}, Журнал: {Journal}, №{Number}, Рiк: {Year}");
    }

    public bool IsAuthor(string author)
    {
        return AuthorSurname.Equals(author, StringComparison.OrdinalIgnoreCase);
    }
}

class ElectronicResource : IVidannya
{
    public string Title { get; set; }
    public string AuthorSurname { get; set; }
    public string Link { get; set; }
    public string Annotation { get; set; }

    public ElectronicResource(string title, string authorSurname, string link, string annotation)
    {
        Title = title;
        AuthorSurname = authorSurname;
        Link = link;
        Annotation = annotation;
    }

    public void Show()
    {
        Console.WriteLine($"Електронний ресурс: {Title}, Автор: {AuthorSurname}, Посилання: {Link}, Анотацiя: {Annotation}");
    }

    public bool IsAuthor(string author)
    {
        return AuthorSurname.Equals(author, StringComparison.OrdinalIgnoreCase);
    }
}

class Program2
{
    static void Main2()
    {
        IVidannya[] catalog = new IVidannya[4];
        catalog[0] = new Book("Програмування", "Iваненко", 2020, "Наука");
        catalog[1] = new Article("Штучний iнтелект", "Петренко", "Iнформатика", 2, 2021);
        catalog[2] = new ElectronicResource("Бази даних", "Сидоренко", "https://example.com", "Матерiали курсу");
        catalog[3] = new Book("Математика", "Iваненко", 2018, "Освiта");

        Console.WriteLine("Усi видання:");
        foreach (var item in catalog)
        {
            item.Show();
        }

        Console.WriteLine("\nПошук за прiзвищем автора:");
        Console.Write("Введiть прiзвище автора: ");
        string? searchAuthor = Console.ReadLine();
        bool found = false;

        if (!string.IsNullOrWhiteSpace(searchAuthor))
        {
            foreach (var item in catalog)
            {
                if (item.IsAuthor(searchAuthor))
                {
                    item.Show();
                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine("Нiчого не знайдено за цим прiзвищем.");
            }
        }
        else
        {
            Console.WriteLine("Ви не ввели прiзвище автора.");
        }
    }
}
