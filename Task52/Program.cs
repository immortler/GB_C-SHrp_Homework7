/* Задача 52. Задайте двумерный массив из целых чисел. Найдите среднее арифметическое элементов в каждом столбце.

Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
Среднее арифметическое каждого столбца: 4,6; 5,6; 3,6; 3. */

int GetNumber(string message)
{
    bool isCorrect = false;
    int result = 0;

    while (!isCorrect)
    {
        Console.WriteLine(message);

        if (int.TryParse(Console.ReadLine(), out result) && result > 0)
        {
            isCorrect = true;
        }
        else
        {
            Console.WriteLine("Error: wrong entry.");
        }
    }
    return result;
}

int[,] InitMatrix(int rows, int columns)
{
    int[,] matrix = new int[rows, columns];

    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            matrix[i, j] = GetNumber($"Enter element of {i + 1} row, {j + 1} column:");
        }
    }

    return matrix;
}

void PrintArray(int[,] matrix)
{
    Console.WriteLine($"\nYour matrix:");
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            Console.Write($"{matrix[i, j]} ");
        }
        Console.WriteLine();
    }
}

void AverageOfColumnsElements(int[,] matrix)
{
    double[] averagesOfColumns = new double[matrix.GetLength(1)];
    Console.Write("\nAverages of every column: ");
    for (int i = 0; i < matrix.GetLength(1); i++)
    {
        averagesOfColumns[i] = 0;
        for (int j = 0; j < matrix.GetLength(0); j++)
        {
            averagesOfColumns[i] = averagesOfColumns[i] + matrix[j, i];
        }
        averagesOfColumns[i] = Math.Round(averagesOfColumns[i] / matrix.GetLength(0), 2);
        if (i + 1 != matrix.GetLength(1))
        {
            Console.Write($"{averagesOfColumns[i]}, ");
        }
        else
        {
            Console.Write($"{averagesOfColumns[i]}.\n");
        }
    }
    return;
}

int rows = GetNumber("Enter the number of rows:");
int columns = GetNumber("Enter the number of columns:");

int[,] matrix = InitMatrix(rows, columns);

PrintArray(matrix);

AverageOfColumnsElements(matrix);

