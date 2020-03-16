using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect4
{
    class Program
    {
        /// <summary>
        /// Ticks per second
        /// </summary>
        public static int TickRate = 20;

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

        }

        public static void BeginLogic()
        {

        }

        public static void InputThread()
        {

        }
    }
}
