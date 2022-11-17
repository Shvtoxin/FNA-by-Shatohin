using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FNAshato
{
    public static class Game
    {
            static void Main(string[] args)
            {
                using (Solution Snowfall = new Solution())
                {
                 Snowfall.Run();
                }
            }
    }
}

