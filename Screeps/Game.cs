﻿using System;
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
        public Game()
        {
            map = new object[xBarrier, yBarrier];
            risovalka = new Printer();
            presStart();
            spawn();
            map[SpawnerX, SpawnerY] = new Spawner();
        }
        public void presStart()
        {
            cave.Hp = 100;
            map[SpawnerX, SpawnerY + 1] = new Miner();
            risovalka.print(map[SpawnerX, SpawnerY + 1], SpawnerX, SpawnerY + 1);
           // map[SpawnerX + 1, SpawnerY + 1] = new Lumberjack();
           // map[SpawnerX + 1, SpawnerY + 1] = new EnergyCollector();


        }
        public void Turn()

        {
            Respawn();
            moving();
            Console.ReadLine();
        }
        private Random rand = new Random();
       
       

        private void spawn()
        {
            
            int spawnX = rand.Next(119);
            int spawnY = rand.Next(29);
            while(map[spawnX,spawnY] != null)
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
        private void Respawn()
        {
            for (int i = 0; i < xBarrier; i++)
            {
                for (int j = 0; j < yBarrier; j++)
                {
                   // Console.Write(map[i, j]);
                    if (map[i, j] != null)
                    {
                        if (map[i, j].GetType() == cave.GetType())
                        {
                            cave = (Mine)map[i, j];
                            if (cave.Hp == 0)
                            {
                                int x = i;
                                int y = j;
                                if (map[x, y] == null)
                                {
                                     x = rand.Next(119);
                                     y = rand.Next(29);
                                    map[x, y] = new Mine();

                                }
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
                        //if (map[i, j].GetType() == forest.GetType())
                        //{
                        //    forest = (Tree)map[i, j];
                        //    if (forest.Hp == 0)
                        //    {
                        //        int x = rand.Next(xBarrier);
                        //        int y = rand.Next(yBarrier);
                        //        if (map[x, y] == null)
                        //        {
                        //            map[x, y] = new Tree();

                        //        }
                        //        else
                        //        {
                        //            while (map[x, y] != null)
                        //            {
                        //                x = rand.Next(xBarrier);
                        //                y = rand.Next(yBarrier);
                        //            }
                        //            map[x, y] = new Tree();

                        //        }



                        //    }

                        //    if (map[i, j].GetType() == lighting.GetType())
                        //    {
                        //        lighting = (Energy)map[i, j];
                        //        if (lighting.Hp == 0)
                        //        {
                        //            int x = rand.Next(xBarrier);
                        //            int y = rand.Next(yBarrier);
                        //            if (map[x, y] == null)
                        //            {
                        //                map[x, y] = new Energy();

                        //            }
                        //            else
                        //            {
                        //                while (map[x, y] != null)
                        //                {
                        //                    x = rand.Next(xBarrier);
                        //                    y = rand.Next(yBarrier);
                        //                }
                        //                map[x, y] = new Energy();

                        //            }



                        //        }

                        //    }
                        //}

                    }
                }
            }
        }
        public point foundTarget(Creep Lexa)
        {
            
            int setX=1;
            int setY=1;
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
            return new point(setX,setY);
        }
private void moving()
        {
            
            int printPozitionX;
            int printPozitionY;
            int deletePozitionX;
            int deletePozitionY;
            for (int i = 0; i < xBarrier; i++)
            {
                for (int j = 0; j < yBarrier; j++)
                {
                    if (map[i, j] != null)
                    {
                        switch(map[i, j].GetType().Name)
                        {
                            
                            case nameof(Miner):
                                {
                                    someCreep = foundTarget((Creep) map[i, j]);
                                    map[i, j] = someCreep;
                                    if (i < someCreep.targetX)
                                    {
                                        printPozitionX = i+1;
                                    }
                                    else if (i == someCreep.targetX)
                                    {
                                        printPozitionX = i;
                                    }
                                    else 
                                    {
                                        printPozitionX = i-1;
                                    }

                                    if (j < someCreep.targetY)
                                    {
                                        printPozitionY = j+1;
                                    }
                                    else if(j== someCreep.targetY)
                                    {
                                        printPozitionY = j;
                                    }
                                    else
                                    {
                                        printPozitionY = j-1;
                                    }
                                    
                                    deletePozitionX = i;
                                    deletePozitionY = j;
                                    map[printPozitionX, printPozitionY] = map[i, j];
                                    map[deletePozitionX, deletePozitionY] = null;
                                    risovalka.print(map[printPozitionX, printPozitionY], printPozitionX, printPozitionY);
                                    Console.SetCursorPosition(deletePozitionX, deletePozitionY);
                                    Console.Write(" ");
                                    break;
                                }
                        }
                        //Console.Write(map[i, j]);
                        //if (map[i,j].GetType() == typeof(Miner))
                        //{
                            
                        //}
                        //if (map[i, j].GetType() == typeof(Lumberjack))
                        //{
                        //    Lumberjack worker = (Lumberjack)map[i, j];
                        //    if (i < worker.targetX)
                        //    {
                        //        map[i + 1, j] = map[i, j];
                        //        risovalka.print(map[i + 1, j], i + 1, j);

                        //        map[i, j] = null;
                        //    }
                        //    else
                        //    {
                        //        map[i - 1, j] = map[i, j];
                        //        map[i, j] = null;
                        //    }
                        //}

                        //if (map[i, j].GetType() == typeof(EnergyCollector))
                        //{
                        //    EnergyCollector worker = (EnergyCollector)map[i, j];
                        //    if (i < worker.targetX)
                        //    {
                        //        map[i + 1, j] = map[i, j];
                        //        risovalka.print(map[i + 1, j], i + 1, j);

                        //        map[i, j] = null;
                        //    }
                        //    else
                        //    {
                        //        map[i - 1, j] = map[i, j];
                        //        map[i, j] = null;
                        //    }
                        //}
                    }
                }
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
}
