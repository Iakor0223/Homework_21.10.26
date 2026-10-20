using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Создаем две матрицы в виде LinkedList<LinkedList<int>>
        // Матрица A (Размер 2x3)
        var matrixA = CreateMatrix(new int[,] {
            { 1, 2, 3 },
            { 4, 5, 6 }
        });

        // Матрица B (Размер 3x2)
        var matrixB = CreateMatrix(new int[,] {
            { 7, 8 },
            { 9, 1 },
            { 2, 3 }
        });

        Console.WriteLine("Матрица A:");
        PrintMatrix(matrixA);

        Console.WriteLine("\nМатрица B:");
        PrintMatrix(matrixB);

        try
        {
            // Умножение матриц
            var resultMatrix = MultiplyMatrices(matrixA, matrixB);

            Console.WriteLine("\nРезультат умножения (Матрица A * Матрица B):");
            PrintMatrix(resultMatrix);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"\nОшибка: {ex.Message}");
        }
    }

    /// Метод умножения двух матриц, заданных через LinkedList
    static LinkedList<LinkedList<int>> MultiplyMatrices(LinkedList<LinkedList<int>> a, LinkedList<LinkedList<int>> b)
    {
        int rowsA = a.Count;
        int colsA = a.First.Value.Count;
        int rowsB = b.Count;
        int colsB = b.First.Value.Count;

        // Проверка согласованности матриц для умножения
        if (colsA != rowsB)
        {
            throw new ArgumentException("Количество столбцов матрицы A должно быть равно количеству строк матрицы B.");
        }

        var result = new LinkedList<LinkedList<int>>();

        // Превращаем связные списки в индексируемые структуры для удобства математического обхода
        var listA = new List<List<int>>();
        foreach (var row in a) listA.Add(new List<int>(row));

        var listB = new List<List<int>>();
        foreach (var row in b) listB.Add(new List<int>(row));

        // Вычисление элементов новой матрицы
        for (int i = 0; i < rowsA; i++)
        {
            var rowResult = new LinkedList<int>();

            for (int j = 0; j < colsB; j++)
            {
                int sum = 0;
                for (int k = 0; k < colsA; k++)
                {
                    sum += listA[i][k] * listB[k][j];
                }
                rowResult.AddLast(sum);
            }

            result.AddLast(rowResult);
        }

        return result;
    }

    //Метод печати матрицы
    static void PrintMatrix(LinkedList<LinkedList<int>> matrix)
    {
        foreach (var row in matrix)
        {
            foreach (var val in row)
            {
                Console.Write($"{val}\t");
            }
            Console.WriteLine();
        }
    }


    /// Вспомогательный метод для удобного создания LinkedList матрицы из обычного массива
    static LinkedList<LinkedList<int>> CreateMatrix(int[,] array)
    {
        var matrix = new LinkedList<LinkedList<int>>();
        int rows = array.GetLength(0);
        int cols = array.GetLength(1);

        for (int i = 0; i < rows; i++)
        {
            var row = new LinkedList<int>();
            for (int j = 0; j < cols; j++)
            {
                row.AddLast(array[i, j]);
            }
            matrix.AddLast(row);
        }

        return matrix;
    }
}
