using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using GameOfLife;

namespace GameOfLifeApp
{
    internal class Program
    {
        [DllImport("Kernel32")]
        public static extern bool SetConsoleCtrlHandler(HandlerRoutine handler, bool add);
        public delegate bool HandlerRoutine(CtrlTypes ctrlType);

        public enum CtrlTypes
        {
            CtrlCEvent = 0,
            CtrlBreakEvent = 1,
            CtrlCloseEvent = 2,
            CtrlLogoffEvent = 5,
            CtrlShutdownEvent = 6
        }

        private const int MaxOffsetFromOriginX = 50;
        private const int MaxOffsetFromOriginY = 32;
        private const int OverallBoardSizeX = MaxOffsetFromOriginX * 2 + 1;
        private const int OverallBoardSizeY = MaxOffsetFromOriginY * 2 + 1;

        private static bool _exitAtNextIteration;
        private static HandlerRoutine _consoleCtrlHandler;

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

            // http://stackoverflow.com/questions/6783561/nullreferenceexception-with-no-stack-trace-when-hooking-setconsolectrlhandler
            _consoleCtrlHandler = consoleCtrlHandler;
            SetConsoleCtrlHandler(_consoleCtrlHandler, true);

            InitialiseConsole();

            for (; DrawBoundedUniverse(universe) && !_exitAtNextIteration; )
            {
                System.Threading.Thread.Sleep(100);
                universe.Tick();
            }

            RestoreConsole();
        }

        private static bool consoleCtrlHandler(CtrlTypes ctrltype)
        {
            if (ctrltype == CtrlTypes.CtrlCEvent)
            {
                _exitAtNextIteration = true;
                return true;
            }

            return false;
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
            const int originX = -45;
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

        private static void InitialiseConsole()
        {
            Console.SetWindowSize(OverallBoardSizeX, OverallBoardSizeY);
            Console.Clear();
        }

        private static void RestoreConsole()
        {
            Console.SetCursorPosition(0, OverallBoardSizeY - 1);
        }

        private static IList<Coords> _previousSetOfLiveCells;

        private static bool DrawBoundedUniverse(Universe universe)
        {
            var nextSetOfLiveCells = new List<Coords>();

            universe.IterateLiveCells(coords =>
                                          {
                                              if (Math.Abs(coords.X) <= MaxOffsetFromOriginX &&
                                                  Math.Abs(coords.Y) <= MaxOffsetFromOriginY)
                                              {
                                                  nextSetOfLiveCells.Add(coords);
                                              }
                                          });

            DrawCellsThatHaveComeAlive(_previousSetOfLiveCells, nextSetOfLiveCells);
            EraseCellsThatHaveDied(_previousSetOfLiveCells, nextSetOfLiveCells);

            _previousSetOfLiveCells = nextSetOfLiveCells;

            return nextSetOfLiveCells.Any();
        }

        private static void DrawCellsThatHaveComeAlive(ICollection<Coords> previousSetOfLiveCells, IEnumerable<Coords> nextSetOfLiveCells)
        {
            foreach (var coords in nextSetOfLiveCells)
            {
                var drawCell = true;

                if (previousSetOfLiveCells != null)
                {
                    drawCell = !previousSetOfLiveCells.Contains(coords);
                }

                if (drawCell)
                {
                    DrawCell(coords);
                }
            }
        }

        private static void EraseCellsThatHaveDied(IEnumerable<Coords> previousSetOfLiveCells, ICollection<Coords> nextSetOfLiveCells)
        {
            if (previousSetOfLiveCells != null)
            {
                foreach (var coords in previousSetOfLiveCells)
                {
                    if (!nextSetOfLiveCells.Contains(coords))
                    {
                        EraseCell(coords);
                    }
                }
            }
        }

        private static void DrawCell(Coords gridCoords)
        {
            DrawCharacter(gridCoords, 'X');
        }

        private static void EraseCell(Coords gridCoords)
        {
            DrawCharacter(gridCoords, ' ');
        }

        private static void DrawCharacter(Coords gridCoords, char character)
        {
            var consoleCoords = GridCoordsToConsoleCoords(gridCoords);
            Console.SetCursorPosition(consoleCoords.X, consoleCoords.Y);
            Console.Write(character);
        }

        private static Coords GridCoordsToConsoleCoords(Coords coords)
        {
            return Coords.Create(
                MaxOffsetFromOriginX + coords.X,
                OverallBoardSizeY - MaxOffsetFromOriginY - coords.Y - 1);
        }
    }
}
