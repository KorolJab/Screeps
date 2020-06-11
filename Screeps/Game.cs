using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Threading.Tasks;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;

namespace Screeps
{
    class Game
    {
        object[,] map = new object[29, 119];
        private Mine cave = new Mine();
        private Tree forest = new Tree();
        private Energy lighting = new Energy();
        

        private int SpawnerX = 59, SpawnerY = 14;

        public point mapping;
        public Game()
        {


            map[rand.Next(119), rand.Next(29)] = new Mine();
            map[rand.Next(119), rand.Next(29)] = new Tree();
            map[rand.Next(119), rand.Next(29)] = new Energy();
            map[SpawnerX, SpawnerY] = new Spawner();
            classes = new List<Creep>() { new Miner(), new Lumberjack(), new EnergyCollector() };
            map[type[0].Coords.x, type[0].Coords.y] = type[0];
            map[type[1].Coords.x, type[1].Coords.y] = type[1];
            map[type[2].Coords.x, type[2].Coords.y] = type[2];


        }
        public void presStart()
        {
            map[SpawnerX, SpawnerY + 1] = new Miner();
            map[SpawnerX + 1, SpawnerY + 1] = new Lumberjack();
            map[SpawnerX + 1, SpawnerY + 1] = new EnergyCollector();


        }
        public void Turn()
        {
            Respawn();
            moving();
        }
        private Random rand = new Random();
        public int x;
        public int y;
        List<Resources> type;
        public List<Creep> classes;
        //шахтёр
        point pont = new point();
        //дровосекас
        point pont1 = new point();
        //электрик вася
        point pont2 = new point();
        
        private void Respawn()
            {
            for (int i = 0; i < 29; i++)
            {

                for (int j = 0; j < 119; j++)
                {
                    if (map[i, j].GetType() == cave.GetType())
                    {
                        cave = (Mine)map[i, j];
                        if(cave.Hp==0)
                        {
                            int x = rand.Next(119);
                            int y = rand.Next(29);
                            if (map[x,y ]==null)
                            {
                                map[x, y] = new Mine();

                            }
                            else
                            {
                                while(map[x, y] != null)
                                {
                                    x = rand.Next(119);
                                    y = rand.Next(29);
                                }
                                map[x, y] = new Mine();

                            }

                            map[i, j] = null;
                            
                                    
                        }
                    }
                    if (map[i, j].GetType() == cave.GetType())
                    {
                        forest = (Tree)map[i, j];
                        if (forest.Hp == 0)
                        {
                            int x = rand.Next(119);
                            int y = rand.Next(29);
                            if (map[x, y] == null)
                            {
                                map[x, y] = new Tree();

                            }
                            else
                            {
                                while (map[x, y] != null)
                                {
                                    x = rand.Next(119);
                                    y = rand.Next(29);
                                }
                                map[x, y] = new Tree();

                            }

                            map[i, j] = null;


                        }
                    }
                    if (map[i, j].GetType() == cave.GetType())
                    {
                        lighting = (Energy)map[i, j];
                        if (lighting.Hp == 0)
                        {
                            int x = rand.Next(119);
                            int y = rand.Next(29);
                            if (map[x, y] == null)
                            {
                                map[x, y] = new Energy();

                            }
                            else
                            {
                                while (map[x, y] != null)
                                {
                                    x = rand.Next(119);
                                    y = rand.Next(29);
                                }
                                map[x, y] = new Energy();

                            }

                            map[i, j] = null;


                        }
                    }
                }
            }
        }
        public void foundTarget(Creep Lexa)
        {
            int creepX=0;
            int creepY=0;
            bool flag=false;
            Resources target=null;
            if(Lexa.GetType() == typeof(Miner))
            {
                
                target = new Mine();
            }
            else if (Lexa.GetType()==typeof(Lumberjack))
            {
                target = new Tree();
            }
            else
            {
                target = new Energy();
            }
            for (int i = 0; i < 29; i++)
            {

                for (int j = 0; j < 119; j++)
                {

                    if (map[i, j].GetType() == target.GetType() )
                    {

                        creepX = i;
                        creepY = j;
                        flag = !flag;
                    }
                    if (map[i, j].GetType() == target.GetType() && flag)
                    {
                        if(Lexa.GetType() == typeof(Miner))
                        {
                            Lexa = (Miner)map[creepX, creepY];
                        } 
                           else if (Lexa.GetType() == typeof(Lumberjack))
                        {
                            Lexa = (Lumberjack)map[creepX, creepY];

                        }
                        else
                        {
                            Lexa = (EnergyCollector)map[creepX, creepY];
                             
                        }
                        Lexa.targetX = i;
                            Lexa.targetY = j;
                        map[creepX, creepY] = Lexa;
                    }
                }
            }
        }
        private void moving(Creep Misha)
        {
            bool FoundedMiner=true;
            bool FoundedMine=true;
            for(int i=0; i<29; i++)
            {
                for(int j=0;j<119;j++)
                {
                    if(Misha.GetType()==typeof(Miner))
                    {
                        if(i<Misha.targetX)
                        {
                            map[i + 1, j] = Misha;
                            map[i, j] = null;
                        }
                        else
                        {
                            map[i - 1, j] = Misha;
                            map[i, j] = null;
                        }
                    }

                    if (Misha.GetType() == typeof(Lumberjack))
                    {
                        if (i < Misha.targetX)
                        {
                            map[i + 1, j] = Misha;
                            map[i, j] = null;
                        }
                        else
                        {
                            map[i - 1, j] = Misha;
                            map[i, j] = null;
                        }
                    }

                    if (Misha.GetType() == typeof(EnergyCollector))
                    {
                        if (i < Misha.targetX)
                        {
                            map[i + 1, j] = Misha;
                            map[i, j] = null;
                        }
                        else
                        {
                            map[i - 1, j] = Misha;
                            map[i, j] = null;
                        }
                    }
                }
            }
            
            
        }
       
        public void SpawnCreep()
        {
            string num = Console.ReadLine();
            int.TryParse(num, out int number);
            //
            while(!(number<4&number>0))
            {   
                num = Console.ReadLine();
                int.TryParse(num, out number);

            }
            switch (number)
            {
                case 1:
                    {
                        classes.Add(new Miner());
                        break;
                    }
                case 2:
                    {
                        classes.Add(new Lumberjack());
                        break;
                    }
                case 3:
                    {
                        classes.Add(new EnergyCollector());
                        break;
                    }

            }

        }
        
    }
}
