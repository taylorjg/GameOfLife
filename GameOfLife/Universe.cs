using System;

namespace GameOfLife
{
    public class Universe
    {
        private Grid _grid = new Grid();

        public void AddSeedCellAt(Coords coords)
        {
            _grid.MarkLiveCellAt(coords);
        }

        public void Tick()
        {
            _grid = Rules.NextGeneration(_grid);
        }

        public void IterateLiveCells(Action<Coords, CellState> action)
        {
            _grid.IterateLiveCells(action);
        }
    }
}
