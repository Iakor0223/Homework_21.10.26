using System;
using System.Collections.Generic;

class Program
{
    // Класс, имитирующий скачанную картинку
    public class ImageItem
    {
        public int Id { get; set; }          // ID пары (0 до 31)
        public string Url { get; set; }     // Ссылка на скачанный файл

        public ImageItem(int id, string url)
        {
            Id = id;
            Url = url;
        }
    }

    static void Main(string[] args)
    {
        // Создаем изначальный список на 64 элемента
        List<ImageItem> imageList = new List<ImageItem>(64);

        // Имитируем ссылки на 32 скачанные из интернета уникальные картинки
        string baseUrl = "https://picsum.photos{0}/200";

        // Добавляем по 2 одинаковые картинки (32 пары)
        for (int i = 0; i < 32; i++)
        {
            string downloadedUrl = string.Format(baseUrl, i + 10);

            imageList.Add(new ImageItem(i, downloadedUrl));
            imageList.Add(new ImageItem(i, downloadedUrl));
        }

        // Выводим изначальные номера (ID картинок) в консоль
        Console.WriteLine("--- Изначальный список (номера/ID пар картинок) ---");
        int count = 0;
        foreach (var item in imageList)
        {
            Console.Write($"{item.Id:D2} ");
            count++;
            if (count % 16 == 0) Console.WriteLine();
        }

        // Перемешиваем список алгоритмом Фишера-Йетса
        Random rand = new Random();
        int n = imageList.Count;
        while (n > 1)
        {
            n--;
            int k = rand.Next(n + 1);
            ImageItem value = imageList[k];
            imageList[k] = imageList[n];
            imageList[n] = value;
        }

        // Выводим полученный перемешанный список в консоль
        Console.WriteLine("\n--- Полученный (перемешанный) список ---");
        count = 0;
        foreach (var item in imageList)
        {
            Console.Write($"{item.Id:D2} ");
            count++;
            if (count % 16 == 0) Console.WriteLine();
        }
    }
}
