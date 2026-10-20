using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        // Проверяем, передан ли путь к файлу в качестве аргумента
        if (args.Length == 0)
        {
            Console.WriteLine("Ошибка: Пожалуйста, укажите путь к файлу в качестве аргумента командной строки.");
            return;
        }

        string filePath = args[0];

        // Проверяем, существует ли указанный файл
        if (!File.Exists(filePath))
        {
            Console.WriteLine($"Ошибка: Файл по пути '{filePath}' не найден.");
            return;
        }

        try
        {
            // Считываем всё содержимое файла в строку
            string fileContent = File.ReadAllText(filePath);

            // Переносим символы из файла в коллекцию List<char>
            List<char> charsList = new List<char>(fileContent);

            // Вызываем метод для подсчета гласных и согласных
            CountVowelsAndConsonants(charsList, out int vowelsCount, out int consonantsCount);

            // Выводим результат
            Console.WriteLine($"Файл успешно обработан: {filePath}");
            Console.WriteLine($"Количество гласных букв: {vowelsCount}");
            Console.WriteLine($"Количество согласных букв: {consonantsCount}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Произошла ошибка при чтении файла: {ex.Message}");
        }
    }

    /// Метод для подсчета гласных и согласных букв в списке символов.
    static void CountVowelsAndConsonants(List<char> textChars, out int vowels, out int consonants)
    {
        vowels = 0;
        consonants = 0;

        // Строки со всеми гласными буквами (для русского и английского языков)
        string vowelsSet = "аеёиоуыэюяАЕЁИОУЫЭЮЯaeiouyAEIOUY";

        // Строки со всеми согласными буквами (для русского и английского языков)
        string consonantsSet = "бвгджзйклмнпрстфхцчшщБВГДЖЗЙКЛМНПРСТФХЦЧШЩbcdfghjklmnpqrstvwxyzBCDFGHJKLMNPQRSTVWXYZ";

        // Проход по коллекции List<char>
        foreach (char ch in textChars)
        {
            if (vowelsSet.Contains(ch))
            {
                vowels++;
            }
            else if (consonantsSet.Contains(ch))
            {
                consonants++;
            }
        }
    }
}
