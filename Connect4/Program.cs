using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Connect4
{
    class Program
    {
        /// <summary>
        /// Ticks per second
        /// </summary>
        public static int FrameRate = 20;
        public static bool Running = true;
        public static Logic GameLogic = new Logic();
        public static Renderer GameRenderer = new Renderer();
        public const int WindowWidth = 60;
        public const int WindowHeight = 20;

        static void Main(string[] args)
        {
            Console.SetWindowSize(WindowWidth, WindowHeight);
            Console.CursorVisible = false;
         
            Task inputThread = new Task(() => InputThread());
            inputThread.Start();

            while (Running)
            {
                GameRenderer.Render();
                Thread.Sleep(1000 / FrameRate);

                if (Logic.GameInProgress) Console.Clear();
            }

            Console.ReadKey(true);
        }

        public static void InputThread()
        {
            while (Running)
            {
                GameLogic.HandleInput(Console.ReadKey(true));
                //sleep so we don't accidentally put 10 dots in the same column from one key press
                Thread.Sleep(100);
            }
        }
    }
}
