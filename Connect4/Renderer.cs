using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect4
{
    public class Renderer
    {
        //Starts are always the lower left corner of the box
        //Grid does not refer to the frame the dots sit in
        public static int ConnectFourGridStartX = (int) ((Program.WindowWidth / 2) - (Math.Ceiling((float)Logic.Columns / 2)));
        public static int ConnectFourGridStartY = (int) ((Program.WindowHeight / 2) - (Math.Ceiling((float)Logic.Rows / 2)));
        public static int ConnectFourFrameHeight = Logic.Rows + 2;
        public static int ConnectFourFrameWidth = Logic.Columns + 2;
        public static char FrameSide = '|';

        /// <summary>
        /// Executed as main render loop
        /// </summary>
        public void Render()
        {
            while (Program.Running)
            {
                if (Logic.GameInProgress)
                {
                    //draw grid
                    DrawConnectFourFrame();
                    DrawConnectFourDots();
                }

                if (Logic.GameWon)
                {
                    Console.Clear();
                    DrawPlayerWin();
                    Program.Running = false;
                }

            }
        }

        /// <summary>
        /// Draws the outline of the grid itself. Think of the frame from the real world equivalent game.
        /// </summary>
        public void DrawConnectFourFrame()
        {
            //TODO
            //draw side lines
            for (int y = ConnectFourGridStartY; y < ConnectFourGridStartY + ConnectFourFrameHeight - 1; y++)
            {
                DrawChar(ConnectFourGridStartX - 1, y, FrameSide);
                DrawChar(ConnectFourGridStartX + ConnectFourFrameWidth - 2, y, FrameSide);

                DrawPlayerTurn();
            }

            //draw bottom line
            for (int bottomLineX = ConnectFourGridStartX - 1; bottomLineX < ConnectFourGridStartX + ConnectFourFrameWidth - 1; bottomLineX++)
            {
                DrawChar(bottomLineX, ConnectFourGridStartY - 1, '-');
            }
        }

        public void DrawPlayerTurn()
        {
            Logic.Connect4Colour player = Program.GameLogic.CurrPlayerColour;
            //Spaces save me having to erase previous player turn text
            string message = $"          {player.ColourName}'s turn          ";

            DrawColouredString((int)((Program.WindowWidth / 2) - Math.Round((float)(message.Length / 2))), Program.WindowHeight - 4, message, player.Colour);
        }

        public void DrawPlayerWin()
        {
            Logic.Connect4Colour player = Program.GameLogic.CurrPlayerColour;
            string message = $"Player {player.ColourName} won!";

            DrawColouredString((int)((Program.WindowWidth / 2) - Math.Round((float)(message.Length / 2))), Program.WindowHeight / 2, message, player.Colour);
        }

        public static int GameYToScreenY(int gameY)
        {
            return Console.WindowHeight - gameY;
        }

        public void DrawConnectFourDot(int gridX, int gridY, Logic.Connect4Colour colour)
        {
            ConsoleColor prevColour = Console.ForegroundColor;
            Console.ForegroundColor = colour.Colour;
            DrawChar(gridX + ConnectFourGridStartX, gridY + ConnectFourGridStartY, 'O');

            Console.ForegroundColor = prevColour;
        }

        /// <summary>
        /// Draws the grid of dots themselves.
        /// </summary>
        public void DrawConnectFourDots()
        {
            Logic logic = Program.GameLogic;

            for (int i = 0; i < Logic.Columns; i++)
            {
                for (int i2 = 0; i2 < Logic.Rows; i2++)
                {
                    if (logic.ConnectFourGrid[i][i2] != null)
                    {
                        this.DrawConnectFourDot(i, i2, logic.ConnectFourGrid[i][i2]);
                    }
                }
            }
        }

        public void DrawChar(int gameX, int gameY, char character)
        {
            //Console.SetCursorPosition(gameX, GameYToScreenY(gameY));
            //Console.Write(character);
            DrawString(gameX, gameY, character.ToString());
        }

        public void DrawString(int gameX, int gameY, string message)
        {
            Console.SetCursorPosition(gameX, GameYToScreenY(gameY));
            Console.Write(message);
        }

        public void DrawColouredString(int gameX, int gameY, string message, ConsoleColor consoleColour, bool switchToPrevColour = true)
        {
            ConsoleColor prevColour = Console.ForegroundColor;
            Console.ForegroundColor = consoleColour;

            DrawString(gameX, gameY, message);

            if (switchToPrevColour) Console.ForegroundColor = prevColour;
        }
    }
}
