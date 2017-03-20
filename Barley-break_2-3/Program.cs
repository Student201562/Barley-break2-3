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
            int count = 0;
            Console.Write("\tХотите ли вы сыграть? \n\t если да наберите Y \n\t если нет то любую клавишу = ");
            while (Convert.ToString(Console.ReadLine()) == "Y")
            {
                ClassGameThird game3 = new ClassGameThird(1, 2, 3, 4, 0, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15);

                Console.Clear();
                PrintGameField.MethodWhichPrintGameField(game3);

                while (!game3.CheckWin())
                {
                    Console.Write("\t\tВведите значение, которое хотите поменять = ");
                    int moveValue = Convert.ToInt32(Console.ReadLine());

                    Console.Clear();
                    if (!game3.Shift(moveValue))
                    {
                        Console.WriteLine("\t\tНекорректные данные!!!");
                    }
                    PrintGameField.MethodWhichPrintGameField(game3);

                    if (game3.SaveHistory(moveValue))
                    {
                        count = 0;
                        int[] help = game3.returnHelp();
                        foreach (var i in help)
                        {
                            if (count == 0) { Console.Write("Перемещение было из {0}", i); }
                            if (count == 1) { Console.Write(",{0}", i); }
                            if (count == 2) { Console.Write(" в {0}", i); }
                            if (count == 3) { Console.Write(",{0}", i); };
                            count++;
                        }
                        Console.WriteLine();
                    }
                }

                //Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Вы выиграли!");
                Console.Write("Если вы хотите сыграть еще раз, намите Y = ");
            }

            Console.ReadKey();
        }

        //static void StartGame(Game3 game3)
        //{
        //    while (!Game3.CheckWin(game3))
        //    {
        //        Console.Write("\t\tВведите значение, которое хотите поменять = ");
        //        int moveValue = Convert.ToInt32(Console.ReadLine());

        //        Console.Clear();
        //        if (!game3.Shift(moveValue))
        //        {
        //            Console.WriteLine("\t\tНекорректные данные!!!");
        //        }
        //        Print.PrintGameField(game3);
        //    }
        //}
    }
}