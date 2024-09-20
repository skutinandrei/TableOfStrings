using System.Linq.Expressions;

namespace TableOfStrings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WriteTable();
        }

        static void WriteTable()
        {
            int n;
            string s;

            Console.WriteLine("Введите n");
            n = Convert.ToInt32(Console.ReadLine());

            while (n < 1 || n > 6)
            {
                Console.WriteLine("Введите число от 1 до 6:");
                n = Convert.ToInt32(Console.ReadLine());
            }

            Console.WriteLine("Введите текст:");
            s = Console.ReadLine();
            while (string.IsNullOrEmpty(s))
            {
                Console.WriteLine("Текст не может быть пустым. Введите текст еще раз:");
                s = Console.ReadLine();
            }

            int width = (n - 1) + (n - 1) + s.Length;
            int height = (n - 1) + (n - 1) + 1;

            string horizontalBorder = "";
            for (int i = 0; i < width + 2; i++)
            {
                horizontalBorder += "+";
            }

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(horizontalBorder);
                switch (i)
                {
                    case 0:
                        WriteLineWithString(n, width, s);
                        break;
                    case 1:
                        WriteLineInChessOrder(width, height);
                        break;
                    case 2:
                        WriteLineWithCross(width);
                        Console.WriteLine(horizontalBorder);
                        break;
                }
            }
        }

        static void WriteLineWithString(int n, int width, string s)
        {
            string line = "";
            for (int i = 0; i < (n - 1) + (n - 1) + 1; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (i == n - 1 && j == n - 1)
                    {
                        line += s;
                        j += s.Length - 1;
                    }
                    else
                    {
                        line += " ";
                    }
                }
                Console.Write("+");
                Console.Write(line);
                Console.Write("+");
                Console.WriteLine();
                line = "";
            }
        }

        static void WriteLineInChessOrder(int width, int height)
        {
            string chessLine = "";

            for (int i = 0; i < height; i++)
            {
                Console.Write("+");
                for (int j = 0; j < width; j++)
                {
                    chessLine += ((i + j) % 2 == 0 ? '+' : ' ');
                }
                Console.Write(chessLine);
                Console.Write("+");
                chessLine = "";
                Console.WriteLine();
            }
        }

        static void WriteLineWithCross(int width)
        {
            string crossLine = "";
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (i == j || i + j == width - 1)
                    {
                        crossLine += "+";
                    }
                    else
                    {
                        crossLine += " ";
                    }
                }
                Console.Write("+");
                Console.Write(crossLine);
                Console.Write("+");
                crossLine = "";
                Console.WriteLine();
            }
        }
    }
}
