using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;

namespace Barley_break
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] returnInt = FileReader.ReadFromFile("C:\\Users\\Kiril\\OneDrive\\Документы\\Visual Studio 2015\\Projects\\Barley_break\\txt.txt");

            Console.Write("\tХотите ли вы сыграть? \n\t если да наберите Y \n\t если нет то любую клавишу = ");
            while (Convert.ToString(Console.ReadLine()) == "Y")
            {
                ClassGameThird game3 = new ClassGameThird(1, 2, 3, 4, 0, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15);

                Console.Clear();
                PrintGameField.MethodWhichPrintGameField(game3);

                while (!game3.CheckWin())
                {
                    StartGame(game3);
                }
                //Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Вы выиграли!");
                Console.Write("Если вы хотите сыграть еще раз, намите Y = ");
            }

            Console.ReadKey();
        }

        static void StartGame(ClassGameThird game3)
        {
            int count = game3.help.Length;

            Console.Write("\t\tВведите значение, которое хотите поменять = ");
            int moveValue = Convert.ToInt32(Console.ReadLine());
            Console.Clear(); PrintGameField.MethodWhichPrintGameField(game3);

            if (game3.Shift(moveValue))
            {
                Console.Clear(); PrintGameField.MethodWhichPrintGameField(game3);
                int[] help = game3.returnHelp();
                for (int i = help.Length;  0 < i; i--)
                {
                    if (i == 4) { Console.Write("Перемещение было из {0}", help[--count]); }
                    if (i == 3) { Console.Write(",{0}", help[--count]); }
                    if (i == 2) { Console.Write(" в {0}", help[--count]); }
                    if (i == 1) { Console.Write(",{0}", help[--count]); };
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("\t\tНекорректные данные!!!");
            }
        }
    }
}