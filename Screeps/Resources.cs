using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Screeps
{
    class Resources
    {

        public int Hp;

        public List<point> points = new List<point>();
       

        public int giveRes(int dmg, int Hp)
        {
            int returnedRes;
            if (Hp - dmg > 0)
            {
                returnedRes = dmg;
            }
            else
            {
                returnedRes = Hp;
            }

            return returnedRes;
        }
    }
}
