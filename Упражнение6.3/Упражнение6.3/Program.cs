using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        //  Создаем словарь
        // Ключ (TKey) — строка (название месяца), Значение (TValue) — массив температур по дням
        Dictionary<string, int[]> yearTemperatures = new Dictionary<string, int[]>();

        string[] months = {
            "Январь", "Февраль", "Март", "Апрель", "Май", "Июнь",
            "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь"
        };

        Random rand = new Random();

        // Заполняем словарь случайными температурами для каждого месяца (по 30 дней)
        foreach (string month in months)
        {
            int[] dailyTemps = new int; // 30 дней в месяце по условию
            for (int i = 0; i < dailyTemps.Length; i++)
            {
                dailyTemps[i] = rand.Next(-20, 31); // Случайные градусы от -20 до +30
            }
            yearTemperatures.Add(month, dailyTemps);
        }

        //  Вызываем метод для расчета средних температур
        List<KeyValuePair<string, double>> averageTempsList = CalculateAverage(yearTemperatures);

        // Сортируем полученный результат по возрастанию температуры
        averageTempsList.Sort((x, y) => x.Value.CompareTo(y.Value));

        // Выводим результат на экран
        Console.WriteLine("Средние температуры по месяцам (отсортировано по возрастанию):\n");
        foreach (var pair in averageTempsList)
        {
            // Выводим название месяца и округленную до 2 знаков температуру
            Console.WriteLine($"{pair.Key,-12} : {pair.Value,6:F2} °C");
        }
    }

    /// Метод, который принимает словарь с температурами, считает среднюю температуру 
    /// для каждого месяца и возвращает список пар "Месяц - Среднее значение".
    static List<KeyValuePair<string, double>> CalculateAverage(Dictionary<string, int[]> temperaturesDict)
    {
        var resultList = new List<KeyValuePair<string, double>>();

        // Проходим циклом по всему словарю
        foreach (var kvp in temperaturesDict)
        {
            string monthName = kvp.Key;
            int[] temps = kvp.Value;

            // Считаем сумму температур за текущий месяц
            int sum = 0;
            foreach (int t in temps)
            {
                sum += t;
            }

            // Находим среднее арифметическое
            double average = (double)sum / temps.Length;

            // Сохраняем пару "Название месяца - Средняя температура" в итоговый список
            resultList.Add(new KeyValuePair<string, double>(monthName, average));
        }

        return resultList;
    }
}
