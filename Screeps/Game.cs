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
        public int setX;
        public int setY;
        public int printPozitionX;
        public int printPozitionY;
        private List<Type> types = new List<Type> { typeof(Miner) };
        public point targeting;
        public object[,] map;
        private Mine cave = new Mine();
        private Tree forest = new Tree();
        private Energy lighting = new Energy();
        static int xBarrier = 130;
        static int yBarrier = 50;
        public Printer risovalka;
        private int SpawnerX = 59, SpawnerY = 14;
        protected Creep someCreep;
        public point mapping;
        public Spawner creator;
        public point spawnerPoint;
        public Game()
        {
            map = new object[xBarrier, yBarrier];
            risovalka = new Printer();
            spawn();
            map[SpawnerX, SpawnerY] = new Spawner();
            spawnerPoint = new point(SpawnerX, SpawnerY);
            presStart();
           
        }
        public void presStart()
        {
            
            cave.Hp = 100;
            Miner someCreep = new Miner();
            someCreep.setTarget(foundTarget(someCreep));
            map[SpawnerX, SpawnerY + 1] = someCreep;
            risovalka.print(map[SpawnerX, SpawnerY + 1], SpawnerX, SpawnerY + 1);
            risovalka.print(map[SpawnerX, SpawnerY], SpawnerX, SpawnerY);

            // map[SpawnerX + 1, SpawnerY + 1] = new Lumberjack();
            // map[SpawnerX + 1, SpawnerY + 1] = new EnergyCollector();


        }
        //public void Turn()

        //{
        //    Respawn();
        //    moving();
        //    Console.ReadLine();
        //}
        //private Random rand = new Random();
        public void Turn()
        {
            for (int i = 0; i < xBarrier; i++)
            {
                for (int j = 0; j < yBarrier; j++)
                {
                    if (map[i, j] != null)
                    {
                            switch (map[i, j].GetType().Name)
                            {
                                case nameof(Miner):
                                    {
                                    someCreep = (Creep)map[i, j];
                                   
                                    if (!someCreep.turned)
                                    {
                                        if (someCreep.reachedTargetX && someCreep.reachedTargetY)
                                        {
                                            if (map[someCreep.targetX,someCreep.targetY].GetType()==typeof(Mine))
                                            {
                                                Resources temporaryRes = (Resources)map[someCreep.targetX, someCreep.targetY];
                                                mining(someCreep, temporaryRes);
                                                someCreep.setTarget(spawnerPoint);
                                                someCreep.reachedTargetX = false;
                                                someCreep.reachedTargetY = false;
                                            }
                                            
                                        }
                                        else
                                        {
                                            moving(someCreep, i, j);

                                        }
                                    
                                    }
                                   
                                    
                                    break;
                                    }

                            }
                 
                        
                    }
                }
            }
        }
        private Random rand = new Random();

        private void moving(Creep someCreep, int i, int j)
        {
            
            int deletePozitionX=i;
            int deletePozitionY=j;
            
            if (someCreep.reachedTargetX == false)
            {
                if (i < someCreep.targetX)
                {
                    printPozitionX = i + 1;
                }
                else
                {
                    printPozitionX = i - 1;
                }
            }
            if (printPozitionX == (someCreep.targetX - 1) || printPozitionX == (someCreep.targetX + 1))

            {
                someCreep.reachedTargetX = true;

            }
            if (someCreep.reachedTargetY==false)
            {
                if (j < someCreep.targetY)
                {
                    printPozitionY = j + 1;
                }
                else
                {
                    printPozitionY = j - 1;
                }
            }
            if (printPozitionY == (someCreep.targetY - 1) || printPozitionY == (someCreep.targetY + 1))
            {
                someCreep.reachedTargetY = true;

            }
            map[printPozitionX, printPozitionY] = map[i, j];
            if (!someCreep.reachedTargetX && !someCreep.reachedTargetY)
            {
               map[deletePozitionX, deletePozitionY] = null;
                Console.SetCursorPosition(deletePozitionX, deletePozitionY);
                Console.Write(" ");
                risovalka.print(map[printPozitionX, printPozitionY], printPozitionX, printPozitionY);
                
            }
        }
        private void spawn()
        {
            int spawnX = rand.Next(119);
            int spawnY = rand.Next(29);
            while (map[spawnX, spawnY] != null)
            {
                spawnX = rand.Next(119);
                spawnY = rand.Next(29);
            }
            map[spawnX, spawnY] = new Mine();
            risovalka.print(map[spawnX, spawnY], spawnX, spawnY);



            //while (map[spawnX, spawnY] != null)
            //{
            //    spawnX = rand.Next(119);
            //    spawnY = rand.Next(29);
            //}
            //map[rand.Next(119), rand.Next(29)] = new Tree();
            //while (map[spawnX, spawnY] != null)
            //{
            //    spawnX = rand.Next(119);
            //    spawnY = rand.Next(29);
            //}
            //map[rand.Next(119), rand.Next(29)] = new Energy();
            //while (map[spawnX, spawnY] != null)
            //{
            //    spawnX = rand.Next(119);
            //    spawnY = rand.Next(29);
            //}


            //map[rand.Next(119), rand.Next(29)] = new Lumberjack();
            //while (map[spawnX, spawnY] != null)
            //{
            //    spawnX = rand.Next(119);
            //    spawnY = rand.Next(29);
            //}
            //map[rand.Next(119), rand.Next(29)] = new EnergyCollector();
            //while (map[spawnX, spawnY] != null)
            //{
            //    spawnX = rand.Next(119);
            //    spawnY = rand.Next(29);
            //}
        }
        private void Respawn(int i,int j)
        {
            if (map[i, j].GetType() == cave.GetType())
            {
                cave = (Mine)map[i, j];

                int x = i;
                int y = j;
                while (map[x, y] != null)
                {
                    x = rand.Next(119);
                    y = rand.Next(29);

                }
                map[x, y] = new Mine();


                map[i, j] = null;


            }
        }
        public point foundTarget(Creep Lexa)
        {

            
            for (int i = 0; i < xBarrier; i++)
            {
                for (int j = 0; j < yBarrier; j++)
                {
                    if (map[i, j] != null)
                    {
                        if (map[i, j].GetType() == typeof(Mine))
                        {
                            //if (Lexa.GetType().Name == nameof(Miner))
                            //{
                            //    setX=1
                            //}
                            setX = i;
                            setY = j;
                        }
                    }
                }
            }
            return new point(setX, setY);
        }
        public void mining(Creep lexa,Resources res)
        {
            lexa.takeRes(res.giveRes(lexa.creepPower));
            lexa.turned = true;
        }
    }
    


    //public void SpawnCreep()
    //{
    //    string num = Console.ReadLine();
    //    int.TryParse(num, out int number);
    //    //
    //    while (!(number < 4 & number > 0))
    //    {
    //        num = Console.ReadLine();
    //        int.TryParse(num, out number);

    //    }


    //}

}
