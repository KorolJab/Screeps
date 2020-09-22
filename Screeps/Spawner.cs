using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Screeps
{
    class Spawner
    {
        public int wood;
        public int stone;
        public int energy;
        public int SpawnerX;
        public int SpawnerY;
        public void takeStone(int taken)
        {
            stone += taken;
        }
        public void SpawnCreep()
        {
        }
    }
}