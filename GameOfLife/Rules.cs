using System.Linq;

namespace GameOfLife
{
    public static class Rules
    {
        public static Grid NextGeneration(Grid currentGrid)
        {
            var nextGrid = new Grid();

            currentGrid.IterateLiveCells(coords =>
            {
                if (WillCurrentlyAliveCellBeALiveInTheNextGeneration(currentGrid, coords))
                {
                    nextGrid.MarkLiveCellAt(coords);
                }

                foreach (var neighbour in coords.Neighbours())
                {
                    if (!currentGrid.IsLiveCellAt(neighbour))
                    {
                        if (WillCurrentlyDeadCellBecomeALiveInTheNextGeneration(currentGrid, neighbour))
                        {
                            nextGrid.MarkLiveCellAt(neighbour);
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

        internal static bool WillCurrentlyAliveCellBeALiveInTheNextGeneration(Grid currentGrid, Coords coords)
        {
            var numLiveNeighbours = GetNumLiveNeighbours(currentGrid, coords);

            // Rules 1, 2 and 3.
            return (numLiveNeighbours == 2 || numLiveNeighbours == 3);
        }

        internal static bool WillCurrentlyDeadCellBecomeALiveInTheNextGeneration(Grid currentGrid, Coords coords)
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
