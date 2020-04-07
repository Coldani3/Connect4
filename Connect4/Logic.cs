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
        public Connect4Colour CurrPlayerColour = Connect4Colour.Red;
        public static bool GameInProgress = true;

        public Logic()
        {
            StartNewGame();
        }

        public void StartNewGame()
        {
            InitGrid();
        }

        private void InitGrid()
        {
            for (int i = 0; i < Columns; i++)
            {
                ConnectFourGrid[i] = new Connect4Colour[Rows];
            }
        }

        public void HandleInput(ConsoleKeyInfo info)
        {
            if (Char.IsNumber(info.KeyChar))
            {
                int key = Int32.Parse(info.KeyChar.ToString());

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
            if (index <= Columns)
            {
                Connect4Colour[] column = ConnectFourGrid[index - 1];
                int columnCount = column.Count(x => x != null);

                if (columnCount < Rows)
                {
                    column[Utillity.Clamp(columnCount, 0, Rows)] = CurrPlayerColour;
                    //check if there are matches whenever a dot drops
                    LookForFourInARow(index - 1, columnCount - 2);

                    //swap colour 
                    if (CurrPlayerColour == Connect4Colour.Red) CurrPlayerColour = Connect4Colour.Yellow;
                    else CurrPlayerColour = Connect4Colour.Red;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gridX">0 index X coordinate</param>
        /// <param name="gridY">0 index Y coordinate</param>
        public void LookForFourInARow(int gridX, int gridY)
        {
            Func<int, int> increment = (val) => val++;
            Func<int, int> decrement = (val) => val--;
            Func<int, int> same = (val) => val;

            //If you want to know why I'm doing it with lambdas and stuff, I was too lazy to write out the same code 4 times but for different directions.
            //Also DRY is a thing and you should definitely try to follow that when you can
            
            if (IsFourInARowForDir(gridX, gridY, increment, increment) || //diagonal bottom to top
                IsFourInARowForDir(gridX, gridY, increment, decrement) || //diagonal top to bottom
                IsFourInARowForDir(gridX, gridY, increment, same) || //horizontal
                IsFourInARowForDir(gridX, gridY, same, decrement)) //vertical
            {
                //they got a four in a row
                PlayerWon(CurrPlayerColour);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="directionNavigationFuncX">A lambda that specifies how the x of the dot we are checking changes every check</param>
        /// <param name="directionNavigationFuncY">A lambda that specifies how the y of the dot we are checking changes every check</param>
        /// <returns>True if a match was found</returns>
        private bool IsFourInARowForDir(int gridX, int gridY, Func<int, int> directionNavigationFuncX, Func<int, int> directionNavigationFuncY)
        {
            bool fourInARowFound = false;
            int matchCount = 0;

            int min = Utillity.Clamp(gridX, 0, Rows - 1);

            for (int x = Utillity.Clamp(gridX, 0, Rows - 1); x < Utillity.Clamp(gridX, 0, Rows - 1); x = directionNavigationFuncX(x))
            {
                for (int y = Utillity.Clamp(gridY, 0, Columns - 1); y < Utillity.Clamp(gridY, 0, Columns - 1); y = directionNavigationFuncY(y))
                {
                    if (ConnectFourGrid[x][y] == CurrPlayerColour) matchCount++;
                    else matchCount = 0;
                }
            }

            fourInARowFound = matchCount >= 4;
            return fourInARowFound;
        }

        public void PlayerWon(Connect4Colour winner)
        {
            Logic.GameInProgress = false;
        }

        //object so I can keep the console color stored in the value instead of using a dictionary
        public class Connect4Colour
        {
            public static Connect4Colour Red = new Connect4Colour(ConsoleColor.Red, "Red");
            public static Connect4Colour Yellow = new Connect4Colour(ConsoleColor.Yellow, "Yellow");

            public ConsoleColor Colour;
            public string ColourName;

            public Connect4Colour(ConsoleColor colour, string colourName)
            {
                this.Colour = colour;
                this.ColourName = colourName;
            }
        }
    }
}
