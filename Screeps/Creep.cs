using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Screeps
{
    class Creep
    {
        protected int creepPower;
        public int creepInventory;
        public int targetX;
        public int targetY;
        public bool reachedTargetX;
        public bool reachedTargetY;
        public Creep()
        {
            
        }
        public void setTarget(point target)
        {

            targetX = target.x;
            targetY = target.y;
        }
       
        public void mine(int resourceHp)
        {
            
            creepInventory += resourceHp;
        }
        
        protected void giveResources()
        {
            int given = creepInventory;
            creepInventory = 0;
        }
    }
}
    