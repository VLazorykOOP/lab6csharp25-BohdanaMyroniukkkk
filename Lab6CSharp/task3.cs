 using System;

// Власний виняток
class EmptyAuthorException : Exception
{
    public EmptyAuthorException() : base("Прізвище автора не може бути порожнім.") { }
}

// Інтерфейс видання
interface IVidannya
{
    void Show();
    bool IsAuthor(string author);
}

// Клас Книга
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

// Основна програма
class Program
{
    static void Main()
    {
        try
        {
            IVidannya[] catalog = new IVidannya[2];
            catalog[0] = new Book("Алгоритми", "Шевченко", 2020, "Технiка");
            catalog[1] = new Book("Iнформатика", "Коваленко", 2021, "Освiта");

            Console.WriteLine("Всi видання:");
            foreach (var item in catalog)
            {
                item.Show();
            }

            Console.WriteLine("\nПошук за прiзвищем автора:");
            Console.Write("Введiть прiзвище: ");
            string? input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                throw new EmptyAuthorException();
            }

            bool found = false;
            foreach (var item in catalog)
            {
                if (item.IsAuthor(input))
                {
                    item.Show();
                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine("Нiчого не знайдено.");
            }

            // Демонстрація OverflowException
            Console.WriteLine("\nСпроба переповнення:");
            checked
            {
                int big = int.MaxValue;
                big += 1; // це викличе OverflowException при checked
            }
        }
        catch (EmptyAuthorException ex)
        {
            Console.WriteLine($"Помилка: {ex.Message}");
        }
        catch (OverflowException)
        {
            Console.WriteLine("Сталася помилка переповнення значення!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Iнша помилка: {ex.Message}");
        }
        finally
        {
            Console.WriteLine("\nРобота завершена.");
        }
    }
}
 