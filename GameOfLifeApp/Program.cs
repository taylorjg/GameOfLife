using System;
using System.Collections.Generic;
using System.Linq;
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

            ConsoleCtrlHandler.RunUntilCtrlC(() =>
                                     {
                                         if (!DrawBoundedUniverse(universe))
                                         {
                                             return ConsoleCtrlHandler.RunLoopResult.Quit;
                                         }

                                         System.Threading.Thread.Sleep(tickSleepInterval);
                                         universe.Tick();

                                         return ConsoleCtrlHandler.RunLoopResult.KeepGoing;
                                     });

            RestoreConsole();
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

        private static IDictionary<Coords, CellState> _previousSetOfLiveCells;

        private static bool DrawBoundedUniverse(Universe universe)
        {
            var nextSetOfLiveCells = new Dictionary<Coords, CellState>();

            universe.IterateLiveCells((coords, cellState) =>
                                          {
                                              if (Math.Abs(coords.X) <= MaxOffsetFromOriginX &&
                                                  Math.Abs(coords.Y) <= MaxOffsetFromOriginY)
                                              {
                                                  nextSetOfLiveCells.Add(coords, cellState);
                                              }
                                          });

            DrawCellsThatHaveComeAlive(_previousSetOfLiveCells, nextSetOfLiveCells);
            EraseCellsThatHaveDied(_previousSetOfLiveCells, nextSetOfLiveCells);

            _previousSetOfLiveCells = nextSetOfLiveCells;

            return nextSetOfLiveCells.Any();
        }

        private static void DrawCellsThatHaveComeAlive(
            IDictionary<Coords, CellState> previousSetOfLiveCells,
            IEnumerable<KeyValuePair<Coords, CellState>> nextSetOfLiveCells)
        {
            foreach (var kvp in nextSetOfLiveCells)
            {
                var drawCell = true;

                if (previousSetOfLiveCells != null)
                {
                    drawCell = !previousSetOfLiveCells.ContainsKey(kvp.Key);
                }

                if (drawCell)
                {
                    DrawCell(kvp.Key, kvp.Value);
                }
            }
        }

        private static void EraseCellsThatHaveDied(
            IEnumerable<KeyValuePair<Coords, CellState>> previousSetOfLiveCells,
            IDictionary<Coords, CellState> nextSetOfLiveCells)
        {
            if (previousSetOfLiveCells != null)
            {
                foreach (var kvp in previousSetOfLiveCells)
                {
                    if (!nextSetOfLiveCells.ContainsKey(kvp.Key))
                    {
                        EraseCell(kvp.Key);
                    }
                }
            }
        }

        private static void DrawCell(Coords gridCoords, CellState cellState)
        {
            var savedForegroundColor = Console.ForegroundColor;

            Console.ForegroundColor = cellState.IsZombie ? ConsoleColor.Magenta : ConsoleColor.Cyan;
            DrawCharacter(gridCoords, 'X');

            Console.ForegroundColor = savedForegroundColor;
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
