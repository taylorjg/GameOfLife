using System;
using System.Threading;
using GameOfLife;

namespace GameOfLifeApp
{
    internal class Program
    {
        private const int MaxOffsetFromOriginX = 50;
        private const int MaxOffsetFromOriginY = 32;
        private const int OverallBoardSizeX = MaxOffsetFromOriginX * 2 + 1;
        private const int OverallBoardSizeY = MaxOffsetFromOriginY * 2 + 1;
        private const int DefaultSeedChoice = 4;
        private const int DefaultTickSleepInterval = 100;

        private static void Main(string[] args)
        {
            var seedChoice = DefaultSeedChoice;
            var tickSleepInterval = DefaultTickSleepInterval;

            if (args.Length >= 1)
            {
                if (!int.TryParse(args[0], out seedChoice))
                {
                    seedChoice = DefaultSeedChoice;
                }
            }

            if (args.Length == 2)
            {
                if (!int.TryParse(args[1], out tickSleepInterval))
                {
                    tickSleepInterval = DefaultTickSleepInterval;
                }
            }

            var universe = new Universe();
            SeedPatterns.SeedTheUniverse(universe, seedChoice);

            InitialiseConsole();

            ConsoleCtrlHandler.RunUntilCtrlC(() => RunLoop(universe, tickSleepInterval));

            RestoreConsole();
        }

        private static ConsoleCtrlHandler.RunLoopResult RunLoop(Universe universe, int tickSleepInterval)
        {
            if (!DrawBoundedUniverse(universe))
            {
                return ConsoleCtrlHandler.RunLoopResult.Quit;
            }

            Thread.Sleep(tickSleepInterval);
            universe.Tick();

            return ConsoleCtrlHandler.RunLoopResult.KeepGoing;
        }

        private static void InitialiseConsole()
        {
            Console.SetWindowSize(OverallBoardSizeX, OverallBoardSizeY);
            Console.Clear();
        }

        private static void RestoreConsole()
        {
            Console.SetCursorPosition(0, OverallBoardSizeY - 2);
        }

        private static bool DrawBoundedUniverse(Universe universe)
        {
            universe.IterateCellsThatHaveComeAlive(DrawCell);
            universe.IterateCellsThatHaveDied(EraseCell);
            return SomeLiveCellsAreWithinBounds(universe);
        }

        private static bool SomeLiveCellsAreWithinBounds(Universe universe)
        {
            var result = false;

            universe.IterateLiveCells((coords, cellState) =>
                                          {
                                              if (GridCoordsAreWithinBounds(coords))
                                              {
                                                  result = true;
                                              }
                                          });

            return result;
        }

        private static void DrawCell(Coords gridCoords, CellState cellState)
        {
            if (GridCoordsAreWithinBounds(gridCoords))
            {
                var savedForegroundColor = Console.ForegroundColor;

                Console.ForegroundColor = cellState.IsZombie ? ConsoleColor.Magenta : ConsoleColor.Cyan;
                DrawCharacter(gridCoords, 'X');

                Console.ForegroundColor = savedForegroundColor;
            }
        }

        private static void EraseCell(Coords gridCoords, CellState cellState)
        {
            if (GridCoordsAreWithinBounds(gridCoords))
            {
                DrawCharacter(gridCoords, ' ');
            }
        }

        private static void DrawCharacter(Coords gridCoords, char character)
        {
            var consoleCoords = GridCoordsToConsoleCoords(gridCoords);
            Console.SetCursorPosition(consoleCoords.X, consoleCoords.Y);
            Console.Write(character);
        }

        private static bool GridCoordsAreWithinBounds(Coords gridCoords)
        {
            return Math.Abs(gridCoords.X) <= MaxOffsetFromOriginX &&
                   Math.Abs(gridCoords.Y) <= MaxOffsetFromOriginY;
        }

        private static Coords GridCoordsToConsoleCoords(Coords coords)
        {
            return Coords.Create(
                MaxOffsetFromOriginX + coords.X,
                OverallBoardSizeY - MaxOffsetFromOriginY - coords.Y - 1);
        }
    }
}
