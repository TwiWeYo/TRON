using System;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Study
{
    public class Player
    {
        private int locX, locY;
        private int dirX, dirY;
        public bool IsAlive { get; private set; } = true;
        private ConsoleKey leftKey, rightKey;
        
        public ConsoleColor Color { get; private set; }
        
        public Player(int x, int y, int dY, ConsoleColor c)
        {
            locX = x; locY = y;
            dirY = dY;
            dirX = 0;
            Color = c;
            leftKey = ConsoleKey.A;
            rightKey = ConsoleKey.D;
            
        }
        //Перегруженный конструктор с назначением клавиш для игрока
        public Player(int x, int y, int dY, ConsoleColor c, ConsoleKey left, ConsoleKey right )
        {
            locX = x; locY = y;
            dirY = dY;
            dirX = 0;
            Color = c;
            leftKey = left;
            rightKey = right;
        }
        //Метод, возвращающий текущую позицию игрока
        public int[] GetLocation()
        {
            int[] GetLocation = new int[] { locX, locY };
            return GetLocation;
        }

        //Осуществление поворота при нажатии клавиши
        public void KeyPress(ConsoleKeyInfo turnKey)
        {
            if (turnKey.Key == leftKey) this.ChangeDirection(-1);
            else if (turnKey.Key == rightKey) this.ChangeDirection(1);
        }
        //Метод, проверяющий по какой оси движется игрок
        private void ChangeDirection(int turn)
        { 

                if (dirX == 0)
                {
                    dirX = -1 * turn * dirY;
                    dirY = 0;
                }
                else
                {
                    dirY = 1 * turn * dirX;
                    dirX = 0;
                }
        }
        //Проверка следуюшего хода на доступность
        private bool isNextMove(Field f)
        {
            if (locX + dirX < 0 || locY + dirY < 0) return false;
            else if (locX + dirX >= f.Size || locY + dirY >= f.Size) return false;
            else return !f.isSpaceTaken(locX + dirX, locY + dirY);
        }
        public void Move(Field f)
        {
            if (isNextMove(f))
            {
                locX += dirX;
                locY += dirY;
                //Изменение цвета участка поля на цвет игрока
                f.SetColor(locX, locY, Color);
            }

            else IsAlive = false;
        }
    }
}
