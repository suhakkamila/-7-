using System;
using DataStructures;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        CharList list = new CharList();
        list.Add('a');
        list.Add('p');
        list.Add('p');
        list.Add('l');
        list.Add('e');
        list.Add('!');
        list.Add('Z');

        Console.WriteLine("🔸 Початковий список:");
        int pos = 0;
        foreach (char c in list)
        {
            Console.WriteLine($"Позиція {pos}: символ '{c}', ASCII = {(int)c}");
            pos++;
        }

        Console.WriteLine();

        // 1. Пошук першого входження символу
        char searchChar = '!';
        int index = list.IndexOf(searchChar);
        Console.WriteLine($"🔍 Перше входження символу '{searchChar}' на позиції: {index}");
        Console.WriteLine();

        // 2. Сума ASCII-кодів на непарних позиціях
        Console.WriteLine("📊 Обчислення суми ASCII-кодів на непарних позиціях:");
        int sum = 0;
        int i = 0;
        foreach (char c in list)
        {
            int ascii = (int)c;
            string type = (i % 2 == 1) ? "непарна" : "парна";
            Console.WriteLine($"Позиція {i} ({type}): '{c}' (ASCII = {ascii})" +
                              ((i % 2 == 1) ? $" — враховується в суму" : ""));
            if (i % 2 == 1) sum += ascii;
            i++;
        }
        Console.WriteLine($"✅ Сума ASCII-кодів на непарних позиціях: {sum}");
        Console.WriteLine();

        // 3. Новий список > заданого значення
        char threshold = 'b';
        Console.WriteLine($"📥 Створення нового списку: символи > '{threshold}' (ASCII { (int)threshold })");
        CharList filtered = list.FilterGreaterThan(threshold);
        foreach (char c in filtered)
        {
            Console.WriteLine($"Символ '{c}' (ASCII = {(int)c}) > '{threshold}'");
        }
        Console.WriteLine();

        // 4. Видалення елементів > середнього
        Console.WriteLine("⚙️ Обчислення середнього значення:");
        int total = 0;
        int count = 0;
        foreach (char c in list)
        {
            Console.WriteLine($"Символ '{c}', ASCII = {(int)c}");
            total += c;
            count++;
        }
        double average = (double)total / count;
        Console.WriteLine($"📈 Сума: {total}, Кількість: {count}, Середнє = {average:F2}");

        Console.WriteLine($"❌ Видаляємо елементи > {average:F2}...");
        list.RemoveGreaterThanAverage();

        Console.WriteLine("📃 Залишилися символи в списку:");
        foreach (char c in list)
        {
            Console.WriteLine($"Символ '{c}', ASCII = {(int)c}");
        }
    }
}
