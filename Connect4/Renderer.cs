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
        public static int ConnectFourGridStartX = 0;
        public static int ConnectFourGridStartY = 0;
        public static int ConnectFourGridHeight = 20;
        public static int ConnectFourGridWidth = 10;
        public static char FrameSide = '|'

        /// <summary>
        /// Executed as main render loop
        /// </summary>
        public void Render()
        {

        }

        /// <summary>
        /// Draws the grid of dots themselves.
        /// </summary>
        public void DrawConnectFourDots()
        {
            //TODO
        }

        /// <summary>
        /// Draws the outline of the grid itself. Think of the frame from the real world equivalent game.
        /// </summary>
        public void DrawConnectFourFrame()
        {
            //TODO
            //draw side lines
            for (int y = ConnectFourGridStartY - 1; y < ConnectFourGridStartY + ConnectFourGridHeight; y++)
            {
                DrawChar(ConnectFourGridStartX - 1, y, FrameSide);
                DrawChar(ConnectFourGridStartX + ConnectFourGridWidth + 1, y, FrameSide);
            }

            //draw bottom line
            for (int bottomLineX = ConnectFourGridStartX; bottomLineX < ConnectFourGridStartX + ConnectFourGridWidth; bottomLineX++)
            {

            }
        }

        public void DrawPlayerWin(string playerName)
        {
            //TODO
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

        public void DrawChar(int gameX, int gameY, char character)
        {
            Console.SetCursorPosition(gameX, GameYToScreenY(gameY));
            Console.Write(character);
        }
    }
}
