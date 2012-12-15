using System;
using GameOfLife;

namespace GameOfLifeApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var universe = new Universe();

            int seedChoice;
            if (args.Length != 1 || !int.TryParse(args[0], out seedChoice))
            {
                seedChoice = 0;
            }

            switch (seedChoice)
            {
                case 1:
                    SeedWithBlinker(universe);
                    break;

                case 2:
                    SeedWithToad(universe);
                    break;

                case 3:
                    SeedWithBeacon(universe);
                    break;

                case 4:
                    SeedWithPulsar(universe);
                    break;

                case 5:
                    SeedWithGlider(universe);
                    break;

                case 6:
                    SeedWithLightWeightSpaceShip(universe);
                    break;

                case 7:
                    SeedWithRPentomino(universe);
                    break;

                case 8:
                    SeedWithGun(universe);
                    break;

                default:
                    SeedWithPulsar(universe);
                    break;
            }

            for (; DrawBoundedUniverse(universe); )
            {
                System.Threading.Thread.Sleep(100);
                universe.Tick();
            }
        }

        private static void SeedWithBlinker(Universe universe)
        {
            // http://en.wikipedia.org/wiki/File:Game_of_life_blinker.gif
            // XXX

            universe.AddSeedCellAt(Coords.Create(0, 0));
            universe.AddSeedCellAt(Coords.Create(1, 0));
            universe.AddSeedCellAt(Coords.Create(2, 0));
        }

        private static void SeedWithToad(Universe universe)
        {
            // http://en.wikipedia.org/wiki/File:Game_of_life_toad.gif
            //  XXX
            // XXX

            universe.AddSeedCellAt(Coords.Create(0, 0));
            universe.AddSeedCellAt(Coords.Create(1, 0));
            universe.AddSeedCellAt(Coords.Create(2, 0));
            universe.AddSeedCellAt(Coords.Create(1, 1));
            universe.AddSeedCellAt(Coords.Create(2, 1));
            universe.AddSeedCellAt(Coords.Create(3, 1));
        }

        private static void SeedWithBeacon(Universe universe)
        {
            // http://en.wikipedia.org/wiki/File:Game_of_life_beacon.gif
            // XX
            // XX
            //   XX
            //   XX

            universe.AddSeedCellAt(Coords.Create(-1, 1));
            universe.AddSeedCellAt(Coords.Create(-2, 1));
            universe.AddSeedCellAt(Coords.Create(-1, 0));
            universe.AddSeedCellAt(Coords.Create(-2, 0));
            universe.AddSeedCellAt(Coords.Create(0, -1));
            universe.AddSeedCellAt(Coords.Create(1, -1));
            universe.AddSeedCellAt(Coords.Create(0, -2));
            universe.AddSeedCellAt(Coords.Create(1, -2));
        }

        private static void SeedWithPulsar(Universe universe)
        {
            // http://en.wikipedia.org/wiki/File:Game_of_life_pulsar.gif
            //   XXX   XXX  
            //
            // x    x x    x
            // x    x x    x
            // x    x x    x
            //   XXX   XXX  
            //
            //   XXX   XXX  
            // x    x x    x
            // x    x x    x
            // x    x x    x
            //
            //   XXX   XXX  

            universe.AddSeedCellAt(Coords.Create(2, 1));
            universe.AddSeedCellAt(Coords.Create(3, 1));
            universe.AddSeedCellAt(Coords.Create(4, 1));
            universe.AddSeedCellAt(Coords.Create(2, 6));
            universe.AddSeedCellAt(Coords.Create(3, 6));
            universe.AddSeedCellAt(Coords.Create(4, 6));
            universe.AddSeedCellAt(Coords.Create(1, 2));
            universe.AddSeedCellAt(Coords.Create(1, 3));
            universe.AddSeedCellAt(Coords.Create(1, 4));
            universe.AddSeedCellAt(Coords.Create(6, 2));
            universe.AddSeedCellAt(Coords.Create(6, 3));
            universe.AddSeedCellAt(Coords.Create(6, 4));

            universe.AddSeedCellAt(Coords.Create(-2, 1));
            universe.AddSeedCellAt(Coords.Create(-3, 1));
            universe.AddSeedCellAt(Coords.Create(-4, 1));
            universe.AddSeedCellAt(Coords.Create(-2, 6));
            universe.AddSeedCellAt(Coords.Create(-3, 6));
            universe.AddSeedCellAt(Coords.Create(-4, 6));
            universe.AddSeedCellAt(Coords.Create(-1, 2));
            universe.AddSeedCellAt(Coords.Create(-1, 3));
            universe.AddSeedCellAt(Coords.Create(-1, 4));
            universe.AddSeedCellAt(Coords.Create(-6, 2));
            universe.AddSeedCellAt(Coords.Create(-6, 3));
            universe.AddSeedCellAt(Coords.Create(-6, 4));

            universe.AddSeedCellAt(Coords.Create(2, -1));
            universe.AddSeedCellAt(Coords.Create(3, -1));
            universe.AddSeedCellAt(Coords.Create(4, -1));
            universe.AddSeedCellAt(Coords.Create(2, -6));
            universe.AddSeedCellAt(Coords.Create(3, -6));
            universe.AddSeedCellAt(Coords.Create(4, -6));
            universe.AddSeedCellAt(Coords.Create(1, -2));
            universe.AddSeedCellAt(Coords.Create(1, -3));
            universe.AddSeedCellAt(Coords.Create(1, -4));
            universe.AddSeedCellAt(Coords.Create(6, -2));
            universe.AddSeedCellAt(Coords.Create(6, -3));
            universe.AddSeedCellAt(Coords.Create(6, -4));

            universe.AddSeedCellAt(Coords.Create(-2, -1));
            universe.AddSeedCellAt(Coords.Create(-3, -1));
            universe.AddSeedCellAt(Coords.Create(-4, -1));
            universe.AddSeedCellAt(Coords.Create(-2, -6));
            universe.AddSeedCellAt(Coords.Create(-3, -6));
            universe.AddSeedCellAt(Coords.Create(-4, -6));
            universe.AddSeedCellAt(Coords.Create(-1, -2));
            universe.AddSeedCellAt(Coords.Create(-1, -3));
            universe.AddSeedCellAt(Coords.Create(-1, -4));
            universe.AddSeedCellAt(Coords.Create(-6, -2));
            universe.AddSeedCellAt(Coords.Create(-6, -3));
            universe.AddSeedCellAt(Coords.Create(-6, -4));
        }

        private static void SeedWithGlider(Universe universe)
        {
            // http://en.wikipedia.org/wiki/File:Game_of_life_animated_glider.gif
            // X
            //  XX
            // XX
            universe.AddSeedCellAt(Coords.Create(-5, 5));
            universe.AddSeedCellAt(Coords.Create(-4, 4));
            universe.AddSeedCellAt(Coords.Create(-3, 4));
            universe.AddSeedCellAt(Coords.Create(-5, 3));
            universe.AddSeedCellAt(Coords.Create(-4, 3));
        }

        private static void SeedWithLightWeightSpaceShip(Universe universe)
        {
            // http://en.wikipedia.org/wiki/File:Game_of_life_animated_LWSS.gif
            //   XX
            // XX XX
            // XXXX
            //  XX
            universe.AddSeedCellAt(Coords.Create(-7, 3));
            universe.AddSeedCellAt(Coords.Create(-6, 3));
            universe.AddSeedCellAt(Coords.Create(-9, 2));
            universe.AddSeedCellAt(Coords.Create(-8, 2));
            universe.AddSeedCellAt(Coords.Create(-6, 2));
            universe.AddSeedCellAt(Coords.Create(-5, 2));
            universe.AddSeedCellAt(Coords.Create(-9, 1));
            universe.AddSeedCellAt(Coords.Create(-8, 1));
            universe.AddSeedCellAt(Coords.Create(-7, 1));
            universe.AddSeedCellAt(Coords.Create(-6, 1));
            universe.AddSeedCellAt(Coords.Create(-8, 0));
            universe.AddSeedCellAt(Coords.Create(-7, 0));
        }

        private static void SeedWithRPentomino(Universe universe)
        {
            // http://en.wikipedia.org/wiki/File:Game_of_life_fpento.svg
            //  XX
            // XX
            //  X
            universe.AddSeedCellAt(Coords.Create(15, 10));
            universe.AddSeedCellAt(Coords.Create(15, 11));
            universe.AddSeedCellAt(Coords.Create(15, 12));
            universe.AddSeedCellAt(Coords.Create(16, 12));
            universe.AddSeedCellAt(Coords.Create(14, 11));
        }

        private static void SeedWithGun(Universe universe)
        {
            // http://en.wikipedia.org/wiki/File:Game_of_life_glider_gun.svg
            const int originX = -30;
            const int originY = 25;

            universe.AddSeedCellAt(Coords.Create(originX + 0, originY + 0));
            universe.AddSeedCellAt(Coords.Create(originX + 0, originY + 1));
            universe.AddSeedCellAt(Coords.Create(originX + 1, originY + 0));
            universe.AddSeedCellAt(Coords.Create(originX + 1, originY + 1));

            universe.AddSeedCellAt(Coords.Create(originX + 10, originY + 0));
            universe.AddSeedCellAt(Coords.Create(originX + 10, originY + 1));
            universe.AddSeedCellAt(Coords.Create(originX + 10, originY + -1));
            universe.AddSeedCellAt(Coords.Create(originX + 11, originY + 2));
            universe.AddSeedCellAt(Coords.Create(originX + 11, originY + -2));
            universe.AddSeedCellAt(Coords.Create(originX + 12, originY + 3));
            universe.AddSeedCellAt(Coords.Create(originX + 13, originY + 3));
            universe.AddSeedCellAt(Coords.Create(originX + 12, originY + -3));
            universe.AddSeedCellAt(Coords.Create(originX + 13, originY + -3));
            universe.AddSeedCellAt(Coords.Create(originX + 14, originY + 0));
            universe.AddSeedCellAt(Coords.Create(originX + 15, originY + 2));
            universe.AddSeedCellAt(Coords.Create(originX + 15, originY + -2));
            universe.AddSeedCellAt(Coords.Create(originX + 16, originY + 0));
            universe.AddSeedCellAt(Coords.Create(originX + 16, originY + 1));
            universe.AddSeedCellAt(Coords.Create(originX + 16, originY + -1));
            universe.AddSeedCellAt(Coords.Create(originX + 17, originY + 0));

            universe.AddSeedCellAt(Coords.Create(originX + 20, originY + 1));
            universe.AddSeedCellAt(Coords.Create(originX + 20, originY + 2));
            universe.AddSeedCellAt(Coords.Create(originX + 20, originY + 3));
            universe.AddSeedCellAt(Coords.Create(originX + 21, originY + 1));
            universe.AddSeedCellAt(Coords.Create(originX + 21, originY + 2));
            universe.AddSeedCellAt(Coords.Create(originX + 21, originY + 3));
            universe.AddSeedCellAt(Coords.Create(originX + 22, originY + 4));
            universe.AddSeedCellAt(Coords.Create(originX + 22, originY + 0));
            universe.AddSeedCellAt(Coords.Create(originX + 24, originY + 4));
            universe.AddSeedCellAt(Coords.Create(originX + 24, originY + 5));
            universe.AddSeedCellAt(Coords.Create(originX + 24, originY + 0));
            universe.AddSeedCellAt(Coords.Create(originX + 24, originY + -1));

            universe.AddSeedCellAt(Coords.Create(originX + 34, originY + 2));
            universe.AddSeedCellAt(Coords.Create(originX + 34, originY + 3));
            universe.AddSeedCellAt(Coords.Create(originX + 35, originY + 2));
            universe.AddSeedCellAt(Coords.Create(originX + 35, originY + 3));
        }

        private static bool DrawBoundedUniverse(Universe universe)
        {
            const int maxOffsetFromOrigin = 32;
            const int overallBoardSize = maxOffsetFromOrigin * 2 + 1;
            var numLiveCellsWithinBounds = 0;
            var cells = new bool[overallBoardSize, overallBoardSize];

            universe.IterateLiveCells(
                coords =>
                {
                    if (Math.Abs(coords.X) <= maxOffsetFromOrigin &&
                        Math.Abs(coords.Y) <= maxOffsetFromOrigin)
                    {
                        cells[maxOffsetFromOrigin + coords.X, maxOffsetFromOrigin + coords.Y] = true;
                        numLiveCellsWithinBounds++;
                    }
                });

            for (var row = overallBoardSize - 1; row >= 0; row--)
            {
                var line = string.Empty;
                for (var col = 0; col < overallBoardSize; col++)
                {
                    line += cells[col, row] ? "X" : " ";
                }
                Console.WriteLine(line);
            }

            Console.WriteLine();

            return numLiveCellsWithinBounds > 0;
        }
    }
}
