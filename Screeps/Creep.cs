using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Screeps
{
    class Creep
    {
        public int creepPower;
        public int creepInventory;
        public int targetX;
        public int targetY;
        public bool reachedTargetX;
        public bool reachedTargetY;
        public bool turned;
        public Creep()
        {
            creepPower = 10;

        }
        public void setTarget(point target)
        {

            targetX = target.x;
            targetY = target.y;
        }

        public void takeRes(int resourceHp)
        {

            creepInventory += resourceHp;
        }

        public int giveResources()
        {
            int given = creepInventory;
            creepInventory = 0;
            return given;
        }
    }
}
