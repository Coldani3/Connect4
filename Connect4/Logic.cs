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

        public static bool GameWon = false;

        public Logic()
        {
            StartNewGame();
        }

        public void StartNewGame()
        {
            InitGrid();
            GameInProgress = true;
            GameWon = false;
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

                if (key >= 1 && key <= 7 && Logic.GameInProgress)
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
            if (index <= Columns && index >= 1)
            {
                Connect4Colour[] column = ConnectFourGrid[index - 1];
                int columnCount = column.Count(x => x != null);

                if (columnCount < Rows)
                {
                    column[Utillity.Clamp(columnCount, 0, Rows)] = CurrPlayerColour;
                    //check if there are matches whenever a dot drops
                    LookForFourInARow(index - 1, columnCount);

                    if (!GameWon)
                    {
                        //swap colour 
                        if (CurrPlayerColour == Connect4Colour.Red) CurrPlayerColour = Connect4Colour.Yellow;
                        else CurrPlayerColour = Connect4Colour.Red;
                    }
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
            bool matchFound = false;
            int count = 0;

            do
            {
                //row
                for (int i = -(gridX > 2 ? 3 : gridX) /*Gets minus gridX when it is less than 3 or minus 3 otherwise*/; 
                    i < 3 && (gridX + i) < Columns; i++)
                {
                    //gridX + -3 is 3 to the left of gridX, or where we want to start checking
                    if (ConnectFourGrid[gridX + i][gridY] == CurrPlayerColour) count++;
                    else count = 0;

                    if (count >= 4)
                    {
                        matchFound = true;
                        break;
                    }
                }

                count = 0;

                //column
                for (int i = -(gridY > 2 ? 3 : gridY); i < 3 && (gridY + i) < Rows; i++)
                {
                    if (ConnectFourGrid[gridX][gridY + i] == CurrPlayerColour) count++;
                    else count = 0;

                    if (count >= 4)
                    {
                        matchFound = true;
                        break;
                    }
                }

                //Diagonals
                count = 0;

                int i2 = -(gridY > 2 ? 3 : gridY);

                for (int i = -(gridX > 2 ? 3 : 0); i < 3 && (gridX + i) < Columns; i++)
                {
                    if (ConnectFourGrid[gridX + i][gridY + i2] == CurrPlayerColour) count++;
                    else count = 0;

                    if (count >= 4)
                    {
                        matchFound = true;
                        break;
                    }

                    i2++;
                    if (gridY + i2 > Columns) break;
                }

                count = 0;

                i2 = -(gridY > 2 ? 3 : gridY);

                for (int i = -(gridX > 2 ? 3 : gridX); i < 3 && (gridX + i) < Columns; i++)
                {
                    if (gridX - i >= 0 && gridY - i2 >= 0)
                    {
                        if (ConnectFourGrid[gridX + i][gridY + i2] == CurrPlayerColour) count++;
                        else count = 0;
                    }

                    if (count >= 4) matchFound = true;

                    i2++;

                    if (gridY + i2 > Columns) break;
                }

            }
            while (false);

            if (matchFound) PlayerWon();
        }

        private bool IsFourInARowForDir(int gridX, int gridY, int xChange, int yChange)
        {
            int matchCount = 0;
            
            int xUpperBound = Utillity.Clamp(gridX + (3 * xChange), 0, Columns - 1);
            int yUpperBound = Utillity.Clamp(gridY + (3 * yChange), 0, Rows - 1);
            //yes it's hacky
            //no i don't care, it works
            bool xRan = false;
            bool yRan = false;
            bool skipOne = false;

            for (int x = Utillity.Clamp(gridX - (3 * xChange), 0, Columns - 1); x <= xUpperBound && !xRan; x += xChange)
            {
                for (int y = Utillity.Clamp(gridY - (3 * yChange), 0, Rows - 1); y <= yUpperBound && !yRan; y += yChange)
                {
                    if (ConnectFourGrid[x][y] == CurrPlayerColour)
                    {
                        matchCount++;

                        if (matchCount >= 4) return true;
                    }
                    else matchCount = 0;

                    if (yChange == 0)
                    {
                        yRan = true;
                        skipOne = true;
                    }
                }

                if (xChange == 0) xRan = true;
                if (skipOne) continue;

                if (yChange == 0)
                {
                    if (ConnectFourGrid[x][gridY] == CurrPlayerColour)
                    {
                        matchCount++;

                        if (matchCount >= 4) return true;
                    }
                    else matchCount = 0;
                }
            }

            return false;

        }

        public void PlayerWon()
        {
            GameInProgress = false;
            GameWon = true;
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
