using System;

namespace Exercise_5
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                int n;

                Console.WriteLine("Введите порядок матрицы:");
                while (true)
                {
                    if (int.TryParse(Console.ReadLine(), out n) && n > 0)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Введены некорректные данные. Повторите ввод:");
                    }
                }

                double[][] matrx = new double[n][];
                for (int i = 0; i < n; i++)
                {
                    while (true)
                    {
                        Console.WriteLine($"Введите строку №{i + 1} (через пробел):");
                        string strLine = Console.ReadLine();
                        if (TryGetLine(strLine, n, out double[] numbers))
                        {
                            matrx[i] = numbers;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Введены некорректные данные.");
                        }
                    }
                }

                Console.WriteLine("Получена последовательность: ");
                for (int i = 0; i < matrx.Length; i++)
                {
                    bool isNegative = false;
                    for (int j = 0; j < matrx[i].Length; j++)
                    {
                        if (matrx[i][j] < 0)
                        {
                            isNegative = true;
                            break;
                        }
                    }

                    if (isNegative)
                        Console.Write(1 + " ");
                    else
                        Console.Write(0 + " ");
                }
                Console.WriteLine();
            }
        }
        static bool TryGetLine(string str, int n, out double[] lineNum)
        {
            string[] strNum = str.Split(' ');

            if (strNum.Length != n)
            {
                lineNum = null;
                return false;
            }

            lineNum = new double[strNum.Length];

            for (int i = 0; i < strNum.Length; i++)
            {
                double num;
                if (double.TryParse(strNum[i], out num))
                {
                    lineNum[i] = num;
                }
                else
                {
                    lineNum = null;
                    return false;
                }
            }
            return true;
        }
    }
}
