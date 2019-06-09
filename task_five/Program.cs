using System;

namespace task_five
{
    class Program
    {
        static Random rand = new Random();
        static void Main(string[] args)
        {
            Console.WriteLine(@"    ~~~ЗАДАНИЕ МАТРИЦЫ~~~
1. Задать матрицу вручную.
2. Задать матрицу рандомно.");
            int option = MenuOption();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nВведите порядок матрицы:");
            Console.ResetColor();
            int n = EnterAnInteger();
            double[,] matrix = new double[n, n];

            switch (option)
            {
                case 1:
                    matrix = MatrixRead(matrix);
                    Console.Clear();
                    break;
                case 2:
                    matrix = MatrixRandom(matrix);
                    Console.Clear();
                    break;
            }
            ShowMatrix(matrix);
            Console.WriteLine("\n\nСумма элементов выше главной диагонали:   " + SumOverMainDiagonal(matrix));
            Console.WriteLine("Сумма элементов на главной диагонали:   " + SumOnMainDiagonal(matrix));
            Console.WriteLine("Сумма элементов ниже главной диагонали:   " + SumBelowMaindDiagonal(matrix));
            Console.ReadLine();
        }

        static double[,] MatrixRead(double[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                    matrix[i, j] = EnterARealNumber();
            return matrix;
        }

        static double[,] MatrixRandom(double[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(0); j++)
                    matrix[i, j] = (double)rand.Next(-1000, 1000) / 10;
            return matrix;
        }

        static double SumOverMainDiagonal(double[,] m)
        {
            double sum = 0;
            for (int i = 0; i < m.GetLength(0); i++)
                if (m[i, 0] < 0)
                {
                    for (int j = 0; j < m.GetLength(1); j++)
                        if (i < j) sum += m[i, j];
                }
            return sum;
        }

        static double SumOnMainDiagonal(double[,] m)
        {
            double sum = 0;
            for (int i = 0; i < m.GetLength(0); i++)
                if (m[i, 0] < 0)
                {
                    for (int j = 0; j < m.GetLength(1); j++)
                        if (i == j) sum += m[i, j];
                }
            return sum;
        }

        static double SumBelowMaindDiagonal(double[,] m)
        {
            double sum = 0;
            for (int i = 0; i < m.GetLength(0); i++)
                if (m[i, 0] < 0)
                {
                    for (int j = 0; j < m.GetLength(1); j++)
                        if (i > j) sum += m[i, j];
                }
            return sum;
        }

        static int MenuOption()
        {
            int option = 0;
            bool alright = false;
            do
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("Пункт:    ");
                Console.ResetColor();
                try
                {
                    option = Convert.ToInt32(Console.ReadLine());
                    if (option < 1 || option > 2) ErrorInMenu();
                    else alright = true;
                }
                catch (FormatException)
                {
                    ErrorInMenu();
                    alright = false;
                }
            } while (!alright);

            return option;
        }

        static void ErrorInMenu()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Выберите пункт меню!");
            Console.ResetColor();
        }

        static double EnterARealNumber() //ввод дробного числа
        {
            bool ok = false;
            double number = 0;
            do
            {
                Console.Write("Введите число:   ");
                try
                {
                    number = Convert.ToDouble(Console.ReadLine());
                    ok = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Введите число!");
                }
            } while (!ok);
            return number;
        }

        static int EnterAnInteger() //ввод целого числа
        {
            bool ok = false;
            int number = 0;
            do
            {
                Console.Write("Ввод:   ");
                try
                {
                    number = Convert.ToInt32(Console.ReadLine());
                    if (number <= 0) Console.WriteLine("Введите положительное число!");
                    else ok = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Введите целое число!");
                }
            } while (!ok);
            return number;
        }

        static void ShowMatrix(double[,] m)
        {
            for (int i = 0; i < m.GetLength(0); i++)
            {
                for (int j = 0; j < m.GetLength(1); j++)
                    if (i == j)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(m[i, j] + "   ");
                        Console.ResetColor();
                    }
                    else Console.Write(m[i, j] + "   ");
                Console.WriteLine();
            }
        }
    }
}
