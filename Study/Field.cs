using System;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Study
{
    public class Field
    {
        public int Size { get; private set; }
        private bool[,] field;
        private ConsoleColor[,] color;
        public Field(int s)
        {
            Size = s;
            field = new bool[Size, Size];
            color = new ConsoleColor[Size, Size];
        }
        //Устанавливает цвет соответствуюшего участа поля
        public void SetColor(int x, int y, ConsoleColor c)
        {
            color[y, x] = c;
        }

        public bool isSpaceTaken(int x, int y)
        {
            return (field[y, x]);
        }

        /* Метод, который проверяет, отрисован ли игрок
         * Если игрок не отрисован, размещает игрока */

        private bool DrawPlayer(int x, int y, int[] playerLocation)
        {
            if (x == playerLocation[0] && y == playerLocation[1])
            {
                field[y, x] = true;
                Console.BackgroundColor = color[y,x];
                Console.Write("HH");
                Console.ResetColor();
                return true;
            }
            return false;
        }
        //Отрисовка поля
        public void DrawField(int[] pL1, int[] pL2)
        {
            Console.Clear();

		for (int i=0; i<Size; i++) 
		{
                for (int j = 0; j < Size; j++)
                {   //Проверка на тип участка поля
                    if (!DrawPlayer(j, i, pL1) && !DrawPlayer(j, i, pL2)) 
                    {
                         if (field[i, j])
                        {
                            Console.BackgroundColor = color[i,j];
                            Console.Write("xx");
                            Console.ResetColor();
                        }
                        else Console.Write("░░");
                    }

                }
            Console.WriteLine();
        }
	    }
    }
}
