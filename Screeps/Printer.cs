using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Screeps
{
    class Printer
    {
        //int xClear,int yClear
        public void print(Object printing,int xPrint,int yPrint)
        {
            char output =' ';
            //Console.SetCursorPosition(xClear, yClear);
           // Console.WriteLine(output);
            if(printing.GetType() == typeof(Miner))
            {
                output = 'M';
            }
            if (printing.GetType() == typeof(Lumberjack))
            {
                output = 'L';
                
            }
            else if (printing.GetType() == typeof(EnergyCollector))
            {
                output = 'E';

            }
            else if (printing.GetType() == typeof(Mine))
            {
                output = 'П';
            }
            else if (printing.GetType() == typeof(Tree))
            {
                output = '|';

            }
            else if (printing.GetType() == typeof(Energy))
            {
                output = '*';

            }
            else if (printing.GetType() == typeof(Spawner))
            {
                output = '0';

            }
            Console.SetCursorPosition(xPrint, yPrint);
            Console.Write(output);
        }

    }
}
