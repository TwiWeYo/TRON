using Microsoft.VisualBasic;
using System;
using System.Threading;

namespace Study
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                String s;
                //Создание игрового поля и игроков
                Field game = new Field(30);
                Player p1 = new Player(4, 0, 1, ConsoleColor.Blue);
                Player p2 = new Player(25, 29, -1, ConsoleColor.Red, ConsoleKey.LeftArrow, ConsoleKey.RightArrow);

                game.SetColor(p1.GetLocation()[0], p1.GetLocation()[1], p1.Color);
                game.SetColor(p2.GetLocation()[0], p2.GetLocation()[1], p2.Color);

                int centerX = (Console.WindowWidth / 2) - 11;
                int centerY = (Console.WindowHeight / 2);
                Console.SetCursorPosition(centerX, centerY);
                Console.WriteLine("Пресс Эни кей ту старт");
                Console.ReadKey();
                
                while (p1.IsAlive && p2.IsAlive)
                {
                    game.DrawField(p1.GetLocation(), p2.GetLocation());

                    //Проверка на нажатие клавиши
                    if (Console.KeyAvailable)
                    {
                        ConsoleKeyInfo key = Console.ReadKey();
                        p1.KeyPress(key);
                        p2.KeyPress(key);
                    }
                    else Thread.Sleep(500);

                    p1.Move(game);
                    p2.Move(game);

                }
                Thread.Sleep(1500);
                Console.Clear();

                if (p1.IsAlive)
                {
                    Console.ForegroundColor = p1.Color;
                    s = "Плауэр 1 уинс";
                }

                else
                {
                    Console.ForegroundColor = p2.Color;
                    s = "Плауэр 2 уинс";
                }
                centerX = (Console.WindowWidth / 2) - (s.Length / 2);
                centerY = (Console.WindowHeight / 2) - 1;
                Console.SetCursorPosition(centerX, centerY);
                Console.WriteLine(s);
                Console.ResetColor();
            }
        }
    }
}
