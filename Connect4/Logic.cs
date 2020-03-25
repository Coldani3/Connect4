using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect4
{
    public class Logic
    {
        public const int Columns = 7;
        public const int Rows = 6;
        public Connect4Colour[][] ConnectFourGrid = new Connect4Colour[Columns][];
        public Connect4Colour PlayerTurn = Connect4Colour.Red;

        public Logic()
        {
            InitGrid();
        }

        private void InitGrid()
        {
            for (int i = 0; i < 7; i++)
            {
                ConnectFourGrid[i] = new Connect4Colour[6];
            }
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
        /// The equivalent of dropping one of the dots into the frame
        /// </summary>
        /// <param name="index">1-7, the horizontal left to right coordinate of the hole to "drop" it into.</param>
        public void DropDot(int index)
        {
            if (index - 1 <= Columns)
            {
                Connect4Colour[] column = ConnectFourGrid[index - 1];

                if (column.Length < Rows)
                {
                    column[column.Length - 1] = PlayerTurn;
                    //check if there are matches whenever a dot drops
                    LookForFourInARow(index - 1, column.Length - 2);

                    //swap colour 
                    if (PlayerTurn == Connect4Colour.Red) PlayerTurn = Connect4Colour.Yellow;
                    else PlayerTurn = Connect4Colour.Red;
                }
            }
        }

        public void LookForFourInARow(int gridX, int gridY)
        {
            //check the straight directions

            //check the diagonal directions
        }

        //object so I can keep the console color stored in the value instead of using a dictionary
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
