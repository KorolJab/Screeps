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
        private List<Type> types = new List<Type> { typeof(Miner) };
        public point targeting;
        public object[,] map;
        private Mine cave = new Mine();
        private Tree forest = new Tree();
        private Energy lighting = new Energy();
        static int xBarrier = 120;
        static int yBarrier = 30;
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
            presStart();
            spawn();
            map[SpawnerX, SpawnerY] = new Spawner();
            spawnerPoint= new point(SpawnerX, SpawnerY);
        }
        public void presStart()
        {
            cave.Hp = 100;
            map[SpawnerX, SpawnerY + 1] = new Miner();
            risovalka.print(map[SpawnerX, SpawnerY + 1], SpawnerX, SpawnerY + 1);
            someCreep = (Creep)map[SpawnerX, SpawnerY + 1];
            someCreep.setTarget(foundTarget(someCreep));
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
                                    Resources temporaryRes = (Resources)map[someCreep.targetX, someCreep.targetY];
                                    if (!someCreep.turned)
                                    {
                                        if (someCreep.reachedTargetX && someCreep.reachedTargetY)
                                        {
                                            if (map[someCreep.targetX,someCreep.targetY].GetType()==typeof(Mine))
                                            {
                                                someCreep.takeRes(temporaryRes.giveRes(someCreep.creepPower));
                                                someCreep.setTarget(spawnerPoint);
                                            }
                                            
                                        }
                                        else
                                        {
                                            moving(someCreep, i, j);

                                        }
                                    
                                    }
                                   
                                    
                                    someCreep.setTarget(targeting);
                                    break;
                                    }

                            }
                            Console.ReadLine();
                        
                    }
                }
            }
        }
        private Random rand = new Random();

        private void moving(Creep someCreep, int i, int j)
        {
            int printPozitionX = 1;
            int printPozitionY = 1;
            int deletePozitionX;
            int deletePozitionY;
            if (someCreep.reachedTargetX == false)
            {
                if (i < someCreep.targetX)
                {
                    printPozitionX = i + 1;
                }
                else if (i == someCreep.targetX)
                {
                    printPozitionX = i;
                }
                else
                {
                    printPozitionX = i - 1;
                }

                if (j < someCreep.targetY)
                {
                    printPozitionY = j + 1;
                }
                else if (j == someCreep.targetY)
                {
                    printPozitionY = j;
                }
                else
                {
                    printPozitionY = j - 1;
                }
            }
            if (i == (someCreep.targetX - 1) || i == (someCreep.targetX + 1))
            {
                someCreep.reachedTargetX = true;

            }
            if (i == (someCreep.targetY - 1) || i == (someCreep.targetY + 1))
            {
                someCreep.reachedTargetY = true;

            }
            deletePozitionX = i;
            deletePozitionY = j;
            map[printPozitionX, printPozitionY] = map[i, j];
            map[deletePozitionX, deletePozitionY] = null;
            risovalka.print(map[printPozitionX, printPozitionY], printPozitionX, printPozitionY);
            Console.SetCursorPosition(deletePozitionX, deletePozitionY);
            Console.Write(" ");
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
                //else
                //{
                //    while (map[x, y] != null)
                //    {
                //        x = rand.Next(119);
                //        y = rand.Next(29);
                //    }
                //    map[x, y] = new Mine();

                //}


                map[i, j] = null;

                            
           }
        }
        public point foundTarget(Creep Lexa)
        {

            int setX = 1;
            int setY = 1;
            for (int i = 0; i < xBarrier; i++)
            {
                for (int j = 0; j < yBarrier; j++)
                {
                    if (map[i, j] != null)
                    {
                        if (map[i, j].GetType() == typeof(Mine))
                        {
                            if (Lexa.GetType().Name == nameof(Miner))
                            {
                                setX = 42;
                                setY = 11;
                            }

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
