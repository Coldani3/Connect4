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
        public static int TickRate = 20;
        public static bool Running = true;
        public static Logic GameLogic = new Logic();
        public static Renderer GameRenderer = new Renderer();

        static void Main(string[] args)
        {
            Task rendererThread = new Task(() => BeginRendering());
            Task inputThread = new Task(() => InputThread());

            rendererThread.Start();
            inputThread.Start();


        }

        /// <summary>
        /// Main rendering thread.
        /// </summary>
        public static void BeginRendering()
        {
            while (Running)
            {
                GameRenderer.Render();

                Thread.Sleep(1000 / TickRate);
            }
        }

        public static void InputThread()
        {
            while (Running)
            {
                GameLogic.HandleInput(Console.ReadKey(true));
                //sleep so we don't accidentally put 10 dots in the same column from one key press
                Thread.Sleep(200);
            }
        }
    }
}
