using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect4
{
    public class Logic
    {
        public Connect4Colour[,] ConnectFourGrid = new Connect4Colour[7,6];

        public Logic()
        {

        }

        public void Tick()
        {

        }

        public void HandleInput(ConsoleKeyInfo info)
        {
            if (Char.IsNumber(info.KeyChar))
            {
                int key = Convert.ToInt32(info.KeyChar);

                if (key >= 1 && key <= 7)
                {
                    DropDot(key);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index">1-7, the horizontal left to right coordinate of the hole to "drop" it into.</param>
        public void DropDot(int index)
        {

        }

        public class Connect4Colour
        {
            public static Connect4Colour Red = new Connect4Colour(ConsoleColor.Red);
            public static Connect4Colour Yellow = new Connect4Colour(ConsoleColor.Yellow);

            public ConsoleColor Colour;

            public Connect4Colour(ConsoleColor colour)
            {
                this.Colour = colour;
            }
        }
    }
}
