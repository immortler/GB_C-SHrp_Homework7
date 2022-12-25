/* Задача 50. 
Напишите программу, которая на вход принимает позиции элемента в двумерном массиве, и возвращает значение этого элемента или же указание, что такого элемента нет.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4

17 -> такого числа в массиве нет  */

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

int[,] InitRandomMatrix(int rows, int columns)
{
    int[,] matrix = new int[rows, columns];
    Random rnd = new Random();

    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            matrix[i, j] = rnd.Next(1, 100);
        }
    }

    return matrix;
}

void PrintArray(string message, int[,] matrix)
{
    Console.WriteLine(message);
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            Console.Write($"{matrix[i, j]} ");
        }

        Console.WriteLine();
    }
}

void SearchElement(int rows, int columns, int x, int y, int[,] matrix)
{
    if (x <= matrix.GetLength(0) && y <= matrix.GetLength(1))
    {
        PrintArray($"\nYour random matrix with {rows} rows and {columns} columns:", matrix);
        Console.WriteLine($"Element of row {x}, column {y} is {matrix[x - 1, y - 1]}.");
    }
    else
    {
        Console.WriteLine("\nError: entered coordinates are outside the matrix.");
    }
    return;
}

int rows = GetNumber("Enter the number of rows:");
int columns = GetNumber("Enter the number of columns:");

int[,] matrix = InitRandomMatrix(rows, columns);

int x = GetNumber("Enter the row of your element:");
int y = GetNumber("Enter the column of your element:");

SearchElement(rows, columns, x, y, matrix);