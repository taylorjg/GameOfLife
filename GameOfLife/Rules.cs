﻿using System.Linq;

namespace GameOfLife
{
    public static class Rules
    {
        public static Grid NextGeneration(Grid currentGrid)
        {
            var nextGrid = new Grid();

            currentGrid.IterateLiveCells((coords, cellState) =>
            {
                if (CurrentlyAliveCellWillStillBeALiveInTheNextGeneration(currentGrid, coords))
                {
                    nextGrid.MarkLiveCellAt(coords);
                }
                else
                {
                    nextGrid.MarkWasPreviouslyAliveCellAt(coords);
                }

                foreach (var neighbour in coords.Neighbours())
                {
                    if (!currentGrid.IsLiveCellAt(neighbour))
                    {
                        if (CurrentlyDeadCellWillBecomeALiveInTheNextGeneration(currentGrid, neighbour))
                        {
                            if (currentGrid.CellWasPreviouslyAliveAt(neighbour))
                            {
                                nextGrid.MarkZombieCellAt(neighbour);
                            }
                            else
                            {
                                nextGrid.MarkLiveCellAt(neighbour);
                            }
                        }
                    }
                }
            });

            return nextGrid;
        }

        // Any live cell with fewer than two live neighbours dies, as if caused by under-population.
        // Any live cell with two or three live neighbours lives on to the next generation.
        // Any live cell with more than three live neighbours dies, as if by overcrowding.
        // Any dead cell with exactly three live neighbours becomes a live cell, as if by reproduction.

        internal static bool CurrentlyAliveCellWillStillBeALiveInTheNextGeneration(Grid currentGrid, Coords coords)
        {
            var numLiveNeighbours = GetNumLiveNeighbours(currentGrid, coords);

            // Rules 1, 2 and 3.
            return (numLiveNeighbours == 2 || numLiveNeighbours == 3);
        }

        internal static bool CurrentlyDeadCellWillBecomeALiveInTheNextGeneration(Grid currentGrid, Coords coords)
        {
            var numLiveNeighbours = GetNumLiveNeighbours(currentGrid, coords);

            // Rule 4.
            return (numLiveNeighbours == 3);
        }

        private static int GetNumLiveNeighbours(Grid currentGrid, Coords coords)
        {
            var coordsOfNeighbours = coords.Neighbours();
            return coordsOfNeighbours.Count(currentGrid.IsLiveCellAt);
        }
    }
}
