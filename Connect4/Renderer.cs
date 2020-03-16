using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect4
{
    public class Renderer
    {
        public static int ConnectFourGridStartX = 0;
        public static int ConnectFourGridStartY = 0;

        /// <summary>
        /// Executed as main render loop
        /// </summary>
        public void Render()
        {

        }

        /// <summary>
        /// Draws the grid of dots themselves.
        /// </summary>
        public void DrawConnectFourGrid()
        {
            //TODO
        }

        /// <summary>
        /// Draws the outline of the grid itself. Think of the frame from the real world equivalent game.
        /// </summary>
        public void DrawConnectFourFrame()
        {
            //TODO
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
            //TODO
            ConsoleColor prevColour = Console.ForegroundColor;
            Console.ForegroundColor = colour.Colour;
            //draw stuff

            Console.ForegroundColor = prevColour;

        }
    }
}
