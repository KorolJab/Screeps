﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Screeps
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            
            while(true)
            {
                System.Threading.Thread.Sleep(0);
                game.Turn();

            }
        }
    }
}
