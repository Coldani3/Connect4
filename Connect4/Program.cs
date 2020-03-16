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
        public static Renderer RendererLogic = new Renderer();

        static void Main(string[] args)
        {
            Task rendererThread = new Task(() => BeginRendering());
            Task logicThread = new Task(() => BeginLogic());
            Task inputThread = new Task(() => InputThread());

            rendererThread.Start();
            logicThread.Start();
            inputThread.Start();


        }

        /// <summary>
        /// Main rendering thread.
        /// </summary>
        public static void BeginRendering()
        {
            while (Running)
            {

                Thread.Sleep(1000 / TickRate);
            }
        }

        /// <summary>
        /// Thread where logic happens.
        /// </summary>
        public static void BeginLogic()
        {
            while (Running)
            {

                Thread.Sleep(1000 / TickRate);
            }
        }

        public static void InputThread()
        {
            while (Running)
            {
                GameLogic.HandleInput(Console.ReadKey(true));
            }
        }
    }
}
