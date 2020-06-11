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
        public Creep()
        {
        }
        public void countRightWay()
        {
        }
        protected void mine(int resourceHp)
        {
            resourceHp -= creepPower;
            creepInventory = creepPower;
        }
                                      
       

        protected void giveResources()
        {
            int given = creepInventory;
            creepInventory = 0;
        }
        public void moveToResourses(point pont)
        {
            if (creepX < pont.x)
            {
                creepX++;
            }
            else
            {
                creepX--;
            }
            if (creepY < pont.y)
            {
                creepY++;
            }
            else
            {
                creepY--;

            }
        }
        public void backToHome()
        {

        }


    }
}
    