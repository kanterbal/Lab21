using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Lab21
{
    class Program
    {
        static int[,] pole;
        static int n;
        static int m;

        static void Main(string[] args)
        {
            n = Convert.ToInt32(Console.ReadLine());
            m = Convert.ToInt32(Console.ReadLine());
            pole = new int[n, m];

            ThreadStart tS1 = new ThreadStart(Sad1);
            Thread th1 = new Thread(tS1);
            ThreadStart tS2 = new ThreadStart(Sad2);
            Thread th2 = new Thread(tS2);

            th1.Start();
            th2.Start();

            th1.Join();
            th2.Join();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write($"{pole[i, j]} ");
                }
                Console.WriteLine();
            }

            Console.ReadKey();
        }
        static void Sad1()
        {

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (pole[i, j] == 0)
                        pole[i, j] = 1;
                    Thread.Sleep(1);
                }

            }
        }
        static void Sad2()
        {

            for (int i = m - 1; i > 0; i--)
            {
                for (int j = n - 1; j > 0; j--)
                {
                    if (pole[j, i] == 0)
                        pole[j, i] = 2;
                    Thread.Sleep(1);
                }

            }
        }
    }
}
