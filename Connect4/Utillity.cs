using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect4
{
    class Utillity
    {
        public static int ClampInt(int min, int max, int value)
        {
            return value <= min ? min : value >= max ? max : value;
        }
    }
}
