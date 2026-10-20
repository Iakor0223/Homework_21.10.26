using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    // Класс Студент
    public class Student
    {
        public string LastName { get; set; }     // Фамилия
        public string FirstName { get; set; }    // Имя
        public int BirthYear { get; set; }       // Год рождения
        public string ExamName { get; set; }     // Экзамен
        public int Score { get; set; }           // Баллы

        public Student(string lastName, string firstName, int birthYear, string examName, int score)
        {
            LastName = lastName;
            FirstName = firstName;
            BirthYear = birthYear;
            ExamName = examName;
            Score = score;
        }

        // вывод информации о студенте
        public override string ToString()
        {
            return $"{LastName} {FirstName} ({BirthYear} г.р.) | Экзамен: {ExamName} | Баллы: {Score}";
        }
    }

    static void Main(string[] args)
    {
        // Путь к файлу со студентами
        string filePath = "students.txt";


        // 1. Создаем словарь для студентов (Ключ: порядковый номер/ID, Значение: Студент)
        Dictionary<int, Student> studentsDict = new Dictionary<int, Student>();

        try
        {
            // Читаем строки из файла
            string[] lines = File.ReadAllLines(filePath);
            int idCounter = 1;

            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line)) continue;

                // Разделяем строку по точке с запятой
                string[] parts = line.Split(';');
                if (parts.Length == 5)
                {
                    string lastName = parts[0].Trim();
                    string firstName = parts[1].Trim();
                    int birthYear = int.Parse(parts[2].Trim());
                    string examName = parts[3].Trim();
                    int score = int.Parse(parts[4].Trim());

                    Student student = new Student(lastName, firstName, birthYear, examName, score);
                    studentsDict.Add(idCounter++, student);
                }
            }
            Console.WriteLine($"Успешно загружено студентов из файла: {studentsDict.Count}\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при чтении файла: {ex.Message}");
            return;
        }

        // Переносим студентов в List для выполнения операций
        List<Student> studentsList = studentsDict.Values.ToList();

        // Интерактивное консольное меню
        while (true)
        {
            Console.WriteLine("\n=== ТЕКУЩИЙ СПИСОК СТУДЕНТОВ ===");
            foreach (var student in studentsList)
            {
                Console.WriteLine(student);
            }

            Console.WriteLine("\nДоступные команды: [Новый студент] | [Удалить] | [Сортировать] | [Выход]");
            Console.Write("Введите команду: ");
            string command = Console.ReadLine().Trim().ToLower();

            if (command == "новый студент")
            {
                Console.WriteLine("\n--- Ввод данных нового студента ---");
                Console.Write("Фамилия: ");
                string ln = Console.ReadLine();
                Console.Write("Имя: ");
                string fn = Console.ReadLine();
                Console.Write("Год рождения: ");
                int by = int.Parse(Console.ReadLine());
                Console.Write("Профильный экзамен: ");
                string exam = Console.ReadLine();
                Console.Write("Баллы: ");
                int sc = int.Parse(Console.ReadLine());

                // Добавляем нового студента в List
                studentsList.Add(new Student(ln, fn, by, exam, sc));
                Console.WriteLine("Студент успешно добавлен!");
            }
            else if (command == "удалить")
            {
                Console.WriteLine("\n--- Удаление студента ---");
                Console.Write("Введите фамилию для удаления: ");
                string lnForDelete = Console.ReadLine().Trim();
                Console.Write("Введите имя для удаления: ");
                string fnForDelete = Console.ReadLine().Trim();

                // Ищем студента по фамилии и имени (игнорируя регистр букв)
                Student studentToRemove = studentsList.FirstOrDefault(s =>
                    s.LastName.Equals(lnForDelete, StringComparison.OrdinalIgnoreCase) &&
                    s.FirstName.Equals(fnForDelete, StringComparison.OrdinalIgnoreCase));

                if (studentToRemove != null)
                {
                    studentsList.Remove(studentToRemove);
                    Console.WriteLine($"Студент {lnForDelete} {fnForDelete} успешно удален.");
                }
                else
                {
                    Console.WriteLine("Студент с такими данными не найден.");
                }
            }
            else if (command == "сортировать")
            {
                // Сортировка по баллам (по возрастанию)
                studentsList = studentsList.OrderBy(s => s.Score).ToList();
                Console.WriteLine("\n[Список успешно отсортирован по возрастанию баллов!]");
            }
            else if (command == "выход")
            {
                break;
            }
            else
            {
                Console.WriteLine("Неизвестная команда. Попробуйте еще раз.");
            }
        }
    }
}
