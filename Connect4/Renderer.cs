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
            }
        }

        /// <summary>
        /// Draws the outline of the grid itself. Think of the frame from the real world equivalent game.
        /// </summary>
        public void DrawConnectFourFrame()
        {
            //TODO
            //draw side lines
            for (int y = ConnectFourGridStartY - 1; y < ConnectFourGridStartY + ConnectFourFrameHeight; y++)
            {
                DrawChar(ConnectFourGridStartX - 1, y, FrameSide);
                DrawChar(ConnectFourGridStartX + ConnectFourFrameWidth + 1, y, FrameSide);
            }

            //draw bottom line
            for (int bottomLineX = ConnectFourGridStartX; bottomLineX < ConnectFourGridStartX + ConnectFourFrameWidth; bottomLineX++)
            {
                DrawChar(bottomLineX, ConnectFourGridStartY - 1, '-');
            }
        }

        public void DrawPlayerWin(string playerName)
        {
            Console.Clear();
            string message = $"Player {playerName} won!";
            DrawString((int) ((Program.WindowWidth / 2) - Math.Round((float) (message.Length / 2))), Program.WindowHeight / 2, message);
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
    }
}
