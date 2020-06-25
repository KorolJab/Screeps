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


        public object[,] map = new object[xBarrier, yBarrier];
        private Mine cave = new Mine();
        private Tree forest = new Tree();
        private Energy lighting = new Energy();
        static int xBarrier = 120;
        static int yBarrier = 30;
        public Printer risovalka;
        private int SpawnerX = 59, SpawnerY = 14;

        public point mapping;
        public Game()
        {

           
            map[SpawnerX, SpawnerY] = new Spawner();
            classes = new List<Creep>() { new Miner(), new Lumberjack(), new EnergyCollector() };


        }
        public void presStart()
        {
            map[SpawnerX, SpawnerY + 1] = new Miner();
            map[SpawnerX + 1, SpawnerY + 1] = new Lumberjack();
            map[SpawnerX + 1, SpawnerY + 1] = new EnergyCollector();


        }
        public void Turn()
        {
            spawn();
            Respawn();

            moving();

        }
        private Random rand = new Random();
        public int x;
        public int y;
        public List<Creep> classes;
        //шахтёр
        point pont = new point();
        //дровосекас
        point pont1 = new point();
        //электрик вася
        point pont2 = new point();
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
            object Ris = map[spawnX, spawnY];
            risovalka.print(Ris, spawnX, spawnY, spawnX + 1, spawnY);


            while (map[spawnX, spawnY] != null)
            {
                spawnX = rand.Next(119);
                spawnY = rand.Next(29);
            }
            map[rand.Next(119), rand.Next(29)] = new Tree();
            while (map[spawnX, spawnY] != null)
            {
                spawnX = rand.Next(119);
                spawnY = rand.Next(29);
            }
            map[rand.Next(119), rand.Next(29)] = new Energy();
            while (map[spawnX, spawnY] != null)
            {
                spawnX = rand.Next(119);
                spawnY = rand.Next(29);
            }
            map[rand.Next(119), rand.Next(29)] = new Miner();
            while (map[spawnX, spawnY] != null)
            {
                spawnX = rand.Next(119);
                spawnY = rand.Next(29);
            }
            map[rand.Next(119), rand.Next(29)] = new Lumberjack();
            while (map[spawnX, spawnY] != null)
            {
                spawnX = rand.Next(119);
                spawnY = rand.Next(29);
            }
            map[rand.Next(119), rand.Next(29)] = new EnergyCollector();
            while (map[spawnX, spawnY] != null)
            {
                spawnX = rand.Next(119);
                spawnY = rand.Next(29);
            }
        }
        private void Respawn()
        {
            for (int i = 0; i < xBarrier; i++)
            {

                for (int j = 0; j < yBarrier; j++)
                {
                    if (map[i, j] != null)
                    {
                        if (map[i, j].GetType() == cave.GetType())
                        {
                            cave = (Mine)map[i, j];
                            if (cave.Hp == 0)
                            {
                                int x = rand.Next(119);
                                int y = rand.Next(29);
                                if (map[x, y] == null)
                                {
                                    map[x, y] = new Mine();

                                }
                                else
                                {
                                    while (map[x, y] != null)
                                    {
                                        x = rand.Next(119);
                                        y = rand.Next(29);
                                    }
                                    map[x, y] = new Mine();

                                }



                            }
                        }
                        if (map[i, j].GetType() == forest.GetType())
                        {
                            forest = (Tree)map[i, j];
                            if (forest.Hp == 0)
                            {
                                int x = rand.Next(xBarrier);
                                int y = rand.Next(yBarrier);
                                if (map[x, y] == null)
                                {
                                    map[x, y] = new Tree();

                                }
                                else
                                {
                                    while (map[x, y] != null)
                                    {
                                        x = rand.Next(xBarrier);
                                        y = rand.Next(yBarrier);
                                    }
                                    map[x, y] = new Tree();

                                }



                            }

                            if (map[i, j].GetType() == lighting.GetType())
                            {
                                lighting = (Energy)map[i, j];
                                if (lighting.Hp == 0)
                                {
                                    int x = rand.Next(xBarrier);
                                    int y = rand.Next(yBarrier);
                                    if (map[x, y] == null)
                                    {
                                        map[x, y] = new Energy();

                                    }
                                    else
                                    {
                                        while (map[x, y] != null)
                                        {
                                            x = rand.Next(xBarrier);
                                            y = rand.Next(yBarrier);
                                        }
                                        map[x, y] = new Energy();

                                    }



                                }

                            }
                        }
                        map[i, j] = null;

                    }
                }
            }
        }
        public void foundTarget(Creep Lexa)
        {
            int creepX = 0;
            int creepY = 0;
            bool flag = false;
            Resources target = null;
            if (Lexa.GetType() == typeof(Miner))
            {

                target = new Mine();
            }
            else if (Lexa.GetType() == typeof(Lumberjack))
            {
                target = new Tree();
            }
            else
            {
                target = new Energy();
            }
            for (int i = 0; i < xBarrier; i++)
            {

                for (int j = 0; j < yBarrier; j++)
                {

                    if (map[i, j].GetType() == target.GetType())
                    {

                        creepX = i;
                        creepY = j;
                        flag = !flag;
                    }
                    if (map[i, j].GetType() == target.GetType() && flag)
                    {
                        if (Lexa.GetType() == typeof(Miner))
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
        
        private void moving()
        {

            for (int i = 0; i < xBarrier; i++)
            {
                for (int j = 0; j < yBarrier; j++)
                {
                    if (map[i, j] != null)
                    {

                        if (map[i,j].GetType() == typeof(Miner))
                        {
                            Miner worker = (Miner)map[i, j];
                            if (i < worker.targetX)
                            {
                                map[i + 1, j] = map[i, j];
                                risovalka.print(map[i + 1, j], i, j, i + 1, j);
                                map[i, j] = null;
                            }
                            else
                            {
                                map[i - 1, j] = map[i, j];
                                map[i, j] = null;
                            }
                        }
                        if (map[i, j].GetType() == typeof(Lumberjack))
                        {
                            Lumberjack worker = (Lumberjack)map[i, j];
                            if (i < worker.targetX)
                            {
                                map[i + 1, j] = map[i, j];
                                risovalka.print(map[i + 1, j], i, j, i + 1, j);

                                map[i, j] = null;
                            }
                            else
                            {
                                map[i - 1, j] = map[i, j];
                                map[i, j] = null;
                            }
                        }

                        if (map[i, j].GetType() == typeof(EnergyCollector))
                        {
                            EnergyCollector worker = (EnergyCollector)map[i, j];
                            if (i < worker.targetX)
                            {
                                map[i + 1, j] = map[i, j];
                                risovalka.print(map[i + 1, j], i, j, i + 1, j);

                                map[i, j] = null;
                            }
                            else
                            {
                                map[i - 1, j] = map[i, j];
                                map[i, j] = null;
                            }
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
            while (!(number < 4 & number > 0))
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
