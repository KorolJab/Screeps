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
        public point pozition;
        List<point> points = new List<point>();
        public point Coords;
       // public Resources(int x,int y) 
       //{
       //     Coords = new point(x, y);
       //     nearbyPoints(x,y);
       //}
      public void nearbyPoints(int x,int y)
        {
            //1
            points.Add(new point(x,y-1));
            //2
            points.Add(new point(x,y+1));
            //3
            points.Add(new point(x+1,y));
            //4
            points.Add(new point(x-1,y));
            //5
            points.Add(new point(x+1 ,y+1));
            //6
            points.Add(new point(x-1, y+1));
            //7
            points.Add(new point(x-1, y-1));
            //8
            points.Add(new point(x-1, y+1));
        }
    }
}
